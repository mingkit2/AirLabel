using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using AirLabel.View;


namespace AirLabel.ViewModel
{
    class PrintLabelViewModel : ObservableObject
    {

        public IRelayCommand PreviewCommand { get; }
        public string AirWayBillNo { get; set; }

        
        private MainWindowViewModel _parentWindow;
        private ReportViewer _reportviewer;

        //private ReportViewer _reportviewer;

        public PrintLabelViewModel(MainWindowViewModel parentWindow)
        {
            _parentWindow = parentWindow;
            //this._reportviewer = window._reportviewer;
            PreviewCommand = new RelayCommand(PreviewLabel);
        }

        private void PreviewLabel()
        {

            //_reportviewer.LocalReport.DataSources.Clear();

            //var rpds_model1 = new ReportDataSource() { Name = "dsShopReport", Value = dataShopReport };

            //_reportviewer.LocalReport.DataSources.Add(rpds_model1);

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("pAirWayBillNo", AirWayBillNo);

            _reportviewer.LocalReport.EnableExternalImages = true;

            //string _path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            //string ContentStart = _path + @"\MVVMNvocc\Reports\DeliveryOrder.rdlc";

            string ReportName = "AirLabel";
            //string ReportName = "DeliveryReceipt";
            _reportviewer.LocalReport.ReportPath = string.Format("Report/{0}.rdlc", ReportName);


            //_reportviewer.LocalReport.ReportPath = ContentStart;

            //string ReportName = "ShippingOrder";
            //_reportviewer.LocalReport.ReportPath = string.Format("Reports/{0}.rdlc", ReportName); ;

            _reportviewer.SetDisplayMode(DisplayMode.PrintLayout);
            _reportviewer.LocalReport.SetParameters(parameters);
            _reportviewer.Refresh();
            _reportviewer.RefreshReport();
        }
    }

}
    

