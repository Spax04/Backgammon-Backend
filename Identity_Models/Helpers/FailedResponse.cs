using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Helpers
{
    public class FailedResponse : Response
    {
        public IEnumerable<string> Errors { get; set; }
        public FailedResponse() : base(false)
        {
        }
    }
}
