using BiciklistickiSavez.CRUD;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciklistickiSavez.ViewModels
{
    public class BicikliPregledVM
    {
        public ObservableCollection<SystemModels.Models.Bicikli> OwnedBicycles { get; set; } = new ObservableCollection<SystemModels.Models.Bicikli>();
        public ObservableCollection<SystemModels.Models.Bicikli> NotOwnedBicycles { get; set; } = new ObservableCollection<SystemModels.Models.Bicikli>();
        public string JMBG { get; set; }
        public ICommand KupiBicikloCommand { get; set; }
        public ICommand ProdajBicikloCommand { get; set; }
        public ICommand UpdateBicikloCommand { get; set; }
        public ICommand RemoveBicikloCommand { get; set; }
        public BicikliPregledVM(List<SystemModels.Models.Bicikli> biciklis, string jmbg)
        {
            JMBG = jmbg;
            biciklis.ForEach(b => OwnedBicycles.Add(b));
            BicikliCRUD.Instance.GetAll().Where(bic=>bic.JmbgT==null).ToList().ForEach(b => NotOwnedBicycles.Add(b));
            KupiBicikloCommand = new RelayCommand<object>(KupiBicikloRow);
            ProdajBicikloCommand = new RelayCommand<object>(ProdajBicikloRow);
            UpdateBicikloCommand = new RelayCommand<object>(UpdateBicikloRow);
            RemoveBicikloCommand = new RelayCommand<object>(RemoveBicikloRow);
        }
        private void KupiBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikli = parameter as SystemModels.Models.Bicikli;
            if (bicikli != null)
            {
                bicikli.JmbgT = JMBG;
                BicikliCRUD.Instance.Modify(bicikli);
            }
            RefreshBicikli();
        }
        private void ProdajBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikli = parameter as SystemModels.Models.Bicikli;
            if (bicikli != null)
            {
                bicikli.JmbgT = null;
                BicikliCRUD.Instance.Modify(bicikli);
            }
            RefreshBicikli();
        }
        private void RemoveBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikli = parameter as SystemModels.Models.Bicikli;
            if (bicikli != null)
            {
                
                BicikliCRUD.Instance.Delete(bicikli.ID);
            }
            RefreshBicikli();
        }

        public void RefreshBicikli()
        {
            OwnedBicycles.Clear();
            NotOwnedBicycles.Clear();

            BicikliCRUD.Instance.GetAll().Where(b => b.JmbgT == JMBG).ToList().ForEach(bic => OwnedBicycles.Add(bic));
            BicikliCRUD.Instance.GetAll().Where(b => b.JmbgT == null).ToList().ForEach(bic => NotOwnedBicycles.Add(bic));
        }
        private void UpdateBicikloRow(object parameter)
        {
            SystemModels.Models.Bicikli bicikl = parameter as SystemModels.Models.Bicikli;
            if (bicikl != null)
            {
                BicikliCRUD.Instance.Modify(bicikl);
            }
        }
    }
}
