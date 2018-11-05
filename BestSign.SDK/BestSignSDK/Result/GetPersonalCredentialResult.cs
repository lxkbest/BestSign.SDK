using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public  class GetPersonalCredentialResult
    {
        public string account { get; set; }

        public string identity { get; set; }

        public string identityType { get; set; }

        public string contactMail { get; set; }

        public string contactMobile { get; set; }

        public string name { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string address { get; set; }
    }
}
