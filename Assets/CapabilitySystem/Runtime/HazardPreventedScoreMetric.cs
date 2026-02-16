namespace CapabilitySystem
{
    public class HazardPreventedScoreMetric : Metric
    {
        public override float Evaluate(EvaluationContext ctx)
        {
            return ctx["TotalWeightedOutcomes"] / ctx["TotalWeights"];
        }
    }   
}