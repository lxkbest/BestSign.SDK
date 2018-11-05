using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class GetSignerConfigResult
    {
        public List<SignaturePositionsResult> signaturePositions { get; set; }

        public string isAllowChangeSignaturePosition { get; set; }

        public string pushUrl { get; set; }

        public string password { get; set; }

        public string isVerifySigner { get; set; }

        public string vcodeMail { get; set; }

        public string vcodeMobile { get; set; }

        public string isDrawSignatureImage { get; set; }

        public string signatureImageName { get; set; }

        public string certType { get; set; }
 
    }

    public class SignaturePositionsResult
    {
        public string pageNum { get; set; }

        public string x { get; set; }

        public string y { get; set; }
    }
}
