using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Numerics;
using System.Linq;

namespace PolinomNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Reciprocal_Class> list_Reciprocal_divider_Class = new List<Reciprocal_Class>();
        List<Reciprocal_Class> list_Reciprocal_dividend_Class = new List<Reciprocal_Class>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            double p = Convert.ToDouble(TextBoxPole.Text.Trim());
            List<double> arraydivider = new List<double>();
            List<double> arraydividend = new List<double>();
            string TextBoxdivider_string = TextBoxdivider.Text.Trim();
            arraydivider = TextBoxdivider_string.Split(' ').Select(i => Convert.ToDouble(i)).ToList();
            string TextBoxdividend_string = TextBoxdividend.Text.Trim();
            arraydividend = TextBoxdividend_string.Split(' ').Select(i => Convert.ToDouble(i)).ToList();

            TextBoxResult.Text = PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked);

            #region
            //int counter = arraydivider.Count - arraydividend.Count;
            //counter = Math.Abs(counter);
            ////MessageBox.Show(counter.ToString());

            //if (arraydivider.Count > arraydividend.Count)
            //{
            //    for (int i = 0; i < counter; i++)
            //    {
            //        arraydividend.Insert(0, 0); //в начало нули
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < counter; i++)
            //    {
            //        arraydivider.Insert(0, 0); //в начало нули
            //    }
            //}

            ////string Newstring = string.Join(" ", arraydivider);
            ////MessageBox.Show(Newstring);
            ////MessageBox.Show(arraydivider.Count.ToString());

            ////Newstring = string.Join(" ", arraydividend);
            ////MessageBox.Show(Newstring);
            ////MessageBox.Show(arraydividend.Count.ToString());



            //divider = arraydivider.ToArray();
            //dividend = arraydividend.ToArray();

            //if (divider.Length > dividend.Length)
            //{
            //    MatrixWidth = divider.Length + 2;
            //}
            //else
            //{
            //    MatrixWidth = dividend.Length + 2;
            //}


            ////MessageBox.Show(MatrixWidth.ToString());
            //MatrixHeigth = divider.Length * 2 + 3;
            ////MessageBox.Show(MatrixHeigth.ToString());
            ////string Newstring = string.Join(" ", divider);
            ////MessageBox.Show(Newstring);

            ////string Newstring2 = string.Join(" ", dividend);
            ////MessageBox.Show(Newstring2);

            //double[,] BigArray = new double[MatrixWidth, MatrixHeigth];
            //BigArray[3, 0] = p;

            //for (int x = 2; x <= MatrixWidth - 1; x++)
            //{
            //    BigArray[x, 4] = divider[x - 2];
            //    BigArray[x, 6] = dividend[x - 2];

            //    for (int i = 2, j = 6; i <= MatrixWidth - 3 && j <= MatrixHeigth - 3; i++, j += 2)
            //    {
            //        if (x >= i)
            //        {
            //            BigArray[x, j + 1] = Ostat.MathOstat(BigArray[i, j] * BigArray[x - i + 2, 4], p);
            //            BigArray[x, j + 2] = Ostat.MathOstat(BigArray[x, j] - BigArray[x, j + 1], p);
            //        }
            //    }
            //    #region процедурка               
            //    //BigArray[x, 7] = Ostat.MathOstat(BigArray[2, 6] * BigArray[x, 4], p);
            //    //BigArray[x, 8] = Ostat.MathOstat(BigArray[x, 6] - BigArray[x, 7], p);

            //    //if (x >= 3)// if (x >= 3) увелич на 1 начинается с 2
            //    //{
            //    //    BigArray[x, 9] = Ostat.MathOstat(BigArray[3, 8] * BigArray[x - 1, 4], p);// BigArray[x, 9] начинается с 7 увелич на 2 
            //    //    BigArray[x, 10] = Ostat.MathOstat(BigArray[x, 8] - BigArray[x, 9], p);
            //    //}
            //    //if (x >= 4)
            //    //{
            //    //    BigArray[x, 11] = Ostat.MathOstat(BigArray[4, 10] * BigArray[x - 2, 4], p);
            //    //    BigArray[x, 12] = Ostat.MathOstat(BigArray[x, 10] - BigArray[x, 11], p);
            //    //}
            //    //if (x >= 5)
            //    //{
            //    //    BigArray[x, 13] = Ostat.MathOstat(BigArray[5, 12] * BigArray[x - 3, 4], p);
            //    //    BigArray[x, 14] = Ostat.MathOstat(BigArray[x, 12] - BigArray[x, 13], p);
            //    //}
            //    //if (x >= 6)
            //    //{
            //    //    BigArray[x, 15] = Ostat.MathOstat(BigArray[6, 14] * BigArray[x - 4, 4], p);
            //    //    BigArray[x, 16] = Ostat.MathOstat(BigArray[x, 14] - BigArray[x, 15], p);
            //    //}
            //    //if (x >= 7)
            //    //{
            //    //    BigArray[x, 17] = Ostat.MathOstat(BigArray[7, 16] * BigArray[x - 5, 4], p);
            //    //    BigArray[x, 18] = Ostat.MathOstat(BigArray[x, 16] - BigArray[x, 17], p);
            //    //}
            //    //if (x >= 8)
            //    //{
            //    //    BigArray[x, 19] = Ostat.MathOstat(BigArray[8, 18] * BigArray[x - 6, 4], p);
            //    //    BigArray[x, 20] = Ostat.MathOstat(BigArray[x, 18] - BigArray[x, 19], p);
            //    //}
            //    //if (x >= 9)
            //    //{
            //    //    BigArray[x, 21] = Ostat.MathOstat(BigArray[9, 20] * BigArray[x - 7, 4], p);
            //    //    BigArray[x, 22] = Ostat.MathOstat(BigArray[x, 20] - BigArray[x, 21], p);
            //    //}
            //    //if (x >= 10)
            //    //{
            //    //    BigArray[x, 23] = Ostat.MathOstat(BigArray[10, 22] * BigArray[x - 8, 4], p);
            //    //    BigArray[x, 24] = Ostat.MathOstat(BigArray[x, 22] - BigArray[x, 23], p);
            //    //}
            //    //if (x >= 11)
            //    //{
            //    //    BigArray[x, 25] = Ostat.MathOstat(BigArray[11, 24] * BigArray[x - 9, 4], p);
            //    //    BigArray[x, 26] = Ostat.MathOstat(BigArray[x, 24] - BigArray[x, 25], p);
            //    //}
            //    //if (x >= 12)
            //    //{
            //    //    BigArray[x, 27] = Ostat.MathOstat(BigArray[12, 26] * BigArray[x - 10, 4], p);
            //    //    BigArray[x, 28] = Ostat.MathOstat(BigArray[x, 26] - BigArray[x, 27], p);
            //    //}
            //    //if (x >= 13)
            //    //{
            //    //    BigArray[x, 29] = Ostat.MathOstat(BigArray[13, 28] * BigArray[x - 11, 4], p);
            //    //    BigArray[x, 30] = Ostat.MathOstat(BigArray[x, 28] - BigArray[x, 29], p);
            //    //}
            //    //if (x >= 14)
            //    //{
            //    //    BigArray[x, 31] = Ostat.MathOstat(BigArray[14, 30] * BigArray[x - 12, 4], p);
            //    //    BigArray[x, 32] = Ostat.MathOstat(BigArray[x, 30] - BigArray[x, 31], p);
            //    //}
            //    //if (x >= 15)
            //    //{
            //    //    BigArray[x, 33] = Ostat.MathOstat(BigArray[15, 32] * BigArray[x - 13, 4], p);
            //    //    BigArray[x, 34] = Ostat.MathOstat(BigArray[x, 32] - BigArray[x, 33], p);
            //    //}
            //    //if (x >= 16)
            //    //{
            //    //    BigArray[x, 35] = Ostat.MathOstat(BigArray[16, 34] * BigArray[x - 14, 4], p);
            //    //    BigArray[x, 36] = Ostat.MathOstat(BigArray[x, 34] - BigArray[x, 35], p);
            //    //}
            //    //if (x >= 17)
            //    //{
            //    //    BigArray[x, 37] = Ostat.MathOstat(BigArray[17, 36] * BigArray[x - 15, 4], p);
            //    //    BigArray[x, 38] = Ostat.MathOstat(BigArray[x, 36] - BigArray[x, 37], p);
            //    //}
            //    //if (x >= 18)
            //    //{
            //    //    BigArray[x, 39] = Ostat.MathOstat(BigArray[18, 38] * BigArray[x - 16, 4], p);
            //    //    BigArray[x, 40] = Ostat.MathOstat(BigArray[x, 38] - BigArray[x, 39], p);
            //    //}
            //    //if (x >= 19)
            //    //{
            //    //    BigArray[x, 41] = Ostat.MathOstat(BigArray[19, 40] * BigArray[x - 17, 4], p);
            //    //    BigArray[x, 42] = Ostat.MathOstat(BigArray[x, 40] - BigArray[x, 41], p);
            //    //}
            //    //if (x >= 20)
            //    //{
            //    //    BigArray[x, 43] = Ostat.MathOstat(BigArray[20, 42] * BigArray[x - 18, 4], p);
            //    //    BigArray[x, 44] = Ostat.MathOstat(BigArray[x, 42] - BigArray[x, 43], p);
            //    //}
            //    //if (x >= 21)
            //    //{
            //    //    BigArray[x, 45] = Ostat.MathOstat(BigArray[21, 44] * BigArray[x - 19, 4], p);
            //    //    BigArray[x, 46] = Ostat.MathOstat(BigArray[x, 44] - BigArray[x, 45], p);
            //    //}
            //    //if (x >= 22)
            //    //{
            //    //    BigArray[x, 47] = Ostat.MathOstat(BigArray[22, 46] * BigArray[x - 20, 4], p);
            //    //    BigArray[x, 48] = Ostat.MathOstat(BigArray[x, 46] - BigArray[x, 47], p);
            //    //}
            //    //if (x >= 23)
            //    //{
            //    //    BigArray[x, 49] = Ostat.MathOstat(BigArray[23, 48] * BigArray[x - 21, 4], p);
            //    //    BigArray[x, 50] = Ostat.MathOstat(BigArray[x, 48] - BigArray[x, 49], p);
            //    //}
            //    //if (x >= 24)
            //    //{
            //    //    BigArray[x, 51] = Ostat.MathOstat(BigArray[24, 50] * BigArray[x - 22, 4], p);
            //    //    BigArray[x, 52] = Ostat.MathOstat(BigArray[x, 50] - BigArray[x, 51], p);
            //    //}
            //    #endregion
            //}

            //if ((BigArray[MatrixWidth - 4, MatrixHeigth - 1] + BigArray[MatrixWidth - 3, MatrixHeigth - 1] + BigArray[MatrixWidth - 2, MatrixHeigth - 1] + BigArray[MatrixWidth - 1, MatrixHeigth - 1]) > 0)
            //{
            //    TextBoxResult.Text = "Не делится";
            //}
            //else
            //{
            //    TextBoxResult.Text = "Делится";
            //}
            ////Excel.Application ex = new Excel.Application();
            ////////Количество листов в рабочей книге
            //////ex.SheetsInNewWorkbook = 1;
            ////////Добавить рабочую книгу
            ////Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            ////////Отключить отображение окон с сообщениями
            //////ex.DisplayAlerts = false;
            ////////Получаем первый лист документа (счет начинается с 1)
            ////Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            ////////Название листа (вкладки снизу)
            ////sheet.Name = "Расчет полинома";
            ////////Пример заполнения ячеек
            ////sheet.StandardWidth = 3;// ширина ячеек
            ////for (int x = 1; x < MatrixWidth; x++)
            ////{
            ////    for (int y = 1; y < MatrixHeigth; y++)
            ////    {
            ////        sheet.Cells[y, x] = BigArray[x, y];
            ////    }
            ////}
            ////ex.Visible = true;
            #endregion
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)// проверка на цыфры
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Factor_Power_divider_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Factor_divider_TextBox.Text == "" | Power_divider_TextBox.Text == "")
            {
                MessageBox.Show("Введите значения");
            }
            else
            {
                Divider_TextBlock.Text = String.Empty;
                List<string> list = new List<string>();
                Reciprocal_Class reciprocal_Class = new Reciprocal_Class();
                reciprocal_Class.factor = Convert.ToDouble(Factor_divider_TextBox.Text.Trim());
                reciprocal_Class.power = Convert.ToDouble(Power_divider_TextBox.Text.Trim());
                reciprocal_Class.result = reciprocal_Class.ReciprocalBilder(reciprocal_Class.factor, reciprocal_Class.power);
                bool flag = true;
                foreach (Reciprocal_Class _Class in list_Reciprocal_divider_Class)
                {
                    if (reciprocal_Class.power == _Class.power)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list_Reciprocal_divider_Class.Insert(0, reciprocal_Class);
                    list_Reciprocal_divider_Class.Sort((c1, c2) => c2.power.CompareTo(c1.power));
                }
                foreach (Reciprocal_Class _Class in list_Reciprocal_divider_Class)
                {
                    list.Add(_Class.result);
                }
                Divider_TextBlock.Text = String.Join("+", list.ToArray());
            }
            Factor_divider_TextBox.Clear();
            Power_divider_TextBox.Clear();
        }

        private void Rascher_Button_Click(object sender, RoutedEventArgs e)
        {
            double p = Convert.ToDouble(TextBoxPole.Text.Trim());
            p = 11;
            List<double> arraydivider = new List<double>();
            List<double> arraydividend = new List<double>();

            Converter_PolinomClass converter_PolinomClass = new Converter_PolinomClass();

            arraydivider = converter_PolinomClass.Converter(list_Reciprocal_divider_Class);
            arraydividend = converter_PolinomClass.Converter(list_Reciprocal_dividend_Class);
            TextBoxResult.Text = PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked);
        }

        private void Factor_Power_dividend_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Factor_dividend_TextBox.Text == "" | Power_dividend_TextBox.Text == "")
            {
                MessageBox.Show("Введите значения");
            }
            else
            {
                Dividend_TextBlock.Text = String.Empty;
                List<string> list = new List<string>();
                Reciprocal_Class reciprocal_Class = new Reciprocal_Class();
                reciprocal_Class.factor = Convert.ToDouble(Factor_dividend_TextBox.Text.Trim());
                reciprocal_Class.power = Convert.ToDouble(Power_dividend_TextBox.Text.Trim());
                reciprocal_Class.result = reciprocal_Class.ReciprocalBilder(reciprocal_Class.factor, reciprocal_Class.power);
                bool flag = true;
                foreach (Reciprocal_Class _Class in list_Reciprocal_dividend_Class)
                {
                    if (reciprocal_Class.power == _Class.power)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list_Reciprocal_dividend_Class.Insert(0, reciprocal_Class);
                    list_Reciprocal_dividend_Class.Sort((c1, c2) => c2.power.CompareTo(c1.power));
                }
                foreach (Reciprocal_Class _Class in list_Reciprocal_dividend_Class)
                {
                    list.Add(_Class.result);
                }
                Dividend_TextBlock.Text = String.Join("+", list.ToArray());
            }
            Factor_dividend_TextBox.Clear();
            Power_dividend_TextBox.Clear();
        }
    }
}

