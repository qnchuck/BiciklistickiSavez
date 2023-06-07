using BiciklistickiSavez.ViewModels;
using System;
using System.Text.RegularExpressions;
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

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
