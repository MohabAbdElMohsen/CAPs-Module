/*using UnityEditor;

namespace CapabilitiesModule.Editor
{
    [CustomEditor(typeof(Evaluator))]
    public class EvaluatorEditor : UnityEditor.Editor
    {
        private SerializedProperty _isClampedProp;
        private SerializedProperty _minProp;
        private SerializedProperty _maxProp;
        private SerializedProperty _absoluteProp;
        
        private void OnEnable()
        {
            _isClampedProp = serializedObject.FindProperty("_isClamped");
            _minProp = serializedObject.FindProperty("_min");
            _maxProp = serializedObject.FindProperty("_max");
            _absoluteProp = serializedObject.FindProperty("_absolute");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_isClampedProp);

            if (_isClampedProp.boolValue)
            {
                EditorGUILayout.PropertyField(_minProp);
                EditorGUILayout.PropertyField(_maxProp);
            }

            EditorGUILayout.PropertyField(_absoluteProp);

            serializedObject.ApplyModifiedProperties();
        }
    }   
}*/