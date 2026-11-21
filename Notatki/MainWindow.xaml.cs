using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Linq;

namespace Notatki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> lista = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Pliki XML (*.xml)|*.xml";

                if (openFileDialog.ShowDialog() == true)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        XDocument xml = XDocument.Load(openFileDialog.FileName);

                        lista.Clear();

                        foreach (XElement notatka in xml.Root.Elements("Notatka"))
                        {
                            lista.Add(notatka.Value);
                        }

                        MessageBox.Show("Notatki zostały wczytane");
                    }
                }


            listBox.ItemsSource = lista;
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2(lista);
            win2.ShowDialog();

            listBox.Items.Refresh();
        }
        private void SaveNotes(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Pliki XML (*.xml)|*.xml";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                XDocument xml = new XDocument(
                    new XElement("Notatki",
                        lista.Select(n => new XElement("Notatka", n))
                    )
                );

                xml.Save(saveFileDialog1.FileName);

                MessageBox.Show("Notatki zostały zapisane");
            }
        }
    }
}
