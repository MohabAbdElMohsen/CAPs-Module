using System;

namespace CapabilitySystem
{
    [Serializable]
    internal class FieldDefinition
    {
        public AccessModifier AccessModifier;
        public FieldType Type;
        public string Name;
    }
}