using UnityEngine;
using XNode;
using Sirenix.OdinInspector;

namespace EvaluationSystem
{
    public class Evaluator : Node
    {
        [Input(connectionType = ConnectionType.Multiple)] 
        [SerializeField] private Evaluator _dependencies;
        
        [Output(connectionType = ConnectionType.Multiple)] 
        [SerializeField] private Evaluator _dependents;

        [Header("Evaluation Options")]
        [SerializeField, Range(0f, 1f)]private float _weight;
        
        [SerializeField] private bool _isClamped = true;
        [SerializeField][ShowIf("_isClamped")] private float _min;
        [SerializeField][ShowIf("_isClamped")] private float _max = 1f;
        
        [SerializeField] private bool _absolute = true;

        public float Weight
        {
            get => _weight;
            set => _weight = Mathf.Clamp(value, 0f, 1f);
        }
        
        public virtual float Evaluate(EvaluationContext ctx)
        {
            float value = 0.0f;

            NodePort outputPort = GetOutputPort("_dependents");
            if (outputPort != null)
            {
                foreach (NodePort connection in outputPort.GetConnections())
                {
                    if (connection.node is Evaluator evaluator)
                        value += evaluator.Evaluate(ctx) * evaluator.Weight;
                }
            }
            
            if (_absolute)
                value = Mathf.Abs(value);
            
            if (_isClamped)
                value = Mathf.Clamp(value, _min, _max);

            return value;
        }
    }
}