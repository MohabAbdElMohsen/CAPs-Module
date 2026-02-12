using UnityEngine;
using XNode;

namespace CapabilitiesModule
{
	[CreateAssetMenu(fileName = "EvaluationTree", menuName = "Evaluation System/EvaluationTree")]
	public sealed class EvaluationTree : NodeGraph
	{
		public float Evaluate(EvaluationContext ctx) =>
			((Evaluator)nodes[0]).Evaluate(ctx);
	}	
}