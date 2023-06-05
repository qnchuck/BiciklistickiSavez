using BiciklistickiSavez.CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace BiciklistickiSavez.ViewModels
{
    public class NoviBicikliVM
    {
        public ObservableCollection<SystemModels.Models.Bicikli> Bicikli { get; set; }
        public SystemModels.Models.Bicikli Bicikl;

        public NoviBicikliVM()
        {
            Bicikli = new ObservableCollection<SystemModels.Models.Bicikli>(BicikliCRUD.Instance.GetAll());
            AddBicikliCommand = new RelayCommand<object>(AddBicikli);
            this.BiciklAdded += HandleBiciklAdded;
        }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string ZemljaPorekla { get; set; }

        public event EventHandler BiciklAdded;

        public event EventHandler ClosingTakmicari;

        public ICommand WindowClosingCommand { get; }
        public ICommand AddBicikliCommand { get; set; }
        private void AddBicikli(object parameter)
        {
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show("Please fill out required fields");
                return;
            }
            
            Bicikl = new SystemModels.Models.Bicikli  
            {
                Model = Model,
                Proizvodjac = Proizvodjac,
                ZemljaPorekla = ZemljaPorekla
            };
            BicikliCRUD.Instance.Create(Bicikl);
            BiciklAdded?.Invoke(this, EventArgs.Empty);
        }
        private bool AreRequiredFieldsFilled()
        {
            return !string.IsNullOrEmpty(Proizvodjac) && !string.IsNullOrEmpty(ZemljaPorekla) && !string.IsNullOrEmpty(Model);


        }

        private void HandleBiciklAdded(object sender, EventArgs e)
        {
            Bicikli.Add(Bicikl);
        }
    }
}
