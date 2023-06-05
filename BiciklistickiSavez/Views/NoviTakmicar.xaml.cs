using BiciklistickiSavez.ViewModels;
using System;
using System.Windows;

namespace BiciklistickiSavez.Views
{
    /// <summary>
    /// Interaction logic for NoviTakmicar.xaml
    /// </summary>
    public partial class NoviTakmicar : Window
    {
        NoviTakmicarVM viewModel; 
        public event EventHandler ClosingEvents;

        public NoviTakmicar(NoviTakmicarVM takmicariVM)
        {
            InitializeComponent();
            this.viewModel = takmicariVM;
            DataContext = takmicariVM;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ClosingEvents?.Invoke(this, EventArgs.Empty);
        }
    }
}
