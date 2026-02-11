using UnityEngine;

namespace CapabilitiesModule
{
    [System.Serializable]
    public class WeightedCapability
    {
        [SerializeField] private Capability _capability;
        [SerializeField] private float _weight = 1.0f;
    
        public Capability Capability => _capability;
    
        public float Weight => _weight;
    }   
}