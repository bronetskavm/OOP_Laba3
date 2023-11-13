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

namespace OOP_Lab3_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (int.TryParse(txtN.Text, out n))
            {
                double[] array = new double[n];
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                {
                    double randomNumber = (rnd.NextDouble() * 11) - 7.51; // Генерувати числа в інтервалі [-7.51, 3.49]
                    array[i] = Math.Round(randomNumber, 2); // Заокруглення до 2 знаків після коми
                }

                // Знайти суму модулів елементів, які мають дробову частину меншу за 0.5
                double sumOfModulus = 0;
                foreach (double element in array)
                {
                    if (Math.Abs(element % 1) < 0.5)
                    {
                        sumOfModulus += Math.Abs(element);
                    }
                }

                txtResult1.Text = string.Join(" ", array);
                txtResult2.Text = sumOfModulus.ToString();
            }
            else
            {
                MessageBox.Show("Введіть коректне число для кількості елементів масиву.");
            }
        }
    }
}