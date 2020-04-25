using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorchApi.Interfaces
{
    public interface ILocationService
    {
        Task<IList<Guid>> LocationsByDistance();
    }
}
