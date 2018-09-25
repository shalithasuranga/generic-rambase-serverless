using GenericServerlessFunction.serverless;
using System;
using System.Text;

namespace GenericServerlessFunction
{
    class Program
    {
        private static string getStdin() {
            StringBuilder buffer = new StringBuilder();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.AppendLine(s);
            }
            return buffer.ToString();
        }

        static void Main(string[] args) {
            string buffer = "";
            ServerlessFunction f = new ServerlessFunction();

            string responseValue = f.Handle(buffer);

            if (responseValue != null)
            {
                Console.Write(responseValue);
            }
            Console.Read();
        }
    }
}
