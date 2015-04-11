using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumDishes
{
    class Program
    {
        static void Main(string[] args)
        {
            InputOrder();
        }

        private static void InputOrder()
        {
            //Build Object For Program Wide Inputs
            ValueObjects.Inputs i = new ValueObjects.Inputs();

            //Set initial retry flag to true
            i.retry = true;

            while (i.retry)
            {
                Console.WriteLine("Enter Your Order");
                i.input = Console.ReadLine().Replace(" ", "").ToLower();

                //Ouput is parsed and returned for screen printing
                i = OutputOperations.FormatOutput(i);                
                Console.WriteLine(i.output);
                Console.WriteLine();

                //break loop once they are finished/or data is input correctly                
                Console.WriteLine("Are You Finished Inputting Orders? y/n");
                i.finished = Console.ReadLine().ToLower();
                if (i.finished == "y")
                {
                    i.retry = false;
                }
                else
                {
                    i.retry = true;
                }
            }
        }
    }
}
