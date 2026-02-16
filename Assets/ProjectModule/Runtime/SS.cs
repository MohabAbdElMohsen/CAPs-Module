using UnityEngine;
using EvaluationSystem;

[CreateAssetMenu(fileName = "SS", menuName = "Scriptable Objects/SS")]
public class SS : ScriptableObject
{
    [SerializeField] private float s;
    
    public float Evaluate(EvaluationContext ctx)
    {
        return s / 1;
    }
}
