using BiciklistickiSavez.CRUD;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BiciklistickiSavez.ViewModels
{
    public class NoviRadnikVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> TipoviZanimanja { get; set; }
        public ObservableCollection<string> Polovi { get; set; }
        private SystemModels.Models.BiciklistickiSavez savez { get; set; }
        public ObservableCollection<SystemModels.Models.Radnik> Radnici { get; set; }
         = new ObservableCollection<SystemModels.Models.Radnik>();


        private string jmbg;
        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged(nameof(Jmbg));
            }
        }
        private string pol;
        public string Pol
        {
            get { return pol; }
            set
            {
                pol = value;
                OnPropertyChanged(nameof(Pol));
            }
        }

        private string ime;
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }


        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }

        private string zanimanje;
        public string Zanimanje
        {
            get { return zanimanje; }
            set
            {
                zanimanje = value;
                OnPropertyChanged(nameof(Zanimanje));
            }
        }


        private string nazivSaveza;
        public string NazivSaveza
        {
            get { return nazivSaveza; }
            set
            {
                nazivSaveza = value;
                OnPropertyChanged(nameof(NazivSaveza));
            }
        }

        private string selectedItemZanimanje;
        public string SelectedItemZanimanje
        {
            get { return selectedItemZanimanje; }
            set
            {
                selectedItemZanimanje = value;
                OnPropertyChanged(nameof(SelectedItemZanimanje));
            }
        }

        private string selectedItemPolovi;
        public string SelectedItemPolovi
        {
            get { return selectedItemPolovi; }
            set
            {
                selectedItemPolovi = value;
                OnPropertyChanged(nameof(SelectedItemPolovi));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public NoviRadnikVM(SystemModels.Models.BiciklistickiSavez savez)
        {
            this.savez = new SystemModels.Models.BiciklistickiSavez();
            RadnikCrud.Instance.GetSavezRadnici(savez).ForEach(r => Radnici.Add(r));
            this.savez = savez;
            NazivSaveza = savez.Naziv;
            TipoviZanimanja = new ObservableCollection<string> { "Sudija", "Delegat", "Organizator"};
            Polovi = new ObservableCollection<string> { "M", "Z"};

            AddCommand = new RelayCommand(DodajRadnika);
            DeleteCommand = new RelayCommand<object>(ObrisiRadnika);
            ModifyCommand = new RelayCommand<object>(IzmeniRadnika);


        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void DodajRadnika()
        {
            if (Jmbg.Length != 13)
            {
                MessageBox.Show("JMBG se sastoji od 13 cifara");
                return;
            }
            var radnik = new SystemModels.Models.Radnik
            {
                Ime = Ime,
                Prezime = Prezime,
                Pol = SelectedItemPolovi,
                JMBG = Jmbg,
                NazivSaveza = NazivSaveza,
                TipZanimanja = (SystemModels.Models.TipZanimanja)Enum.Parse(typeof(SystemModels.Models.TipZanimanja), SelectedItemZanimanje)
            };

            RadnikCrud.Instance.Create(radnik);
            this.RefreshTable();
        }

        private void ObrisiRadnika(object param)
        {
            if (param is SystemModels.Models.Radnik item)
            {
                RadnikCrud.Instance.DeleteRadnik(item.JMBG);
                Radnici.Remove(item);
            }

        }

        private void IzmeniRadnika(object param)
        {
            if (param is SystemModels.Models.Radnik item)
            {
                RadnikCrud.Instance.Modify(item);
                this.RefreshTable();
            }
        }

        private void RefreshTable()
        {
            Radnici.Clear();
            try
            {
                RadnikCrud.Instance.GetSavezRadnici(this.savez).ForEach(item => Radnici.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
