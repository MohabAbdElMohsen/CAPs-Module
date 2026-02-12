using UnityEngine;

namespace CapabilitiesModule
{
    [CreateAssetMenu(fileName = "Capability", menuName = "Scriptable Objects/Capability")]
    public sealed class Capability : Evaluator
    {
        [SerializeField] private string _capabilityId;
        [SerializeField] private string _capabilityName;
        
        
        public string CapabilityId => _capabilityId;
        
        public string CapabilityName => _capabilityName;
    }
}