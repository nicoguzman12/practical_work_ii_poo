using System;

namespace Conversor_app
{
    public class TwoComplementToDecimal : Conversion
    {
        public TwoComplementToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {
        }

        public override string Change(string input)
        {
            int n = input.Length;
            if (n == 0) return "0";

            bool isNegative = input[0] == '1';

            int result = 0;

            if (!isNegative)
            {
                // to convert a positive binary number into a decimal one
                for (int i = 0; i < n; i++)
                {
                    int bit = input[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }
            }
            else
            {
                char[] inverted = new char[n];

                // to invert the bits from 1 to 0 and viceversa
                for (int i = 0; i < n; i++)
                {
                    inverted[i] = input[i] == '1' ? '0' : '1';
                }

                // to add one to the number converted
                for (int i = n - 1; i >= 0; i--)
                {
                    if (inverted[i] == '0')
                    {
                        inverted[i] = '1';
                        break;
                    }
                    else
                    {
                        inverted[i] = '0';
                    }
                }

                // convert to decimal
                for (int i = 0; i < n; i++)
                {
                    int bit = inverted[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }

                result = -result;
            }

            return result.ToString();
        }
    }
}