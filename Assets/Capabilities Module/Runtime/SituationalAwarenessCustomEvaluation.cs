using System.Collections.Generic;
using UnityEngine;
using CapabilitiesModule;

[CreateAssetMenu(fileName = "SituationalAwarenessCustomEvaluation", menuName = "Scriptable Objects/SituationalAwarenessCustomEvaluation")]
public class SituationalAwarenessCustomEvaluation : ScriptableObject, ICustomEvaluation
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
