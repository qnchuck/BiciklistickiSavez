using BiciklistickiSavez.CRUD;
using BiciklistickiSavez.Database;
using BiciklistickiSavez.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
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

        public ICommand AddNoviSavezCommand { get; set; }
        public ICommand PregledajTakmicareCommand { get; set; }
        public ICommand AddBicikliCommand { get; set; }
        public ICommand PregledajKluboveCommand { get; set; }
        public ICommand PregledajDokumentacijeCommand { get; set; }
        public ICommand UpdateSavezCommand { get; set; }
        public ICommand PregledajRadnikeCommand { get; set; }

        public MainViewVM()
        {
            LoadData(); 
            AddNoviSavezCommand  = new RelayCommand(OpenNoviSavezForm);
            PregledajTakmicareCommand = new RelayCommand<object>(Pregledaj);
            AddBicikliCommand = new RelayCommand(DodajBicikli); 
            PregledajKluboveCommand = new RelayCommand<object>(InfoKlubovi);
            PregledajDokumentacijeCommand = new RelayCommand<object>(InfoDokumentacije);
            UpdateSavezCommand = new RelayCommand<object>(UpdateSavezRow);
            PregledajRadnikeCommand = new RelayCommand<object>(InfoRadnici);
        }
        private void InfoRadnici(object param)
        {
            if (param is SystemModels.Models.BiciklistickiSavez item)
            {
                var noviRadnikVM = new NoviRadnikVM(item);
                var secondWindow = new NoviRadnik() { DataContext = noviRadnikVM };
                secondWindow.Closed += SecondWindowClosed;
                secondWindow.Show();
            }
        }

        public void OpenNoviSavezForm()
        {
            NoviBiciklistickiSavezVM noviBiciklistickiSavezVM= new NoviBiciklistickiSavezVM();
            noviBiciklistickiSavezVM.SavezAdded += OsveziTabelu;
            NoviBiciklistickiSavez noviBiciklistickiSavez= new NoviBiciklistickiSavez(noviBiciklistickiSavezVM);
            noviBiciklistickiSavez.ShowDialog();
        } 
        public void DodajBicikli()
         {
            NoviBicikliVM noviBicikliVM= new NoviBicikliVM();
            noviBicikliVM.BiciklAdded += OsveziTabelu;
            NoviBicikli noviBicikli= new NoviBicikli(noviBicikliVM);
            noviBicikli.ShowDialog();
        }
        public  void LoadData()
        {
            BiciklistickiSavezi.Clear();
            BiciklistickiSavezCRUD.Instance.GetAll().ForEach(bs => BiciklistickiSavezi.Add((bs)));
        }
        private void OsveziTabelu(object sender, EventArgs e)
        {
            LoadData();
        }
        private void UpdateSavezRow(object parameter)
        {
            SystemModels.Models.BiciklistickiSavez savez = parameter as SystemModels.Models.BiciklistickiSavez;
            if (savez != null)
            {

                BiciklistickiSavezCRUD.Instance.Modify(savez);
            }
            LoadData();
        }

        private void Pregledaj(object parameter)
        {
            SystemModels.Models.BiciklistickiSavez savez = (SystemModels.Models.BiciklistickiSavez)parameter;
            if (savez != null)
            {
                NoviTakmicarVM takmicarVM= new NoviTakmicarVM(savez.Takmicari, savez.Naziv);
                NoviTakmicar takmicariWindow = new NoviTakmicar(takmicarVM);
                takmicariWindow.ClosingEvents += OsveziTabelu;
                takmicariWindow.ShowDialog();
            }
        }
        private void InfoKlubovi(object param)
        {
            if (param is SystemModels.Models.BiciklistickiSavez item)
            {
                var noviKlubVM = new NoviKlubVM(item);
                var secondWindow = new NoviKlub() { DataContext = noviKlubVM };
                secondWindow.Closed += SecondWindowClosed;
                secondWindow.Show();
            }
        }

        private void InfoDokumentacije(object param)
        {
            if (param is SystemModels.Models.BiciklistickiSavez item)
            {
                var novaDokumentacijaVM = new NovaDokumentacijaVM(item);
                var secondWindow = new NovaDokumentacija() { DataContext = novaDokumentacijaVM };
                secondWindow.Closed += SecondWindowClosed;
                secondWindow.Show();
            }

        }


        private void SecondWindowClosed(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
