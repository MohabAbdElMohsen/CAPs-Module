using System;

public interface IDetectable
{
    float AvgLatency { get; }
    
    Int32 DetectionCount { get; }
    
    void Detect();
}