using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi22_WebAPI.Entities
{
    public class ApiResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
