using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.UseCases
{
    public interface IJob
    {
        Task ExecuteAsync();
    }
}
