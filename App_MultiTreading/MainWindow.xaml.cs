using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace App_MultiTreading
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

        

        private void NewMethod()
        {
            // DoWork();
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i <= 100000; i++)
            {
                for (int j = 0; j <= 100000; j++)
                {

                }
            }
            Dispatcher.Invoke(AggiornamentoInterfaccia);

        }

        private void AggiornamentoInterfaccia()
        {
            Lbl_risultato.Content = "finito";
        }

        private void Btn_conta_Click(object sender, RoutedEventArgs e)
        {
            
            Task.Factory.StartNew(DoCount);
        }

        private void DoCount()
        {
            for (int i = 0; i <= 100000; i++)
            {
                for (int j = 0; j <= 100000; j++)
                {
                    Dispatcher.Invoke(()=>AggiornamentoInterfaccia(j));
                    Thread.Sleep(1000);
                }
            }
        }
        private void AggiornamentoInterfaccia(int j)
        {
            Lbl_conta.Content = j.ToString();
        }
    }
}
