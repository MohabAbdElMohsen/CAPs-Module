using UnityEngine;
using CapabilitySystem;

public class Radar : MonoBehaviour, IDetectable
{
    private EvaluationContext _evaluationContext;

    private float _totalDetectionLatency;
    
    private float _avgLatency;
    
    public float AvgLatency => _avgLatency;

    private int _detectionCount;
    public int DetectionCount => _detectionCount;
    
    private void Start()
    {
        //_evaluationContext = EvaluationManager.Instance.EvaluationContext;
    }

    [ContextMenu("Detect")]
    public void Detect()
    {
        _totalDetectionLatency = Time.time;
        _detectionCount = 5;
        
        _avgLatency = _totalDetectionLatency / _detectionCount;
        //_evaluationContext["DetectionLatency"] =  _avgLatency;
    }
}
