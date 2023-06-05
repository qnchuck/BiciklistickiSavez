using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using BiciklistickiSavez.Database;
using BiciklistickiSavez.Views;
using GalaSoft.MvvmLight.Command;
using BiciklistickiSavez.CRUD;
using SystemModels.Models;

namespace BiciklistickiSavez.ViewModels
{
    public class NoviBiciklistickiSavezVM
    {
        public NoviBiciklistickiSavezVM()
        {

            AddSavezCommand = new RelayCommand<object>(AddSavez);
            CancelCommand = new RelayCommand(Cancel);
        }
        public string Naziv { get; set; }
        public string Drzava{ get; set; }
        
        DBModels dBModels = DBModels.Instance;
        DBConversion dBConversion = new DBConversion();

        public event EventHandler SavezAdded; 
        public ICommand AddSavezCommand { get; set; }
        private ICommand CancelCommand { get; set; }

       

        private void AddSavez(object parameter)
        {
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show("Please fill out required fields");
                return;
            }
            if(dBModels.Biciklisticki_Savez.Where(bs => bs.NZV == Naziv).FirstOrDefault() != null)
            {
                MessageBox.Show("Postoji savez sa tim nazivom");
                return;
            }
            SystemModels.Models.BiciklistickiSavez savez = new SystemModels.Models.BiciklistickiSavez
            {
                Naziv = Naziv,
                Drzava = Drzava
            };
            BiciklistickiSavezCRUD.Instance.Create(savez);
                
         

            CloseForm();
            SavezAdded?.Invoke(this, EventArgs.Empty);

        }
        private bool AreRequiredFieldsFilled()
        {
            return  !string.IsNullOrEmpty(Naziv) &&
                !string.IsNullOrEmpty(Drzava) ;
        }
        private void Cancel()
        {
            CloseForm();
        }

        private void CloseForm()
        {
            var window = App.Current.Windows.OfType<NoviBiciklistickiSavez>().FirstOrDefault();
            window?.Close();
        }
    }
}
