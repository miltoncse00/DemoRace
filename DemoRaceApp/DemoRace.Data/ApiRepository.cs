using DemoRace.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoRace.Data
{
    public class ApiRepository<T> : IRepository<T> where T : new()
    {
        private readonly string url;

        public ApiRepository(string url)
        {
            this.url = url;
        }
        public async Task<IList<T>> GetAll()
        {
            var json = await GetStringAync(url);
            var data = JsonConvert.DeserializeObject<IList<T>>(json);
            return data;
        }

        private static async Task<string> GetStringAync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}
