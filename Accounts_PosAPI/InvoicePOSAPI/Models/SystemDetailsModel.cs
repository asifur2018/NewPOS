using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePOSAPI.Models
{
    public class SystemDetailsModel
    {
        public string WINDOWS_VERSION { get; set; }
        public string MACHINE_NAME { get; set; }
        public string DOTNET_RUNTIMES { get; set; }
        public string INTERNET_EXPLORER_VERSION { get; set; }
        public string HTML_HELP_VERSION { get; set; }
        public string WINDOWS_CURRENT_USER { get; set; }
        public string DEFAULT_PRINTER { get; set; }
        public string DEFAULT_BROWSER { get; set; }
        public string ADOBE_FLASH_VERSION { get; set; }
        public string MICROSOFT_OFFICE_VERSION { get; set; }
        public string PDF_VIEWER { get; set; }
    }
}