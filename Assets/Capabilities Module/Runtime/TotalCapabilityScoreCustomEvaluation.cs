using System.Collections.Generic;
using UnityEngine;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "TotalCapabilityScoreCustomEvaluation", menuName = "Scriptable Objects/TotalCapabilityScoreCustomEvaluation")]
    public class TotalCapabilityScoreCustomEvaluation : ScriptableObject, ICustomEvaluation
    {
        [SerializeField] private List<WeightedCapability> _weightedCapabilities;
    
        public float Evaluate(EvaluationContext ctx)
        {
            float sum = 0.0f;
        
            foreach (var weightedCapability in _weightedCapabilities)
                sum += weightedCapability.Capability.Evaluate(ctx) * weightedCapability.Weight;

            return sum;
        }
    }   
}