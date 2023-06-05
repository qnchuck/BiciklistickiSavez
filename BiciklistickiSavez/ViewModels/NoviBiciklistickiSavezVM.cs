using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using BiciklistickiSavez.Database;
using BiciklistickiSavez.Views;

namespace BiciklistickiSavez.ViewModels
{
    public class NoviBiciklistickiSavezVM
    {
        public NoviBiciklistickiSavezVM()
        {

        }
        public string Naziv { get; set; }
        public string Drzava{ get; set; }
        
        DBModels dBModels = DBModels.Instance;
        DBConversion dBConversion = new DBConversion();

        public event EventHandler SavezAdded;
        private ICommand addSavezCommand;
        private ICommand cancelCommand;

        public ICommand AddSavezCommand
        {
            get
            {
                if (addSavezCommand == null)
                {
                    addSavezCommand = new RelayCommand(AddSavez);
                }
                return addSavezCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(Cancel);
                }
                return cancelCommand;
            }
        }

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
            dBModels.Biciklisticki_Savez.Add(
                new Biciklisticki_Savez
                {
                    NZV = Naziv,
                    DRZ = Drzava
                });
            dBModels.SaveChanges();
                
         

            CloseForm();
            SavezAdded?.Invoke(this, EventArgs.Empty);

        }
        private bool AreRequiredFieldsFilled()
        {
            return  !string.IsNullOrEmpty(Naziv) &&
                !string.IsNullOrEmpty(Drzava) ;
        }
        private void Cancel(object parameter)
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
