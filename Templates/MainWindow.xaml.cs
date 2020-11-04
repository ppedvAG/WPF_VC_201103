using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Person> Personenliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Rainer", Nachname="Zufall", Alter=45},
                new Person(){Vorname="Anna", Nachname="Nass", Alter=23},
            };

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Klick funktioniert");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (Spl_DataBinding.DataContext as Person).Alter++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Vorname = "Hannes", Nachname = "Schmidt", Alter = 101 });
        }
    }
}
