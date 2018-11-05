using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSign.SDK.BestSignSDK.Push
{
    public class CertApplyPush : IPush
    {
        public string certType { get; set; }

        public string cert { get; set; }

        public string message { get; set; }

        public string account { get; set; }

        public string taskId { get; set; }

        public string status { get; set; }
    }
}
