using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Accounts_Pos.Helpers;
using Accounts_Pos.ViewModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using Accounts_Pos.View.Company;
using Accounts_Pos.View.Lookup;
using Accounts_Pos.ViewModel;
using Accounts_Pos.ViewModel.Company;
using Accounts_Pos.Helpers;
using Accounts_Pos.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Xml;



namespace Accounts_Pos.ViewModel.Company
{
    class CompanyViewModel : DependencyObject, INotifyPropertyChanged, IModalService
    {

        CompanyModel[] data = null;
        ConfigurationModel dataConfig = null;
        DevelopmentCompanyModel dataDevelopmentCompany = null;
        InternationalSettingsModel dataInternationalSettings = null;
        SystemDetailsModel dataSystem = null;
        // List<DeliveryAddressModel> _ListGrid_Temp = new List<DeliveryAddressModel>();
        ObservableCollection<CompanyModel> _ListGrid_Temp = new ObservableCollection<CompanyModel>();
        public CompanyViewModel()
        {
            selectCompany = new CompanyModel();
            GetCompanies();
            GetConfigurations();
            GetDevelopmentCompany();
            GetInternationalSettings();
            GetSystemDetails();

        }

        private CompanyModel _selectCompany;
        public CompanyModel selectCompany
        {
            get { return _selectCompany; }
            set
            {
                if (_selectCompany != value)
                {
                    _selectCompany = value;
                    OnPropertyChanged("selectCustomer");
                }
            }
        }

        private ICommand _StartCompany { get; set; }
        public ICommand StartCompany
        {
            get
            {
                if (_StartCompany == null)
                {
                    _StartCompany = new DelegateCommand(Start_Company);
                }
                return _StartCompany;
            }

        }

        public void Start_Company()
        {
            App.Current.Properties["Company_Id"] = selectCompany.COMPANY_ID;


            Company_Login _CA = new Company_Login();
            _CA.ShowDialog();

            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {

                if (window.DataContext == this)
                {
                    window.Close();
                }
            }



        }


        public ObservableCollection<CompanyModel> _ListGrid { get; set; }
        public ObservableCollection<CompanyModel> ListGrid
        {
            get
            {
                return _ListGrid;
            }
            set
            {
                this._ListGrid = value;
                OnPropertyChanged("ListGrid");
            }
        }

        public ConfigurationModel _Configuration { get; set; }
        public ConfigurationModel Configuration
        {
            get
            {
                return _Configuration;
            }
            set
            {
                this._Configuration = value;
                OnPropertyChanged("Configuration");
            }
        }

        public DevelopmentCompanyModel _DevelopmentCompany { get; set; }
        public DevelopmentCompanyModel DevelopmentCompany
        {
            get
            {
                return _DevelopmentCompany;
            }
            set
            {
                this._DevelopmentCompany = value;
                OnPropertyChanged("DevelopmentCompany");
            }
        }

        public InternationalSettingsModel _InternationalSettings { get; set; }
        public InternationalSettingsModel InternationalSettings
        {
            get
            {
                return _InternationalSettings;
            }
            set
            {
                this._InternationalSettings = value;
                OnPropertyChanged("InternationalSettings");
            }
        }

        public SystemDetailsModel _SystemDetails { get; set; }
        public SystemDetailsModel SystemDetails
        {
            get
            {
                return _SystemDetails;
            }
            set
            {
                this._SystemDetails = value;
                OnPropertyChanged("SystemDetails");
            }
        }
   
        public async Task<ObservableCollection<CompanyModel>> GetCompanies()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
              var response = client.GetAsync("api/CompanyAPI/GetCompanies").Result;
                _ListGrid_Temp.Clear();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<CompanyModel[]>(await response.Content.ReadAsStringAsync());
                    // EmployeeData = new List<EmployeeModel>();
                    int x = 0;

                    for (int i = 0; i < data.Length; i++)
                    {
                        x++;
                        _ListGrid_Temp.Add(new CompanyModel
                        {
                            SLNO = x,

                            //DELIVERY_CODE = data[i].DELIVERY_CODE,
                            COMPANY_NAME = data[i].COMPANY_NAME,
                            //ADDRESS = data[i].ADDRESS,
                            //COUNTRY = data[i].COUNTRY,
                            //CONTACTS = data[i].CONTACTS,
                            //TELEPHONE = data[i].TELEPHONE,
                            //POSTCODE = data[i].POSTCODE,
                            COMPANY_ID = data[i].COMPANY_ID,


                        });
                    }

                }
                // ListGrid.Clear();

                ListGrid = _ListGrid_Temp;
                //DeliveryAddress.ListGridRef.ItemsSource = ListGrid.ToString();
                return new ObservableCollection<CompanyModel>(_ListGrid_Temp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async void GetConfigurations()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/ConfigurationAPI/GetConfiguration/?id=1").Result;
                if (response.IsSuccessStatusCode)
                {
                    dataConfig = JsonConvert.DeserializeObject<ConfigurationModel>(await response.Content.ReadAsStringAsync());
                    Configuration = dataConfig;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async void GetDevelopmentCompany()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/DevelopmentCompanyAPI/GetDevelopmentCompanyDetails/?id=1").Result;
                if (response.IsSuccessStatusCode)
                {
                    dataDevelopmentCompany = JsonConvert.DeserializeObject<DevelopmentCompanyModel>(await response.Content.ReadAsStringAsync());
                    DevelopmentCompany = dataDevelopmentCompany;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async void GetInternationalSettings()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(GlobalData.gblApiAdress);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/InternationalSettingsAPI/GetInternationalSettings/?id=1").Result;
                if (response.IsSuccessStatusCode)
                {
                    dataInternationalSettings = JsonConvert.DeserializeObject<InternationalSettingsModel>(await response.Content.ReadAsStringAsync());
                    InternationalSettings = dataInternationalSettings;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void GetSystemDetails()
        {
            dataSystem = new SystemDetailsModel();

            dataSystem.WINDOWS_VERSION = Environment.OSVersion.ToString();
            dataSystem.MACHINE_NAME = Environment.MachineName.ToString();
            dataSystem.DOTNET_RUNTIMES = GetDotNetVersions();
            dataSystem.INTERNET_EXPLORER_VERSION = GetInternetExplorerVersion();
            dataSystem.WINDOWS_CURRENT_USER = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            PrinterSettings settings = new PrinterSettings();
            dataSystem.DEFAULT_PRINTER = settings.PrinterName;
            dataSystem.DEFAULT_BROWSER = GetDefaultBrowserName();
            dataSystem.ADOBE_FLASH_VERSION = GetAdobeFlushPlayerVersion();
            dataSystem.MICROSOFT_OFFICE_VERSION = GetOfficeVersion();
            dataSystem.PDF_VIEWER = GetPDFViewerStatus();
            SystemDetails = dataSystem;
        }

        private string GetPDFViewerStatus()
        {
            string pdfReaderStatus = "Disabled";

            RegistryKey key = Registry.ClassesRoot.OpenSubKey(".pdf");
            if (key != null)
            {
                pdfReaderStatus = "Enabled";
            }
            return pdfReaderStatus;
        }

        private string GetOfficeVersion()
        {
            string sVersion = string.Empty;
            Microsoft.Office.Interop.Word.Application appVersion = new Microsoft.Office.Interop.Word.Application();
            appVersion.Visible = false;
            sVersion = appVersion.Version.ToString();
            return sVersion;
        }

        private string GetAdobeFlushPlayerVersion()
        {
            RegistryKey regKey = null;
            regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Macromedia\FlashPlayer");
            if (regKey == null)
            {
                regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Macromedia\FlashPlayerPepper");
            }
            if (regKey != null)
            {
                string flashVersion = Convert.ToString(regKey.GetValue("Version"));
                return flashVersion;
            }
            return string.Empty;
        }

        private string GetDefaultBrowserName()
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string progId;
            string browser = string.Empty;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice))
            {
                if (userChoiceKey == null)
                {
                    browser = "Unknown";
                    return browser;
                }
                object progIdValue = userChoiceKey.GetValue("Progid");
                if (progIdValue == null)
                {
                    browser = "Unknown";
                    return browser;
                }
                progId = progIdValue.ToString();
                switch (progId)
                {
                    case "IE.HTTP":
                        browser = "Internet Explorer";
                        break;
                    case "FirefoxURL":
                        browser = "Mozilla Firefox";
                        break;
                    case "ChromeHTML":
                        browser = "Google Chrome";
                        break;
                    case "OperaStable":
                        browser = "Opera";
                        break;
                    case "SafariHTML":
                        browser = "Safari";
                        break;
                    case "AppXq0fevzme2pys62n3e0fbqa7peapykr8v":
                        browser = "Edge";
                        break;
                    default:
                        browser = "Unknown";
                        break;
                }
            }
            return browser;
        }

        private string GetInternetExplorerVersion()
        {
            string str = "";
            if (Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer").GetValue("Version") != null)
            {
                str = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer").GetValue("Version").ToString();
            }
            return str;
        }

        private string GetDotNetVersions()
        {
            string path = @"SOFTWARE\Microsoft\NET Framework Setup\NDP";
            string display_framwork_name = null;

            RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(path);
            string[] version_names = installed_versions.GetSubKeyNames();

            for (int i = 1; i <= version_names.Length - 1; i++)
            {
                string temp_name = version_names[i].ToString().Substring(1);
                if (installed_versions.OpenSubKey(version_names[i]).GetValue("SP") != null)
                {
                    temp_name = temp_name  + "  SP" + installed_versions.OpenSubKey(version_names[i]).GetValue("SP");
                }
                temp_name = temp_name + "\n";
                display_framwork_name = display_framwork_name + temp_name;
            }

            return display_framwork_name;
        }

        
        private ICommand _AddNewCompanyAsistantClick { get; set; }
        public ICommand AddNewCompanyAsistantClick
        {
            get
            {
                if (_AddNewCompanyAsistantClick == null)
                {
                    _AddNewCompanyAsistantClick = new DelegateCommand(AddNewCompanyAsistant_Click);
                }
                return _AddNewCompanyAsistantClick;
            }

        }

       

        public void AddNewCompanyAsistant_Click()
        {
          
            NewCompanyAssistant _CA = new NewCompanyAssistant();
            _CA.ShowDialog();
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
          
        }

        #region SaveToFileClick

        private ICommand _SaveToFileClick { get; set; }
        public ICommand SaveToFileClick
        {
            get
            {
                if (_SaveToFileClick == null)
                {
                    _SaveToFileClick = new DelegateCommand(SaveToFile_Click);
                }
                return _SaveToFileClick;
            }

        }

        public void SaveToFile_Click()
        {
            try
            {
                DateTime date = DateTime.UtcNow.Date;
                string filename = "TASSupport_" + date.ToString("yyyy-mm-dd") + "@" + DateTime.Now.ToString("hhmmss")+".Xaml" ;
                string filepath = Path.GetTempPath();
                Grid supportGrid = new Grid();
                supportGrid = App.Current.Windows[0].FindName("SupportGrid") as Grid;
                if (supportGrid != null)
                {
                    //Store this Xaml in File

                    FileStream Fs = new FileStream(filepath + filename,
                        FileMode.OpenOrCreate);
                    System.Windows.Markup.XamlWriter.Save(supportGrid, Fs);
                    Fs.Close();

                    
                   /* string strXAML = System.Windows.Markup.XamlWriter.Save(supportGrid);

                    StringBuilder htmlBuilder = new StringBuilder();

                    //Create Top Portion of HTML Document
                    htmlBuilder.Append("<html>");
                    htmlBuilder.Append("<head>");
                    StringReader strReader = new StringReader(strXAML);
                    XmlTextReader xmlReader = new XmlTextReader(strReader);
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "TextBlock"))
                        {
                            if (xmlReader.HasAttributes)
                            {
                                if ((xmlReader.GetAttribute("Text") == "Contact Us")
                                    || (xmlReader.GetAttribute("Text") == "System Details")
                                    || (xmlReader.GetAttribute("Text") == "International Settings")
                                    || (xmlReader.GetAttribute("Text") == "Licence Details")
                                    || (xmlReader.GetAttribute("Text") == "Application Details")
                                    || (xmlReader.GetAttribute("Text") == "Configuration")
                                    || (xmlReader.GetAttribute("Text") == "Pervasive Database"))
                                {
                                    htmlBuilder.Append("<div>");
                                    htmlBuilder.Append(xmlReader.GetAttribute("Text"));
                                    while (xmlReader.Read())
                                    {
                                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "TextBlock"))
                                        {
                                            if (xmlReader.HasAttributes)
                                            {
                                                htmlBuilder.Append(xmlReader.GetAttribute("Text"));
                                            }
                                        }
                                    }
                                    htmlBuilder.Append("</div>");
                                }
                               
                            }
                        }
                    }

                    htmlBuilder.Append("</body>");
                    htmlBuilder.Append("</html>");
                    //Store in html file
                    FileStream Fs1 = new FileStream(@"D:\tanima\25.11.2017_Support\NewDesign.html",
                        FileMode.OpenOrCreate);
                    //string strHTML = HtmlFromXamlConverter.ConvertXamlToHtml(strXAML);
                    using (StreamWriter w = new StreamWriter(Fs1, Encoding.UTF8))
                    {
                        w.Write(htmlBuilder.ToString());
                    }
                    Fs1.Close();*/

                    App.Current.Properties["File_Name"] = filename;
                    App.Current.Properties["File_Path"] = filepath;
                    SaveFile _SF = new SaveFile();
                    _SF.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
        #endregion

        #region RemoteSupportClick

        private ICommand _RemoteSupportClick { get; set; }
        public ICommand RemoteSupportClick
        {
            get
            {
                if (_RemoteSupportClick == null)
                {
                    _RemoteSupportClick = new DelegateCommand(RemoteSupport_Click);
                }
                return _RemoteSupportClick;
            }

        }

        public void RemoteSupport_Click()
        {
            string url = "http://www.infosolz.com/";
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        #region SendToSupportClick

        private ICommand _SendToSupportClick { get; set; }
        public ICommand SendToSupportClick
        {
            get
            {
                if (_SendToSupportClick == null)
                {
                    _SendToSupportClick = new DelegateCommand(SendToSupport_Click);
                }
                return _SendToSupportClick;
            }

        }

        public void SendToSupport_Click()
        {
            try
            {
                System.Diagnostics.Process.Start(@"mailto:support@infosolz.com");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region AddLookUp
        private ICommand _OpenAccountAnalysisClick { get; set; }
        public ICommand OpenAccountAnalysisClick
        {
            get
            {
                if (_OpenAccountAnalysisClick == null)
                {
                    _OpenAccountAnalysisClick = new DelegateCommand(OpenAccountAnalysis_Click);
                }
                return _OpenAccountAnalysisClick;
            }

        }

        public void OpenAccountAnalysis_Click()
        {
            AccountAnalysis _AA = new AccountAnalysis();
            _AA.ShowDialog();
        }

        private ICommand _OpenAccountTypeClick { get; set; }
        public ICommand OpenAccountTypeClick
        {
            get
            {
                if (_OpenAccountTypeClick == null)
                {
                    _OpenAccountTypeClick = new DelegateCommand(OpenAccountType_Click);
                }
                return _OpenAccountTypeClick;
            }

        }

        public void OpenAccountType_Click()
        {
            AccountType _AA = new AccountType();
            _AA.ShowDialog();
        }

        private ICommand _OpenDeliveryModeClick { get; set; }
        public ICommand OpenDeliveryModeClick
        {
            get
            {
                if (_OpenDeliveryModeClick == null)
                {
                    _OpenDeliveryModeClick = new DelegateCommand(OpenDeliveryMode_Click);
                }
                return _OpenDeliveryModeClick;
            }

        }

        public void OpenDeliveryMode_Click()
        {
            DeliveryMode _AA = new DeliveryMode();
            _AA.ShowDialog();
        }

        private ICommand _OpenDeliveryTypeClick { get; set; }
        public ICommand OpenDeliveryTypeClick
        {
            get
            {
                if (_OpenDeliveryTypeClick == null)
                {
                    _OpenDeliveryTypeClick = new DelegateCommand(OpenDeliveryType_Click);
                }
                return _OpenDeliveryTypeClick;
            }

        }

        public void OpenDeliveryType_Click()
        {
            DeliveryType _AA = new DeliveryType();
            _AA.ShowDialog();
        }

        private ICommand _OpenGroupClick { get; set; }
        public ICommand OpenGroupClick
        {
            get
            {
                if (_OpenGroupClick == null)
                {
                    _OpenGroupClick = new DelegateCommand(OpenGroup_Click);
                }
                return _OpenGroupClick;
            }

        }

        public void OpenGroup_Click()
        {
            Accounts_Pos.View.Lookup.Group _AA = new Accounts_Pos.View.Lookup.Group();
            _AA.ShowDialog();
        }

        private ICommand _OpenGroupTypeClick { get; set; }
        public ICommand OpenGroupTypeClick
        {
            get
            {
                if (_OpenGroupTypeClick == null)
                {
                    _OpenGroupTypeClick = new DelegateCommand(OpenGroupType_Click);
                }
                return _OpenGroupTypeClick;
            }

        }

        public void OpenGroupType_Click()
        {
            Accounts_Pos.View.Lookup.GroupType _AA = new Accounts_Pos.View.Lookup.GroupType();
            _AA.ShowDialog();
        }

        private ICommand _OpenMarketCodeClick { get; set; }
        public ICommand OpenMarketCodeClick
        {
            get
            {
                if (_OpenMarketCodeClick == null)
                {
                    _OpenMarketCodeClick = new DelegateCommand(OpenMarketCode_Click);
                }
                return _OpenMarketCodeClick;
            }

        }

        public void OpenMarketCode_Click()
        {
            Accounts_Pos.View.Lookup.MarketCode _AA = new Accounts_Pos.View.Lookup.MarketCode();
            _AA.ShowDialog();
        }

        private ICommand _OpenNatureProductClick { get; set; }
        public ICommand OpenNatureProductClick
        {
            get
            {
                if (_OpenNatureProductClick == null)
                {
                    _OpenNatureProductClick = new DelegateCommand(OpenNatureProduct_Click);
                }
                return _OpenNatureProductClick;
            }

        }

        public void OpenNatureProduct_Click()
        {
            Accounts_Pos.View.Lookup.NatureProduct _AA = new Accounts_Pos.View.Lookup.NatureProduct();
            _AA.ShowDialog();
        }

        private ICommand _OpenNominalAccountDetailsClick { get; set; }
        public ICommand OpenNominalAccountDetailsClick
        {
            get
            {
                if (_OpenNominalAccountDetailsClick == null)
                {
                    _OpenNominalAccountDetailsClick = new DelegateCommand(OpenNominalAccountDetails_Click);
                }
                return _OpenNominalAccountDetailsClick;
            }

        }

        public void OpenNominalAccountDetails_Click()
        {
            Accounts_Pos.View.Lookup.NomialAccountDetails _AA = new Accounts_Pos.View.Lookup.NomialAccountDetails();
            _AA.ShowDialog();
        }

        private ICommand _OpenProductGroupClick { get; set; }
        public ICommand OpenProductGroupClick
        {
            get
            {
                if (_OpenProductGroupClick == null)
                {
                    _OpenProductGroupClick = new DelegateCommand(OpenProductGroup_Click);
                }
                return _OpenProductGroupClick;
            }

        }

        public void OpenProductGroup_Click()
        {
            Accounts_Pos.View.Lookup.ProductGroup _AA = new Accounts_Pos.View.Lookup.ProductGroup();
            _AA.ShowDialog();
        }

        private ICommand _OpenProductTypeClick { get; set; }
        public ICommand OpenProductTypeClick
        {
            get
            {
                if (_OpenProductTypeClick == null)
                {
                    _OpenProductTypeClick = new DelegateCommand(OpenProductType_Click);
                }
                return _OpenProductTypeClick;
            }

        }

        public void OpenProductType_Click()
        {
            Accounts_Pos.View.Lookup.ProductType _AA = new Accounts_Pos.View.Lookup.ProductType();
            _AA.ShowDialog();
        }

        private ICommand _OpenTaxabilityCISClick { get; set; }
        public ICommand OpenTaxabilityCISClick
        {
            get
            {
                if (_OpenTaxabilityCISClick == null)
                {
                    _OpenTaxabilityCISClick = new DelegateCommand(OpenTaxabilityCIS_Click);
                }
                return _OpenTaxabilityCISClick;
            }

        }

        public void OpenTaxabilityCIS_Click()
        {
            Accounts_Pos.View.Lookup.TaxabilityCIS _AA = new Accounts_Pos.View.Lookup.TaxabilityCIS();
            _AA.ShowDialog();
        }

        private ICommand _OpenVatTypeClick { get; set; }
        public ICommand OpenVatTypeClick
        {
            get
            {
                if (_OpenVatTypeClick == null)
                {
                    _OpenVatTypeClick = new DelegateCommand(OpenVatType_Click);
                }
                return _OpenVatTypeClick;
            }

        }

        public void OpenVatType_Click()
        {
            Accounts_Pos.View.Lookup.VatType _AA = new Accounts_Pos.View.Lookup.VatType();
            _AA.ShowDialog();
        }

       
        #endregion

        #region ViewLookUp

        private ICommand _ViewAccountAnalysis { get; set; }
        public ICommand ViewAccountAnalysis
        {
            get
            {
                if (_ViewAccountAnalysis == null)
                {
                    _ViewAccountAnalysis = new DelegateCommand(ViewAccountAnalysis_Click);
                }
                return _ViewAccountAnalysis;
            }

        }

        public void ViewAccountAnalysis_Click()
        {
            ViewAccountAnalysis _VAA = new ViewAccountAnalysis();
            _VAA.ShowDialog();
        }

        private ICommand _ViewAccountType { get; set; }
        public ICommand ViewAccountType
        {
            get
            {
                if (_ViewAccountType == null)
                {
                    _ViewAccountType = new DelegateCommand(ViewAccountType_Click);
                }
                return _ViewAccountType;
            }

        }

        public void ViewAccountType_Click()
        {
            ViewAccountType _VAT = new ViewAccountType();
            _VAT.ShowDialog();
        }

        private ICommand _ViewDeliveryMode { get; set; }
        public ICommand ViewDeliveryMode
        {
            get
            {
                if (_ViewDeliveryMode == null)
                {
                    _ViewDeliveryMode = new DelegateCommand(ViewDeliveryMode_Click);
                }
                return _ViewDeliveryMode;
            }

        }

        public void ViewDeliveryMode_Click()
        {
            ViewDeliveryMode _VDM = new ViewDeliveryMode();
            _VDM.ShowDialog();
        }

        private ICommand _ViewDeliveryType { get; set; }
        public ICommand ViewDeliveryType
        {
            get
            {
                if (_ViewDeliveryType == null)
                {
                    _ViewDeliveryType = new DelegateCommand(ViewDeliveryType_Click);
                }
                return _ViewDeliveryType;
            }

        }

        public void ViewDeliveryType_Click()
        {
            ViewDeliveryType _VDT = new ViewDeliveryType();
            _VDT.ShowDialog();
        }

        private ICommand _ViewGroup { get; set; }
        public ICommand ViewGroup
        {
            get
            {
                if (_ViewGroup == null)
                {
                    _ViewGroup = new DelegateCommand(ViewGroup_Click);
                }
                return _ViewGroup;
            }

        }

        public void ViewGroup_Click()
        {
            ViewGroup _VG = new ViewGroup();
            _VG.ShowDialog();
        }

        private ICommand _ViewGroupType { get; set; }
        public ICommand ViewGroupType
        {
            get
            {
                if (_ViewGroupType == null)
                {
                    _ViewGroupType = new DelegateCommand(ViewGroupType_Click);
                }
                return _ViewGroupType;
            }

        }

        public void ViewGroupType_Click()
        {
            ViewGroupType _VGT = new ViewGroupType();
            _VGT.ShowDialog();
        }

        private ICommand _ViewMarketCode { get; set; }
        public ICommand ViewMarketCode
        {
            get
            {
                if (_ViewMarketCode == null)
                {
                    _ViewMarketCode = new DelegateCommand(ViewMarketCode_Click);
                }
                return _ViewMarketCode;
            }

        }

        public void ViewMarketCode_Click()
        {
            ViewMarketCode _VMC = new ViewMarketCode();
            _VMC.ShowDialog();
        }

        private ICommand _ViewNatureProduct { get; set; }
        public ICommand ViewNatureProduct
        {
            get
            {
                if (_ViewNatureProduct == null)
                {
                    _ViewNatureProduct = new DelegateCommand(ViewNatureProduct_Click);
                }
                return _ViewNatureProduct;
            }

        }

        public void ViewNatureProduct_Click()
        {
            ViewNatureProduct _VNP = new ViewNatureProduct();
            _VNP.ShowDialog();
        }

        private ICommand _ViewNominalAccountDetails { get; set; }
        public ICommand ViewNominalAccountDetails
        {
            get
            {
                if (_ViewNominalAccountDetails == null)
                {
                    _ViewNominalAccountDetails = new DelegateCommand(ViewNominalAccountDetails_Click);
                }
                return _ViewNominalAccountDetails;
            }

        }

        public void ViewNominalAccountDetails_Click()
        {
            ViewNominalAccountDetails _VNAD = new ViewNominalAccountDetails();
            _VNAD.ShowDialog();
        }

        private ICommand _ViewProductGroup { get; set; }
        public ICommand ViewProductGroup
        {
            get
            {
                if (_ViewProductGroup == null)
                {
                    _ViewProductGroup = new DelegateCommand(ViewProductGroup_Click);
                }
                return _ViewProductGroup;
            }

        }

        public void ViewProductGroup_Click()
        {
            ViewProductGroup _VPG = new ViewProductGroup();
            _VPG.ShowDialog();
        }

        private ICommand _ViewProductType { get; set; }
        public ICommand ViewProductType
        {
            get
            {
                if (_ViewProductType == null)
                {
                    _ViewProductType = new DelegateCommand(ViewProductType_Click);
                }
                return _ViewProductType;
            }

        }

        public void ViewProductType_Click()
        {
            ViewProductType _VPT = new ViewProductType();
            _VPT.ShowDialog();
        }

        private ICommand _ViewTaxabilityCIS { get; set; }
        public ICommand ViewTaxabilityCIS
        {
            get
            {
                if (_ViewTaxabilityCIS == null)
                {
                    _ViewTaxabilityCIS = new DelegateCommand(ViewTaxabilityCIS_Click);
                }
                return _ViewTaxabilityCIS;
            }

        }

        public void ViewTaxabilityCIS_Click()
        {
            ViewTaxabilityCIS _VTC = new ViewTaxabilityCIS();
            _VTC.ShowDialog();
        }

        private ICommand _ViewVatType { get; set; }
        public ICommand ViewVatType
        {
            get
            {
                if (_ViewVatType == null)
                {
                    _ViewVatType = new DelegateCommand(ViewVatType_Click);
                }
                return _ViewVatType;
            }

        }

        public void ViewVatType_Click()
        {
            ViewVatType _VVT = new ViewVatType();
            _VVT.ShowDialog();
        }

        #endregion

        #region RefreshButton

        private ICommand _Refresh { get; set; }
        public ICommand Refresh
        {
            get
            {
                if (_Refresh == null)
                {
                    _Refresh = new DelegateCommand(RefreshButton_Click);
                }
                return _Refresh;
            }

        }

        public void RefreshButton_Click()
        {
            GetCompanies();
            NotifyPropertyChanged("ListGrid");
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private Stack<BackNavigationEventHandler> _backFunctions
           = new Stack<BackNavigationEventHandler>();

        void IModalService.NavigateTo(System.Windows.Window uc, BackNavigationEventHandler backFromDialog)
        {

        }


        void IModalService.GoBackward(bool dialogReturnValue)
        {
        }


        public static IModalService ModalService
        {
            get { return (IModalService)System.Windows.Application.Current.MainWindow; }
        }

    }
}
