using System;
using System.Collections.Generic;
using System.IO;

namespace oppguidedpw
{
    public class Converter
    {
        private List<string> operations = new List<string>();
        private string separator;

        public Converter(string separator)
        {
            this.separator = separator;
        }

        public void AddOperation(string input, string output, string conversion, string error, string errorMessage)
        {
            string operation = "";
            operation += input + separator;
            operation += output + separator;
            operation += conversion + separator;
            operation += error + separator;
            operation += errorMessage;
            this.operations.Add(operation);
        }

        public void SaveOperationsToFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                foreach (string op in this.operations)
                {
                    writer.WriteLine(op);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}