using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateZ1
{
    internal interface IMath
    {

        double Sum(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Del(double x, double y);
    }
}
