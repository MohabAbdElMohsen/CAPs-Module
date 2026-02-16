using UnityEngine;
using EvaluationSystem.Utilities;

namespace CapabilitySystem
{
    [CreateAssetMenu(fileName = "EvaluationContext", menuName = "Scriptable Objects/EvaluationContext")]
    public class EvaluationContext : ScriptableObject
    {
        [SerializeField] private ParameterDictionary _parameterDictionary;
        
        public float this[string key]
        {
            get => _parameterDictionary[key];
            set => _parameterDictionary[key] = value;
        }
    }   
}
