using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;

namespace CapabilitySystem.Editor
{
    [CustomEditor(typeof(EvaluationContext))]
    public class EvaluationContextEditor : UnityEditor.Editor
    {
        private SerializedProperty fieldProp;
        private SerializedProperty fieldsProp;

        private void OnEnable()
        {
            fieldProp = serializedObject.FindProperty("Field");
            fieldsProp = serializedObject.FindProperty("Fields");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Add New Field", EditorStyles.boldLabel);

            // Horizontal layout: Field + Add Button
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(fieldProp, GUIContent.none);

            if (GUILayout.Button("Add", GUILayout.Width(50)))
            {
                AddField();
            }

            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Existing Fields", EditorStyles.boldLabel);

            // Display the Fields list nicely
            for (int i = 0; i < fieldsProp.arraySize; i++)
            {
                var f = fieldsProp.GetArrayElementAtIndex(i);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(f, GUIContent.none);

                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    fieldsProp.DeleteArrayElementAtIndex(i);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            // Generate Button
            if (GUILayout.Button("Generate Class", GUILayout.Height(30)))
            {
                Generate((EvaluationContext)target);
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void AddField()
        {
            serializedObject.Update();

            var fieldObj = fieldProp.FindPropertyRelative("Name").stringValue;
            if (string.IsNullOrEmpty(fieldObj))
            {
                Debug.LogWarning("Field Name cannot be empty!");
                return;
            }

            // Prevent duplicates
            bool exists = false;
            for (int i = 0; i < fieldsProp.arraySize; i++)
            {
                var existingName = fieldsProp.GetArrayElementAtIndex(i).FindPropertyRelative("Name").stringValue;
                if (existingName == fieldObj)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Debug.LogWarning($"Field '{fieldObj}' already exists!");
                return;
            }

            // Add field
            fieldsProp.arraySize++;
            var newField = fieldsProp.GetArrayElementAtIndex(fieldsProp.arraySize - 1);
            newField.FindPropertyRelative("Name").stringValue = fieldProp.FindPropertyRelative("Name").stringValue;
            newField.FindPropertyRelative("Type").enumValueIndex = fieldProp.FindPropertyRelative("Type").enumValueIndex;
            newField.FindPropertyRelative("AccessModifier").enumValueIndex = fieldProp.FindPropertyRelative("AccessModifier").enumValueIndex;

            // Clear input
            fieldProp.FindPropertyRelative("Name").stringValue = "";

            serializedObject.ApplyModifiedProperties();
        }

        private void Generate(EvaluationContext t)
        {
            if (fieldsProp.arraySize == 0)
            {
                Debug.LogWarning("No fields to generate!");
                return;
            }

            var sb = new StringBuilder();

            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            sb.AppendLine("namespace CapabilitySystem");
            sb.AppendLine("{");
            sb.AppendLine("    [CreateAssetMenu(fileName = \"EvaluationContext\", menuName = \"Scriptable Objects/EvaluationContext\")]");
            sb.AppendLine("    public class EvaluationContext : ScriptableObject");
            sb.AppendLine("    {");
            sb.AppendLine("#if UNITY_EDITOR");
            sb.AppendLine("        [SerializeField] internal FieldDefinition Field;");
            sb.AppendLine("        [SerializeField] internal List<FieldDefinition> Fields = new();");
            sb.AppendLine("#endif");
            sb.AppendLine();

            // Generate actual fields
            for (int i = 0; i < fieldsProp.arraySize; i++)
            {
                var f = fieldsProp.GetArrayElementAtIndex(i);
                string access = ((AccessModifier)f.FindPropertyRelative("AccessModifier").enumValueIndex).GetDescription();
                string type = ((FieldType)f.FindPropertyRelative("Type").enumValueIndex).GetDescription();
                string name = f.FindPropertyRelative("Name").stringValue;

                sb.AppendLine($"        {access} {type} {name};");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            MonoScript currentScript = MonoScript.FromScriptableObject(t);
            string scriptPath = AssetDatabase.GetAssetPath(currentScript);

            string folderPath = $"{Path.GetDirectoryName(scriptPath)}/../Runtime";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = $"{folderPath}/EvaluationContext.cs";

            File.WriteAllText(filePath, sb.ToString());

            AssetDatabase.Refresh();

            Debug.Log("EvaluationContext.cs generated successfully!");
        }
    }
}