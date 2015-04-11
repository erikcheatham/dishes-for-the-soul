using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumDishes
{
    public static class ValueObjects
    {
        public class Inputs
        {
            public String input { get; set; }

            public String output { get; set; }

            public List<int> dishList { get; set; }

            public bool retry { get; set; }

            public String finished { get; set; }
        }

        //public enum timeOfDay
        //{
        //    morning = 1,
        //    night = 2
        //}

        //public enum dishes
        //{
        //    entree = 1,
        //    side = 2,
        //    drink = 3,
        //    dessert = 4
        //}

        public enum morningDishes
        {
            eggs = 1,
            toast = 2,
            coffee = 3
        }

        public enum nightDishes
        {
            steak = 1,
            potato = 2,
            wine = 3,
            cake = 4
        }
    }
}
