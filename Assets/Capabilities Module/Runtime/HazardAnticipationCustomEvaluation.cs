using UnityEngine;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "HazardAnticipationCustomEvaluation", menuName = "Scriptable Objects/HazardAnticipationCustomEvaluation")]
    public class HazardAnticipationCustomEvaluation : ScriptableObject, ICustomEvaluation
    {
        public float Evaluate(EvaluationContext ctx) =>
            (ctx["AnticipationTiming"] * 0.6f) + (ctx["HazardPreventedScore"] * 0.4f);
    }   
}