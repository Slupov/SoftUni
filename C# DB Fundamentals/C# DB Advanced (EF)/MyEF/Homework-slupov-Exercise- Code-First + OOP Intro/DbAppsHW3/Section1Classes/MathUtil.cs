using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAppsHW3
{
    class MathUtil
    {
        public static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1*num2;
        }

        public static double Divide(double dividend, double divisor)
        {
            //floating point precision fixed
            return dividend/(divisor + 0.000001d);
        }

        public static double Percentage(double totalNumber, double percent)
        {
            return totalNumber*(percent/100);
        }
    }
}