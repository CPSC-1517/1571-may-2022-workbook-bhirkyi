using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        //static classes are not instantiated by the user 
        //static class items are referenced using the calssname.xxxxxxxxxxxx
        //methods within this class have the keyword static in their signature
        //static classes are shared between all outside users at the SAME time
        //DO NOT consider saving data within a static class BECAUSE you cannot be certain it will be ther when you use the class again

        public static bool IsZeroPostive(int value)
        {
            bool valid = true;
            if(value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPostive(decimal value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPostive(double value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}
