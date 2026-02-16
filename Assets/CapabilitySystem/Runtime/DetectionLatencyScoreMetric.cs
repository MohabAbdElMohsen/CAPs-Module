namespace CapabilitySystem
{
    public class DetectionLatencyScoreMetric : Metric
    {
        public override float Evaluate(EvaluationContext ctx)
        {
            return ctx["MinTime"] / ctx["DetectionLatency"];
        }
    }   
}