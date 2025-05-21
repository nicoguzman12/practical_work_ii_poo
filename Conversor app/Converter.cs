using System;
using System.Collections;

namespace Conversor_app
{
    public class Converter
    {
        private List<Conversion> operations;

        public Converter()
        {
            this.operations = new List<Conversion>();

            this.operations.Add(new DecimalToBinary("Decimal to Binary", "Decimal to Binary"));
            this.operations.Add(new DecimalToOctal("Decimal to Octal", "Decimal to Octal"));
            this.operations.Add(new DecimalToTwoComplement("Decimal to Two's Complement", "Decimal to Two's Complement")); 
            this.operations.Add(new DecimalToHexadecimal("Decimal to Hexadecimal", "Decimal to Hexadecimal"));
            this.operations.Add(new TwoComplementToDecimal("Two's Complement to Decimal", "Binary (TwoComplement) to Decimal"));
            this.operations.Add(new BinaryToDecimal("Binary to Decimal", "Binary to Decimal"));
            this.operations.Add(new OctalToDecimal("Octal to Decimal", "Octal to Decimal"));
            this.operations.Add(new HexadecimalToDecimal("Hexadecimal to Decimal", "Hexadecimal to Decimal"));
        }

        public int Exit()
        {
            return this.operations.Count + 1;
        }

        public int GetNumberOfOperations()
        {
            return this.operations.Count;
        }

        public int PrintOperations()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------");

            for (int i = 1; i <= this.operations.Count; i++)
            {
                Console.WriteLine($"{i}. {this.operations[i - 1].GetName()}");
            }

            Console.WriteLine($"{this.Exit()}. Exit");
            Console.Write("---------------------------------------");

            string tmp = Console.ReadLine();

            if (tmp == "") return this.Exit();

            int option = int.Parse(tmp);

            return (option <= 1 || option > this.GetNumberOfOperations()) ? this.Exit() + 1 : option;
        }

        public string PerformConversion(int op, string input)
        {
            this.operations[op - 1].validate(input);

            if (this.operations[op - 1].NeedBitSize())
            {
                Console.Write("How many bits should I use: ");
                int bits = Int32.Parse(Console.ReadLine());
                return this.operations[op - 1].Change(input, bits);
            }

            return this.operations[op - 1].Change(input);
        }

        public void PrintConversion(int op, string input, string output)
        {
            this.operations[op - 1].PrintConversion(input, output);
        }
    }
}