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
using Accounts_Pos.ViewModel.SalesOrder;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Accounts_Pos.View.SalesOrder.Report
{
    /// <summary>
    /// Interaction logic for SalesOrderEnquiry.xaml
    /// </summary>
    public partial class SalesOrderEnquiry : Window
    {
        private bool _isReportViewerLoaded;
        public SalesOrderEnquiry()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                //_reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                SalesOrderEnquiryViewModel _SOEVM = (SalesOrderEnquiryViewModel)this.DataContext;

                if (_SOEVM.isCustomerReport)
                {
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file

                    reportDataSource1.Value = _SOEVM.ReportList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                    _reportViewer.LocalReport.ReportPath = "...//..//View//SalesOrder//Report//SalesOrderEnquiryReport.rdlc";
                }
                else if ((!_SOEVM.isCustomerReport) && (!_SOEVM.IncludeAddressDetailsChecked))
                {
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource1.Name = "DataSet1";
                    reportDataSource1.Value = _SOEVM.ReporDataSet2tList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource2.Name = "DataSet2";
                    reportDataSource2.Value = _SOEVM.ReportList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
                    _reportViewer.LocalReport.ReportPath = "...//..//View//SalesOrder//Report//SalesOrderDetailsEnquiryReport.rdlc";
                }
                else if ((!_SOEVM.isCustomerReport) && (_SOEVM.IncludeAddressDetailsChecked))
                {
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource1.Name = "DataSetItemLine";
                    reportDataSource1.Value = _SOEVM.ReporDataSet2tList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource2.Name = "DataSetSalesOrder";
                    reportDataSource2.Value = _SOEVM.ReportList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource3.Name = "DataSetInvoiceTo";
                    reportDataSource3.Value = _SOEVM.ReporDataSet3tList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource3);
                    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
                    reportDataSource4.Name = "DataSetDeliveryTo";
                    reportDataSource4.Value = _SOEVM.ReporDataSet4tList;
                    this._reportViewer.LocalReport.DataSources.Add(reportDataSource4);
                    _reportViewer.LocalReport.ReportPath = "...//..//View//SalesOrder//Report//SalesOrderDetailsWithAddressReport.rdlc";
                }


                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }

        




    }

   
}
