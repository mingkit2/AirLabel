using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using AirLabel.View;


namespace AirLabel.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {               
        public IRelayCommand LoadPrintLabelCommand { get; }

        private string _windowsTitle;
        public string WindowsTitle
        {
            get
            {
                return _windowsTitle;
            }
            set
            {
                _windowsTitle = value;
                OnPropertyChanged("WindowsTitle");
            }
        }

        private ObservableObject _currentViewModel;

        public MainWindowViewModel()
        {
            LoadPrintLabelCommand = new RelayCommand(LoadPrintLabel);
        }
        public ObservableObject CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

 

        private void LoadPrintLabel()
        {
            WindowsTitle = "Print Label";
            CurrentViewModel = new PrintLabelViewModel(this);
        }


    }
}
