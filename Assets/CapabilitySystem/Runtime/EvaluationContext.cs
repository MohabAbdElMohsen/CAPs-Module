using System.Collections.Generic;
using UnityEngine;

namespace CapabilitySystem
{
    [CreateAssetMenu(fileName = "EvaluationContext", menuName = "Scriptable Objects/EvaluationContext")]
    public class EvaluationContext : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] internal FieldDefinition Field;
        [SerializeField] internal List<FieldDefinition> Fields = new();
#endif

        public int SS;
        public Vector3 RR;
        public bool IsDead;
        public bool IsGrounded;
    }
}
