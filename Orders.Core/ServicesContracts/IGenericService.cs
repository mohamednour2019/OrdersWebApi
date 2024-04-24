using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts
{
    public interface IGenericService<TRequest, TResponse>
    {
        Task<TResponse> performService(TRequest ? requestDto);
    }
}
