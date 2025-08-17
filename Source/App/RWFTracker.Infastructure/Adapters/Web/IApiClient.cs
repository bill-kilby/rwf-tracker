using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWFTracker.Infastructure.Adapters.Web
{
    public interface IApiClient<T>
    {
        public Task<T> GetDataAsync();
    }
}
