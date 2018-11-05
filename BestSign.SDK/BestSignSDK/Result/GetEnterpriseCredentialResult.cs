using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class GetEnterpriseCredentialResult
    {
        public string regCode { get; set; }

        public string taxCode { get; set; }

        public string orgCode { get; set; }

        public string legalPerson { get; set; }

        public string legalPersonIdentity { get; set; }

        public string legalPersonIdentityType { get; set; }

        public string legalPersonMobile { get; set; }

        public string contactMail { get; set; }

        public string name { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string address { get; set; }
    }
}
