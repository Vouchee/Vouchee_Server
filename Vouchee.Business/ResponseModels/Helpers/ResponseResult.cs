using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vouchee.Business.ResponseModels.Helpers
{
    public class ResponseResult<T>
    {
        public string? Message { get; set; }
        public T? Value { get; set; }
        public bool? Result { get; set; }

        public string? Response {  get; set; }
    }
}
