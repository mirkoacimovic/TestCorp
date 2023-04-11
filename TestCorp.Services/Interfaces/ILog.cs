using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Models;

namespace TestCorp.Services.Interfaces
{
    public interface ILog
    {
        Task<bool> Log(SystemLog entry);
     }
}
