using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for Db_Ansicht.xaml
    /// </summary>
    public partial class Db_Ansicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; }

        public Db_Ansicht()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Anna", Nachname="Nass", Geburtsdatum=new DateTime(1999,5,23), Geschlecht=Gender.Weiblich, Verheiratet=true, Lieblingsfarbe=Colors.CornflowerBlue}
            };

            this.DataContext = this;
        }

        private void Mei_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            PersonenDialog dialog = new PersonenDialog();

            if(dialog.ShowDialog() == true)
            {
                Personenliste.Add(dialog.NeuePerson);
            }
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            if (Dgd_Personen.SelectedItem is Person)
            {
                PersonenDialog dialog = new PersonenDialog();

                dialog.NeuePerson = new Person(Dgd_Personen.SelectedItem as Person);
                dialog.DataContext = dialog.NeuePerson;

                dialog.Title = dialog.NeuePerson.Vorname + " " + dialog.NeuePerson.Nachname;

                if (dialog.ShowDialog() == true)
                    Personenliste[Dgd_Personen.SelectedIndex] = dialog.NeuePerson;
            }
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Soll diese Person wirklich gelöscht werden?", "Person löschen?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Personenliste.Remove(Dgd_Personen.SelectedItem as Person);
        }
    }
}
