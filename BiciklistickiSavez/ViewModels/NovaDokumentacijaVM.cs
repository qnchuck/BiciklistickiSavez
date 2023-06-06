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
    public class NovaDokumentacijaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SystemModels.Models.BiciklistickiSavez savez { get; set; }
        public ObservableCollection<SystemModels.Models.Dokumentacija> Dokumentacije { get; set; }
         = new ObservableCollection<SystemModels.Models.Dokumentacija>();

        private string tekst;
        public string Tekst
        {
            get { return tekst; }
            set
            {
                tekst = value;
                OnPropertyChanged(nameof(Tekst));
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

        public NovaDokumentacijaVM(SystemModels.Models.BiciklistickiSavez savez)
        {

            DokumentacijaCrud.Instance.GetSavezDokumentacije(savez).ForEach(d => Dokumentacije.Add(d));
            NazivSaveza = savez.Naziv;
            this.savez = savez;
            AddCommand = new RelayCommand(DodajDokumentaciju);
            DeleteCommand = new RelayCommand<object>(ObrisiDokumentaciju);
            ModifyCommand = new RelayCommand<object>(IzmeniDokumentaciju);


        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DodajDokumentaciju()
        {
            var dokumentacija = new SystemModels.Models.Dokumentacija
            {
                Tekst = Tekst,
                NazivSaveza = NazivSaveza
            };

            DokumentacijaCrud.Instance.Create(dokumentacija);
            this.RefreshTable();
        }

        private void ObrisiDokumentaciju(object param)
        {
            if (param is SystemModels.Models.Dokumentacija item)
            {
                DokumentacijaCrud.Instance.Delete(item.ID);
                Dokumentacije.Remove(item);
            }

        }

        private void IzmeniDokumentaciju(object param)
        {
            if (param is SystemModels.Models.Dokumentacija item)
            {
                DokumentacijaCrud.Instance.Modify(item);
                this.RefreshTable();
            }
        }

        private void RefreshTable()
        {
            Dokumentacije.Clear();
            try
            {
                DokumentacijaCrud.Instance.GetSavezDokumentacije(savez).ForEach(d => Dokumentacije.Add(d));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
