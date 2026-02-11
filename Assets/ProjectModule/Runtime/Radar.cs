using System;
using UnityEngine;
using CapabilitiesModule;

public class Radar : MonoBehaviour
{
    private EvaluationContext _evaluationContext;

    private void Start()
    {
        _evaluationContext = CapabilityManager.Instance.EvaluationContext;
    }

    [ContextMenu("Detect")]
    public void Detect()
    {
        _evaluationContext["DetectionLatency"] = Time.time;
    }
}
