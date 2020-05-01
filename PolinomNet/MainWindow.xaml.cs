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
using System.Text.RegularExpressions;

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
            if (TextBoxPole.Text == "" | TextBoxdivider.Text == "" | TextBoxdividend.Text == "")
            {
                MessageBox.Show("Поле пустое");
            }
            else
            {


                Divider_TextBlock.Text = String.Empty;
                Dividend_TextBlock.Text = String.Empty;



                #region//леваячасть
                if (TextBoxPole.Text == "" | TextBoxdivider.Text == "" | TextBoxdividend.Text == "")
                {
                    MessageBox.Show("Введите значения");
                }

                else
                {
                    double p = Convert.ToDouble(TextBoxPole.Text.Trim());
                    List<double> arraydivider = new List<double>();
                    List<double> arraydividend = new List<double>();
                    string TextBoxdivider_string = TextBoxdivider.Text.Trim();
                    TextBoxdivider_string = Regex.Replace(TextBoxdivider_string, @"\s+", " ");
                    arraydivider = TextBoxdivider_string.Split(' ').Select(i => Convert.ToDouble(i)).ToList();

                    string TextBoxdividend_string = TextBoxdividend.Text.Trim();
                    TextBoxdividend_string = Regex.Replace(TextBoxdividend_string, @"\s+", " ");
                    arraydividend = TextBoxdividend_string.Split(' ').Select(i => Convert.ToDouble(i)).ToList();

                    TextBoxResult.Text = PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked);
                }
                #endregion

                //#region//правая часть
                //double p = Convert.ToDouble(TextBoxPole.Text.Trim());
                ////p = 11;
                //List<double> arraydivider = new List<double>();
                //List<double> arraydividend = new List<double>();

                //Converter_PolinomClass converter_PolinomClass = new Converter_PolinomClass();

                //arraydivider = converter_PolinomClass.Converter(list_Reciprocal_divider_Class);
                //arraydividend = converter_PolinomClass.Converter(list_Reciprocal_dividend_Class);
                //TextBoxResult.Text = PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked);
                //#endregion

            }
        }

        private void Test_Click2(object sender, RoutedEventArgs e)
        {
            if (TextBoxPole2.Text == "")
            {
                MessageBox.Show("Поле пустое");
            }
            else
            {
                #region//правая часть
                double p = Convert.ToDouble(TextBoxPole2.Text.Trim());
                //p = 11;
                List<double> arraydivider = new List<double>();
                List<double> arraydividend = new List<double>();

                Converter_PolinomClass converter_PolinomClass = new Converter_PolinomClass();

                arraydivider = converter_PolinomClass.Converter(list_Reciprocal_divider_Class);
                arraydividend = converter_PolinomClass.Converter(list_Reciprocal_dividend_Class);
                TextBoxResult.Text = PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked);
                #endregion
            }
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)// проверка на цыфры
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void TextBoxPole_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
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


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxdivider.Clear();
            TextBoxdividend.Clear();
            Divider_TextBlock.Text = String.Empty;
            Dividend_TextBlock.Text = String.Empty;
            TextBoxResult.Text = String.Empty;

            list_Reciprocal_divider_Class.Clear();
            list_Reciprocal_dividend_Class.Clear();
        }

        private void Button_Result3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double p = Convert.ToDouble(TextBox_Pole3.Text.Trim());
                List<double> arraydivider = new List<double>();
                List<double> arraydividend = new List<double>();

                string richText = new TextRange(TextBox_divider3.Document.ContentStart, TextBox_divider3.Document.ContentEnd).Text;

                List<string> content = richText.Split('\r').Select(i => Convert.ToString(i)).ToList();

                
                string TextBoxdividend_string = TextBox_dividend3.Text.Trim();
                TextBoxdividend_string = Regex.Replace(TextBoxdividend_string, @"\s+", " ");
                arraydividend = TextBoxdividend_string.Split(' ').Select(i => Convert.ToDouble(i)).ToList();

                FlowDocument flowDocumentRich = new FlowDocument();

                flowDocumentRich = TextBox_divider3.Document;
                flowDocumentRich.UpdateDefaultStyle();
                Paragraph paragraphRich = new Paragraph();
                
                

                FlowDocument flowDocument = new FlowDocument();
                Paragraph paragraph = new Paragraph();
                paragraph.LineHeight = 18;

                for (int i = 0; i < content.Count - 1; i++)
                {
                    content[i] = content[i].Trim();
                    content[i] = Regex.Replace(content[i], @"\s+", " ");
                    arraydivider = content[i].Split(' ').Select(ii => Convert.ToDouble(ii)).ToList();
                    paragraph.Inlines.Add(new Bold(new Run(PolinomBool.PolinomResulter(arraydivider, arraydividend, p, CheckBox_EXCEL.IsChecked) + '\r')));

                    flowDocument.Blocks.Add(paragraph);
                }
                flowDocument.LineHeight = flowDocumentRich.LineHeight;
                TextBox_Result3.Document = flowDocument;

                TextBox_divider3.Document = flowDocumentRich;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


