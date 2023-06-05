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
    /// Interaction logic for NoviBicikli.xaml
    /// </summary>
    public partial class NoviBicikli : Window
    {
        NoviBicikliVM viewModel;
        public event EventHandler ClosingEvents;

        public NoviBicikli(NoviBicikliVM bicikliVM)
        {
            InitializeComponent();
            this.viewModel = bicikliVM;
            DataContext = bicikliVM;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClosingEvents?.Invoke(this, EventArgs.Empty);
        }
    }
}
