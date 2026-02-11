using UnityEngine;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "AttentionToDetailsCustomEvaluation", menuName = "Scriptable Objects/AttentionToDetailsCustomEvaluation")]
    public class AttentionToDetailsCustomEvaluation : ScriptableObject,  ICustomEvaluation
    {
        [SerializeField] private float minTime;
    
        public float Evaluate(EvaluationContext ctx)
        {
            return Mathf.Clamp01(minTime / ctx["DetectionLatency"]);
        }
    }   
}