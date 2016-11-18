using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Common.Interfaces
{
    //Interface defines the members of and interaction not the implementation logic
    public interface ILoggable
    {
        string Log();
    }
}
