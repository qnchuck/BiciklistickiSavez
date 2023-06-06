using BiciklistickiSavez.DBCrud;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciklistickiSavez.ViewModels
{
    public class NoviKlubVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SystemModels.Models.BiciklistickiSavez savez { get; set; }

        public ObservableCollection<SystemModels.Models.BiciklistickiKlub> BiciklistickiKlubovi { get; set; }
         = new ObservableCollection<SystemModels.Models.BiciklistickiKlub>();


        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }
        private string lokacija;
        public string Lokacija
        {
            get { return lokacija; }
            set
            {
                lokacija = value;
                OnPropertyChanged(nameof(Lokacija));
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

        public ICommand AddCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public NoviKlubVM(SystemModels.Models.BiciklistickiSavez savez)
        {

            KlubCrud.Instance.GetKluboviSavez(savez).ForEach(klub => BiciklistickiKlubovi.Add(klub));
            NazivSaveza = savez.Naziv;
            this.savez = savez;
            AddCommand = new RelayCommand(DodajKlub);
            DeleteCommand = new RelayCommand<object>(ObrisiKlub);
            ModifyCommand = new RelayCommand<object>(IzmeniKlub);
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void DodajKlub()
        {
            var klub = new SystemModels.Models.BiciklistickiKlub
            {
                Naziv = Naziv,
                Lokacija = Lokacija,
                NazivSaveza = NazivSaveza
            };

            KlubCrud.Instance.Create(klub);
            this.RefreshTable();
        }

        private void ObrisiKlub(object param)
        {
            if (param is SystemModels.Models.BiciklistickiKlub item)
            {
                KlubCrud.Instance.Delete(item.ID);
                BiciklistickiKlubovi.Remove(item);
            }

        }

        private void IzmeniKlub(object param)
        {
            if (param is SystemModels.Models.BiciklistickiKlub item)
            {
                KlubCrud.Instance.Modify(item);
                this.RefreshTable();
            }
        }

        private void RefreshTable()
        {
            BiciklistickiKlubovi.Clear();
            try
            {
                KlubCrud.Instance.GetKluboviSavez(savez).ForEach(item => BiciklistickiKlubovi.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
