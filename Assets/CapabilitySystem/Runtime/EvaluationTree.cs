using UnityEngine;
using XNode;

namespace CapabilitySystem
{
	[CreateAssetMenu(fileName = "CapabilityTee", menuName = "Capability System/CapabilityTee")]
	public sealed class CapabilityTree : NodeGraph
	{
		public float Evaluate() =>
			((Evaluable)nodes[0]).Evaluate();
	}
}