using System.Collections.Generic;
using UnityEngine;
using XNode;
using Sirenix.OdinInspector;

namespace CapabilitySystem
{
    public abstract class Evaluable : Node
    {
        [Input(connectionType = ConnectionType.Multiple)]
        [SerializeField] private Evaluable _dependents;
        
        [Output(connectionType = ConnectionType.Multiple)]
        [SerializeField] private Evaluable _dependencies;

        [Header("Options")]
        [SerializeField, Range(0.0f, 1.0f)] private float _weight;
        
        [SerializeField] private bool _isClamped = true;
        [SerializeField][ShowIf("_isClamped")] private float _min;
        [SerializeField][ShowIf("_isClamped")] private float _max = 1.0f;
        
        [SerializeField] private bool _absolute = true;

        public float Weight
        {
            get => _weight;
            set => _weight = Mathf.Clamp(value, 0.0f, 1.0f);
        }

        protected List<Evaluable> Dependencies { get; private set; }

        protected override void Init()
        {
            List<Evaluable> list = new List<Evaluable>();
            NodePort port = GetOutputPort("_dependencies");

            if (port != null)
                foreach (var connection in port.GetConnections())
                {
                    if (connection.node is Evaluable evaluable)
                        list.Add(evaluable);
                }

            Dependencies  = list;
        }
        
        public float Evaluate()
        {
            float value = OnEvaluate();
            
            if (_absolute)
                value = Mathf.Abs(value);
            if (_isClamped)
                value = Mathf.Clamp(value, _min, _max);
            
            return value;
        }
        
        protected abstract float OnEvaluate();
    }
}