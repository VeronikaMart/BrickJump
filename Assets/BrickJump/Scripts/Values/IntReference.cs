using System;

namespace StackJump.Values
{
    [Serializable]
    public class IntReference
    {
        public IntVariable variable;
        public int Value => variable.IntValue;

        public static implicit operator int(IntReference reference) => reference.Value;
    }
}