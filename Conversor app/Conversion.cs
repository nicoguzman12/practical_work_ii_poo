using System;

namespace oopguidedpw7
{
    public abstract class Conversion
    {
        protected string name;
        protected string definition;
        protected bool bitSize;
        protected InputValidator validator;

        public Conversion(string name, string definition, InputValidator validator)
        {
            this.name = name;
            this.definition = definition;
            this.validator = validator;
            this.bitSize = false;
        }
        public Conversion(string name, string definition,InputValidator validator, bool bitSize)
        {
            this.name = name;
            this.definition = definition;
            this.validator = validator;
            this.bitSize = bitSize;
        }

        public void PrintConversion(string input, string output)
        {
            Console.Clear();
            Console.WriteLine($"{this.name} representation of {input} is {output}");
            Console.ReadLine();
        }

        public abstract string Change(string input);
        public virtual string Change(string input, int bits)
        {
            throw new NotImplementedException("This method is not implemented in this subclass.");
        }


        public string GetName()
        {
            return this.name;
        }

        public string GetDefinition()
        {
            return this.definition;
        }

        public bool NeedBitSize()
        {
            return this.bitSize;
        }

       protected string DecimalToTwosComplement(int number, int size = 16)
        {
            int minVal = -(1 << (size - 1));
            int maxVal = (1 << (size - 1)) - 1;

            if (number < minVal || number > maxVal)
            
                return "";

            uint unsignedValue = (uint) number & ((1u << size) -1);
            string binaryString = Convert.ToString(unsignedValue, 2).PadLeft(size, '0' );
            return binaryString.PadLeft(size, '0');
            
        }
        private string DecimalToBinary(int number)
        {
            if(number == 0) return "0";

            string binaryString = "";

            while (number > 0)
            {
                int remainder = number % 2;
                binaryString = remainder + binaryString;
                number /= 2;
            }

            return binaryString;
        }
        private string DecimalToOctal(int number)
        {
            if (number == 0) return "0";

            string octalString = "";

            while (number >0)
            {
                int remainder = number % 8;
                octalString = remainder + octalString;
                number /= 8;
            }
            
            return octalString;
        }
        private string DecimalToHexadecimal(int number)
        {
            char[] hexChars = "0123456789ABCDEF".ToCharArray();

            if (number == 0) return "0";

            string hexString = "";

            while (number >0)
            {
                int remainder = number % 16;
                hexString = hexChars[remainder] + hexString;
                number /= 16;
            }
            
            return hexString;
    }
   
        public void PrintConversion(int finalBase, string input, string output)
        {
            string name = "";

            if(finalBase == 1)
                name = "binary";
            else if (finalBase == 2)
                name = "Octal";
            else if (finalBase == 3)
                name = "Hexadecimal";
            else if (finalBase == 4)
                name = "Binary (2Complement)";

            Console.Clear();
            Console.WriteLine($"{name} representation of {input} is {output}");
            Console.ReadLine();
               
       
        }

        public void validate(string input)
        {
            this.validator.validate(input);
        }
    }
}