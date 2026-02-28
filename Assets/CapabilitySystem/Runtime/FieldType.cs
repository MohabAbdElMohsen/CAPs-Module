using System.ComponentModel;


namespace CapabilitySystem
{
    internal enum FieldType
    {
        [Description("int")]
        Integer,

        [Description("float")]
        Float,
        
        [Description("bool")]
        Boolean,

        [Description("string")]
        String,
        
        Vector2,
        
        Vector3,
        
        Vector4,
    }   
}