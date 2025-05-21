using System;

namespace oopguidedpw7
{
    public class OctalToDecimal : Conversion
    {
        public OctalToDecimal(string name, string definition) : base(name, definition, new OctalInputValidator())
        {

        }

        public override string Change(string input)
        {
            int decimalValue = 0;
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                char digitChar = input[i];
                int digit = digitChar - '0';
                int power = length - 1 - i;

                decimalValue += digit * (int)Math.Pow(8, power);
            }

            return decimalValue.ToString();
        }
    }
}