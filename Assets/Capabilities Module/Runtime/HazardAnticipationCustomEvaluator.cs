using UnityEngine;
using CapabilitiesModule;

public class HazardAnticipationCustomEvaluator : ScriptableObject, ICustomEvaluation
{
    public float Evaluate(EvaluationContext ctx) =>
        (ctx["AnticipationTiming"] * 0.6f) + (ctx["HazardPreventedScore"] * 0.4f);
} 