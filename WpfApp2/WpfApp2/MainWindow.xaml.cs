using System;
using System.Collections.Generic;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int result = 0;
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string text1 = Num1TextBox.Text.Trim();
            string text2 = Num2TextBox.Text.Trim();

            int num1 = 0;
            int num2 = 0;

            if (!string.IsNullOrEmpty(text1) && !string.IsNullOrEmpty(text2))
            {
                try
                {
                    num1 = Convert.ToInt32(text1);
                    num2 = Convert.ToInt32(text2);
                }
                catch (Exception exc) { }

                Calculate(num1, num2); //Передача данных модели
            }
        }
        public void Calculate(int num1, int num2)
        {
            result = num1 + num2; //Проведение операций с полученными данными

            UpdateView(); //Вызов обновления представления
        }
        public void UpdateView()
        {
            ResultTextBlock.Text = result.ToString(); //Изменение вида
        }
    }
}
