using UnityEngine;

namespace EvaluationSystem
{
    public class EvaluationManager : MonoBehaviour
    {
        public static EvaluationManager Instance { get; private set; }
        
        [SerializeField] private EvaluationTree _evaluationTree;
        
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