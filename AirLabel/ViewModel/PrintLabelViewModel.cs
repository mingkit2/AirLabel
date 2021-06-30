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
using ZXing; // for BarcodeWriter
using System.Windows.Forms.Integration;
using System.IO;
using System.Drawing.Imaging;
using ZXing.OneD;

namespace AirLabel.ViewModel
{
    class PrintLabelViewModel : ObservableObject
    {

        public IRelayCommand PreviewCommand { get; }
        public string AirWayBillNo { get; set; }

        
        private MainWindowViewModel _parentWindow;
        public ReportViewer reportViewer;
        public WindowsFormsHost Viewer { get; set; }

        //private ReportViewer _reportviewer;

        public PrintLabelViewModel(MainWindowViewModel parentWindow)
        {
            _parentWindow = parentWindow;
            WindowsFormsHost windowsFormsHost = new WindowsFormsHost();
            reportViewer = new ReportViewer();
            windowsFormsHost.Height = 800;
            windowsFormsHost.Width = 1000;
            windowsFormsHost.Child = reportViewer;
            this.Viewer = windowsFormsHost;
            //this._reportviewer = window._reportviewer;
            PreviewCommand = new RelayCommand(PreviewLabel);
            OnPropertyChanged("Viewer");

        }

        private void PreviewLabel()
        {
            
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("pAirWayBillNo", AirWayBillNo);
            parameters[1] = new ReportParameter("pAirWayBillNoBarcode", ImageToBase64(AirWayBillNo));
            reportViewer.LocalReport.EnableExternalImages = true;

            string ReportName = "AirLabel";
            reportViewer.LocalReport.ReportPath = string.Format("Report/{0}.rdlc", ReportName);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.Refresh();
            reportViewer.RefreshReport();
            OnPropertyChanged("Viewer");
        }

        
            public static string ImageToBase64(string AirWayBillNo)
        {
            var content = AirWayBillNo;
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new Code128EncodingOptions
                {
                    Height = 100,
                    Width = 600,
                    PureBarcode=true
                }

            };
            System.Drawing.Bitmap bmp  = writer.Write(content);

            string _base64String = null;
            using (System.Drawing.Image _image = bmp)
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, ImageFormat.Jpeg);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    return _base64String;
                }
            }
        }

    }

}
    

