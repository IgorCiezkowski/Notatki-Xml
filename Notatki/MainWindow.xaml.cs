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

namespace Notatki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] lista = { };
        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = lista;

        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2(lista);
            win2.ShowDialog();
            ListBox.ItemsSource = lista;

        }
    }
}
