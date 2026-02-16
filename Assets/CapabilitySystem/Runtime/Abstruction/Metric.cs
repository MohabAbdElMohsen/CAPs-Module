using UnityEngine;
using XNode;
using Sirenix.OdinInspector;

namespace CapabilitySystem
{
    public abstract class Metric : Node, IEvaluable, IWeightable
    {
        [Input(connectionType = ConnectionType.Multiple)] 
        [SerializeField] private Node _dependents;
        
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
        
        public abstract float Evaluate(EvaluationContext ctx);
    }
}