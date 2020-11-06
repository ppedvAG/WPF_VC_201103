using MVVM_Personendatenbank.Model;
using MVVM_Personendatenbank.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace MVVM_Personendatenbank.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        //Es gibt in Core (und nach meinen Recherchen anscheinend auch schon länger im 'normalen' Framework, leider keinen Weg
        //mehr, auf einfache Art und Weise hier eine Referenz auf das View zu übergeben. 
        //Dies würde auch MVVM wiedersprechen ;-)
        //public DetailView ContextView { get; set; }

        //Command-Properties
        public CustomCommand OkCmd { get; set; }
        public CustomCommand AbbruchCmd { get; set; }

        //Property, welche die neue oder zu bearbeitende Person beinhaltet
        private Person neuePerson;
        public Person NeuePerson 
        {
            get { return neuePerson; }
            set
            {
                neuePerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuePerson)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DetailViewModel()
        {
            NeuePerson = new Person();

            //OK-Command (Bestätigung)
            OkCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden. Eine Prüfung auf die Validierung der einzelnen Eingabefelder findet schon in der GUI (vgl. DetailView) statt.
                    p => true,
                    //Exe:
                    p => 
                    {
                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        string ausgabe = NeuePerson.Vorname + " " + NeuePerson.Nachname + " (" + NeuePerson.Geschlecht + ")\n" + NeuePerson.Geburtsdatum.ToShortDateString() + "\n" + NeuePerson.Lieblingsfarbe.ToString();
                        ausgabe += NeuePerson.Verheiratet ? "\nIst Verheiratet" : "";
                        if (MessageBox.Show(ausgabe + "\nÜbernehmen?", "Neue Person", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das LIstView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (p as Window).DialogResult = true;
                            //Schließen des Views
                            (p as Window).Close();
                        }
                    }
                );

            //Abbruch-Cmd
            AbbruchCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen des Fensters
                    p => (p as Window).Close()
                );
        }
    }
}
