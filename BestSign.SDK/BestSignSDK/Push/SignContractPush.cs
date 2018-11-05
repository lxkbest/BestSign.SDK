using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSign.SDK.BestSignSDK.Push
{
    public class SignContractPush : IPush
    {
        public string contractId { get; set; }

        public string account { get; set; }

        public string signerStatus { get; set; }

        public string errMsg { get; set; }

        public string sid { get; set; }
    }
}
