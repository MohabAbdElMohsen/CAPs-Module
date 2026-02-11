using UnityEngine;
using CapabilitiesModule;

[CreateAssetMenu(fileName = "SS", menuName = "Scriptable Objects/SS")]
public class SS : ScriptableObject, ICustomEvaluation
{
    [SerializeField] private float s;
    
    public float Evaluate(EvaluationContext ctx)
    {
        return s / 1;
    }
}
