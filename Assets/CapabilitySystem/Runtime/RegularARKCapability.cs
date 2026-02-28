namespace CapabilitySystem
{
    public sealed class RegularARKCapability : Evaluable
    {
        protected override float OnEvaluate()
        {
            float value = 0.0f;
            
            foreach (Evaluable evaluable in Dependencies)
                value += evaluable.Evaluate() * evaluable.Weight;
            
            return value;
        }
    }
}