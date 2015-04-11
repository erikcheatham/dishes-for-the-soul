using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumDishes
{
    public class OutputOperations
    {
        const string com = ", ";

        public static ValueObjects.Inputs FormatOutput(ValueObjects.Inputs i)
        {
            //Initiate output string
            i.output = "";

            //Initiate a new list of integers
            i.dishList = new List<int>();

            //Split the inputs into an array by comma delimiter
            String[] list = i.input.Split(',');

            //foreach item in the array if the string can be parsed into an integer dump into dishlist
            foreach (String c in list)
            {
                int l = 0;
                if (int.TryParse(c, out l))
                {
                    i.dishList.Add(l);
                }
            }

            //Use LINQ to get the count of items as well as their integers
            var dishHash = i.dishList.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderBy(x => x.Value);

            //check the fisrt item of the array for a morning or night order
            switch (list[0])
            {
                case "morning":
                    foreach (var dish in dishHash)
                    {
                        //Begin building output string for each dish
                        switch (dish.Value)
                        {
                            case 1:
                                i = CatchOutputs(i, dish.Count, ValueObjects.morningDishes.eggs.ToString());
                                break;
                            case 2:
                                i = CatchOutputs(i, dish.Count, ValueObjects.morningDishes.toast.ToString());
                                break;
                            case 3:
                                //If the count of dishes for only coffee in the mornings exceeds one then output appropriately
                                i = Multiples(i, dish.Count, ValueObjects.morningDishes.coffee.ToString());
                                break;
                            default:
                                i.output += "error" + com;
                                break;
                        }
                    }
                    break;
                case "night":
                    foreach (var dish in dishHash)
                    {
                        switch (dish.Value)
                        {
                            case 1:
                                i = CatchOutputs(i, dish.Count, ValueObjects.nightDishes.steak.ToString());
                                break;
                            case 2:
                                //If the count of dishes for only potatoes in the evenings exceeds one then output appropriately
                                i = Multiples(i, dish.Count, ValueObjects.nightDishes.potato.ToString());
                                break;
                            case 3:
                                i = CatchOutputs(i, dish.Count, ValueObjects.nightDishes.wine.ToString());
                                break;
                            case 4:
                                i = CatchOutputs(i, dish.Count, ValueObjects.nightDishes.cake.ToString());
                                break;
                            default:
                                i.output += "error" + com;
                                break;
                        }
                    }
                    break;
                default:
                    i.retry = true;
                    break;
            }
            i = Finish(i);
            return i;
        }
        public static ValueObjects.Inputs CatchOutputs(ValueObjects.Inputs i, int count, string name)
        {
            if (count > 1)
            {
                i.output += name + com + "error|";
            }
            else
            {
                i.output += name + com;
            }
            return i;
        }
        public static ValueObjects.Inputs Multiples(ValueObjects.Inputs i, int count, string name)
        {
            if (count == 1)
            {
                i.output += name + com;
            }
            else
            {
                i.output += String.Format("{0}(x{1}){2}", name, count, com);
            }
            return i;
        }

        public static ValueObjects.Inputs Finish(ValueObjects.Inputs i)
        {
            if (i.output.Equals(String.Empty))
            { i.retry = true; }
            //Early error handling
            else if (i.output.Contains('|'))
            { i.output = i.output.Remove(i.output.LastIndexOf('|')); }
            //Remove trailing comma and space
            else
            { i.output = i.output.Remove(i.output.LastIndexOf(',')); }
            
            return i;
        }
    }
}
