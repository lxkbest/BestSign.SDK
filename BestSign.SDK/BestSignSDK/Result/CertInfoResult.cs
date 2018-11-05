using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class CertInfoResult
    {
        public string serialNumber { get; set; }

        public string statusMsg { get; set; }

        public string issuerDN { get; set; }

        public string revokedTime { get; set; }

        public string startTime { get; set; }

        public string stopTime { get; set; }

        public string certId { get; set; }

        public string revokedReason { get; set; }

        public string subjectDN { get; set; }

        public int status { get; set; }

 
    }
}
