using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class GetInfoResult
    {
        public string fid { get; set; }

        public string senderAccount { get; set; }

        public string userId { get; set; }

        public string description { get; set; }

        public string expireTime { get; set; }

        public string title { get; set; }

        public string sendTime { get; set; }

        public string finishTime { get; set; }

        public List<string> signers { get; set; }

        public string developerId { get; set; }

        public string pages { get; set; }

        public string contractId { get; set; }

        public string status { get; set; }
    }
}
