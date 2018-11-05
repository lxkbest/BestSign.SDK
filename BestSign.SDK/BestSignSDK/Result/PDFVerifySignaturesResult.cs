using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class PDFVerifySignaturesResult
    {
        public string verifyResult { get; set; }

        public List<PDFVerifySignaturesDetailsResult> signatureDetails { get; set; }
    }

    public class PDFVerifySignaturesDetailsResult
    {
        public int signatureNumber { get; set; }

        public string singer { get; set; }

        public string serialNumber { get; set; }

        public string dn { get; set; }

        public string signTime { get; set; }

        public string signIsModified { get; set; }

        public string documentIsModified { get; set; }
    }
}
