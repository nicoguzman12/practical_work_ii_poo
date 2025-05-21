using System;

namespace Conversor_app
{
    public class HexadecimalToDecimal : Conversion
    {
        public HexadecimalToDecimal(string name, string definition) : base(name, definition, new HexadecimalInputValidator())
        {

        }

        public override string Change(string input)
        {
            int decimalValue = 0;
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                char digitChar = input[i];
                int digit;
                if (char.IsDigit(digitChar))
                {
                    digit = digitChar - '0';
                }
                else
                {
                    digit = char.ToUpper(digitChar) - 'A' + 10;
                }

                int power = length - i - 1;
                decimalValue += digit * (int)Math.Pow(16, power);
            }

            return decimalValue.ToString();
        }
    }
}