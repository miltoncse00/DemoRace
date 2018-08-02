using DemoRace.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoXTests
{
    public class FakeRepository<T> : IRepository<T> where T : new()
    {
        public FakeRepository(IList<T> items)
        {
            this.items = items;
        }
        private IList<T> items = new List<T>();
        public async Task<IList<T>> GetAll()
        {
            return await Task.Run(() =>  items);
        }
    }
}
