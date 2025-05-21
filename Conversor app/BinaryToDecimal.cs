using System;

namespace Conversor_app
{
    public class BinaryToDecimal : Conversion
    {
        public BinaryToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {
        }

        public override string Change(string input)
        {
            int decimalValue = 0;
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                char bit = input[i];
                int digit = bit - '0';
                int power = length - 1 - i;
                decimalValue += digit * (int)Math.Pow(2, power);
            }
            return decimalValue.ToString();
        }
    }
}