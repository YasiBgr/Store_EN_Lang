using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Application
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public string Massage { get; set; }

        public OperationResult()
        {
            IsSucceeded = false;
        }
        public OperationResult Succeeded(string massage="the operation is successfull")
        {
            IsSucceeded = true;
            Massage = massage;
            return this;
        }
        public OperationResult Failed(string massage = "the operation is Failed")
        {
            IsSucceeded = false;
            Massage = massage;
            return this;
        }
    }
}
