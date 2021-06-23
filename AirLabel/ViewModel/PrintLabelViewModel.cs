using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace AirLabel.ViewModel
{
    class PrintLabelViewModel: ObservableObject
    {

        MainWindowViewModel _parentWindow;

        public PrintLabelViewModel(MainWindowViewModel parentWindow)
        {
            _parentWindow = parentWindow;
           
        }


    }
}
