using UnityEngine;
using CapabilitiesModule.Utilities;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "EvaluationContext", menuName = "Scriptable Objects/EvaluationContext")]
    public class EvaluationContext : ScriptableObject
    {
        [SerializeField] private MetricDictionary _metricDictionary;
        
        public float this[string key]
        {
            get => _metricDictionary[key];
            set => _metricDictionary[key] = value;
        }
    }   
}
