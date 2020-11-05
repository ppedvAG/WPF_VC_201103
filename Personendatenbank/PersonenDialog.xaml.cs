﻿using System;
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

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public Person NeuePerson { get; set; }

        public PersonenDialog()
        {
            InitializeComponent();

            this.NeuePerson = new Person();

            this.DataContext = NeuePerson;
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            string ausgabe = NeuePerson.Vorname + " " + NeuePerson.Nachname + " (" + NeuePerson.Geschlecht + ")\n" + NeuePerson.Geburtsdatum.ToShortDateString() + "\n" + NeuePerson.Lieblingsfarbe.ToString();
            ausgabe += NeuePerson.Verheiratet ? "\nIst Verheiratet" : "";
            if (MessageBox.Show(ausgabe + "\nÜbernehmen?", "Neue Person", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.DialogResult = true;

                this.Close();
            }
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
