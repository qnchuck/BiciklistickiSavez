using BiciklistickiSavez.Database;
using BiciklistickiSavez.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiciklistickiSavez.ViewModels
{
    public class MainViewVM
    {

        public ObservableCollection<SystemModels.Models.BiciklistickiSavez> BiciklistickiSavezi { get; set; } = new ObservableCollection<SystemModels.Models.BiciklistickiSavez>();
        DBModels dBModels = DBModels.Instance;

        private ICommand addNoviSavezCommand;
        DBConversion dBConversion = new DBConversion();

        public MainViewVM()
        {
            LoadData();
        }
        public ICommand AddNoviSavezCommand
        {
            get
            {
                if (addNoviSavezCommand == null)
                {
                    addNoviSavezCommand = new RelayCommand(param => OpenNoviSavezForm());
                }
                return addNoviSavezCommand;
            }
        }
        private void OpenNoviSavezForm()
        {
            NoviBiciklistickiSavezVM noviBiciklistickiSavezVM= new NoviBiciklistickiSavezVM();
            noviBiciklistickiSavezVM.SavezAdded += OsveziTabelu;
            NoviBiciklistickiSavez noviBiciklistickiSavez= new NoviBiciklistickiSavez(noviBiciklistickiSavezVM);
            noviBiciklistickiSavez.ShowDialog();
        }
        private void LoadData()
        {
            BiciklistickiSavezi.Clear();
            dBModels.Biciklisticki_Savez.ToList().ForEach(bs => BiciklistickiSavezi.Add(dBConversion.ConvertBiciklistickiSavez(bs)));
        }
        private void OsveziTabelu(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
