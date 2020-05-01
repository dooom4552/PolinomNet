using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PolinomNet
{
    class Converter_PolinomClass
    {
        public List<double> Converter(List<Reciprocal_Class> list_Reciprocal_Class)
        {
            List<double> List_Polinom = new List<double>();
            int maxpower = (int)list_Reciprocal_Class[0].power;
            double[] Polinom = new double[maxpower+1];

            
            foreach (Reciprocal_Class reciprocal_Class in list_Reciprocal_Class)
            {
                double power = reciprocal_Class.power;
                //List_Polinom[(int)power] = reciprocal_Class.factor;
                Polinom[(int)power]= reciprocal_Class.factor;
            }
            List_Polinom = Polinom.ToList();
            List_Polinom.Reverse();
            return List_Polinom;
        }
    }
}
