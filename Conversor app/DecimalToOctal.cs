using System;

namespace Conversor_app
{
    public class DecimalToOctal : Conversion
    {
        public DecimalToOctal(string name, string definition) : base(name, definition, new DecimalInputValidator())
        {
        }

        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            if (number == 0) return "0";

            string octalString = "";

            while (number > 0)
            {
                int remainder = number % 8;
                octalString = remainder + octalString;
                number /= 8;
            }

            return octalString;
        }
    }
}