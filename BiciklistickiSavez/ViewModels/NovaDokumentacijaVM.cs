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

        private readonly DBCrud.DokumentacijaCrud crud;
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
            this.crud = new DokumentacijaCrud();

            this.crud.GetAll().ForEach(d => Dokumentacije.Add(d));
            NazivSaveza = savez.Naziv;

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

            this.crud.Create(dokumentacija);
            this.RefreshTable();
        }

        private void ObrisiDokumentaciju(object param)
        {
            if (param is SystemModels.Models.Dokumentacija item)
            {
                this.crud.Delete(item.ID);
                Dokumentacije.Remove(item);
            }

        }

        private void IzmeniDokumentaciju(object param)
        {
            if (param is SystemModels.Models.Dokumentacija item)
            {
                this.crud.Modify(item);
                this.RefreshTable();
            }
        }

        private void RefreshTable()
        {
            Dokumentacije.Clear();
            try
            {
                this.crud.GetAll().ForEach(item => Dokumentacije.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
