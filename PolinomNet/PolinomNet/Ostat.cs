using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PolinomNet
{
    class Ostat
    {
        static public BigInteger MathOstat(BigInteger n_BigInteger, BigInteger d_BigInteger)
        {
            //BigInteger ost;
            double n = (double)n_BigInteger;
            double d = (double)d_BigInteger;
            double ost_double = n - d * Math.Floor(n / d);
            BigInteger ost = (BigInteger)ost_double;

            //BigInteger ost = BigInteger.DivRem(n, d, out _);
            //BigInteger.DivRem(n, d, out ost);

           //ost = BigInteger.Remainder(n, d);
           return ost;
        }
    }
}
