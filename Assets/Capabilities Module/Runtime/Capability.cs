using UnityEngine;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "Capability", menuName = "Scriptable Objects/Capability")]
    public sealed class Capability : ScriptableObject
    {
        [SerializeField] private string _capabilityId;
        [SerializeField] private string _capabilityName;
        
        [SerializeField] private ScriptableObject _customEvaluation;
        
        public string CapabilityId => _capabilityId;
        
        public string CapabilityName => _capabilityName;

        private ICustomEvaluation CustomEvaluation
        {
            get
            {
                ICustomEvaluation evaluation = _customEvaluation as ICustomEvaluation;
                
                if (_customEvaluation != null && evaluation == null)
                {
                    Debug.LogError($"{_customEvaluation.name} does not implement ICustomEvaluation!");
                }

                return evaluation;
            }
        }
        
        public float Evaluate(EvaluationContext ctx) =>
            CustomEvaluation?.Evaluate(ctx) ?? 0.0f;
    }   
}