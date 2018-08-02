using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRace.Common
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
    }
}
