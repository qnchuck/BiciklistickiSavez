using BiciklistickiSavez.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BiciklistickiSavez.Views
{
    /// <summary>
    /// Interaction logic for BicikliPregled.xaml
    /// </summary>
    public partial class BicikliPregled : Window
    {
        BicikliPregledVM viewModel;
        public event EventHandler ClosingEvents;

        public BicikliPregled(BicikliPregledVM bicikliPregledVM)
        {
            InitializeComponent();
            this.viewModel = bicikliPregledVM;
            DataContext = bicikliPregledVM;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClosingEvents?.Invoke(this, EventArgs.Empty);
        }
    }
}
