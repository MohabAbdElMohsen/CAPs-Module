using UnityEngine;
using XNode;
using Sirenix.OdinInspector;

namespace CapabilitySystem
{
    public sealed class Capability : Node, IEvaluable, IWeightable
    {
        [Input(connectionType = ConnectionType.Multiple)] 
        [SerializeField] private Node _dependents;
        
        [Output(connectionType = ConnectionType.Multiple)] 
        [SerializeField] private Node _dependencies;

        [Header("Options")]
        [SerializeField, Range(0.0f, 1.0f)]private float _weight;
        
        [SerializeField] private bool _isClamped = true;
        [SerializeField][ShowIf("_isClamped")] private float _min;
        [SerializeField][ShowIf("_isClamped")] private float _max = 1.0f;
        
        [SerializeField] private bool _absolute = true;

        public float Weight
        {
            get => _weight;
            set => _weight = Mathf.Clamp(value, 0.0f, 1.0f);
        }
        
        public float Evaluate(EvaluationContext ctx)
        {
            float value = 0.0f;

            NodePort outputPort = GetOutputPort("_dependencies");
            if (outputPort != null)
            {
                foreach (NodePort connection in outputPort.GetConnections())
                {
                    if (connection.node is IEvaluable evaluable)
                    {
                        if(connection.node is IWeightable weightable)
                            value += evaluable.Evaluate(ctx) * weightable.Weight;
                    }
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