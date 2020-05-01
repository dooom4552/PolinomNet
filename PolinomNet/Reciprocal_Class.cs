using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomNet
{
    class Reciprocal_Class  //одночлекн
    {

        public double factor { get; set; }
        public double power { get; set; }

        public string result { get; set; }

        public string ReciprocalBilder(double factor, double power)
        {
            string res = $"{factor}x^{power}";
            return res;
        }
    }
}
