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
    /// Interaction logic for NoviBiciklistickiSavez.xaml
    /// </summary>
    public partial class NoviBiciklistickiSavez : Window
    {
        private NoviBiciklistickiSavezVM vm;
        public NoviBiciklistickiSavez(NoviBiciklistickiSavezVM noviBiciklistickiSavezVM)
        {
                InitializeComponent();
                this.vm = noviBiciklistickiSavezVM;
                DataContext = noviBiciklistickiSavezVM;
            
        }
        private void CloseForm()
        {
            Close();
        }
    }
}
