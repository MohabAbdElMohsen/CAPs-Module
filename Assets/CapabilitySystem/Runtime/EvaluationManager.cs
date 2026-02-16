using UnityEngine;

namespace CapabilitySystem
{
    public class EvaluationManager : MonoBehaviour
    {
        public static EvaluationManager Instance { get; private set; }
        
        [SerializeField] private CapabilityTree _evaluationTree;
        
        [SerializeField] private EvaluationContext _evaluationContextTemplate;

        [HideInInspector] public EvaluationContext EvaluationContext;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                
                return;
            }

            Instance = this;
        
            DontDestroyOnLoad(gameObject);
            
            EvaluationContext = Instantiate(_evaluationContextTemplate);
        }

        [ContextMenu("Evaluate Root Capability")]
        public void EvaluateRootCapability() =>
            Debug.Log(_evaluationTree?.Evaluate(EvaluationContext));
    }
}