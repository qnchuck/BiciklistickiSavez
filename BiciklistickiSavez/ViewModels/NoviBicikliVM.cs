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

        public ICommand UpdateBicikloCommand { get; set; }
        public ICommand RemoveBicikloCommand { get; set; }
        public NoviBicikliVM()
        {
            Bicikli = new ObservableCollection<SystemModels.Models.Bicikli>(BicikliCRUD.Instance.GetAll());
            AddBicikliCommand = new RelayCommand<object>(AddBicikli);
            UpdateBicikloCommand = new RelayCommand<object>(UpdateBicikloRow);
            RemoveBicikloCommand = new RelayCommand<object>(RemoveBicikloRow);
            this.BiciklAdded += HandleBiciklAdded;
        }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string ZemljaPorekla { get; set; }

        public event EventHandler BiciklAdded;

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
        private void RemoveBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikli = parameter as SystemModels.Models.Bicikli;
            if (bicikli != null)
            {
                BicikliCRUD.Instance.Delete(bicikli.ID);
            }
            Bicikli.Clear();
            BicikliCRUD.Instance.GetAll().ToList().ForEach(bic => Bicikli.Add(bic));
        }

        private void UpdateBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikl = parameter as SystemModels.Models.Bicikli;
            if (bicikl != null)
            {
                BicikliCRUD.Instance.Modify(bicikl);
            }
        }
        private void HandleBiciklAdded(object sender, EventArgs e)
        {
            Bicikli.Add(Bicikl);
        }
    }
}
