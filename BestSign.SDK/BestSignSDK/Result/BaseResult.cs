using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestSignSDK.Result
{
    public class BaseResult<T>
    {
        public int errno { get; set; }

        public int cost { get; set; }

        public T data { get; set; }

        public string errmsg { get; set; }
    }
}
