using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateZ1
{
    internal class Real:IMath
    {
        public Real() { }

        public double Sum(double x, double y) 
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Del(double x, double y)
        {
            return x / y;
        }
    }
}
