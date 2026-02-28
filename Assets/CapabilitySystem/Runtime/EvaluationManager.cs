using UnityEngine;

namespace CapabilitySystem
{
    public class EvaluationManager : MonoBehaviour
    {
        public static EvaluationManager Instance { get; private set; }
        
        [SerializeField] private CapabilityTree _evaluationTree;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                
                return;
            }

            Instance = this;
        
            DontDestroyOnLoad(gameObject);
        }

        [ContextMenu("Evaluate Root Capability")]
        public void EvaluateRootCapability() =>
            Debug.Log(_evaluationTree?.Evaluate());
    }
}