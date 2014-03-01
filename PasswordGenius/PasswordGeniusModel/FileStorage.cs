using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    public class FileStorage:IDataStorage
    {
        private const string fileName = "PasswordData.dat";

        public string Query(string queryString)
        {
            throw new NotImplementedException();
        }

        public void Add(string json)
        {
            
        }

        public void Update(string nameKey, string json)
        {
            throw new NotImplementedException();
        }

        public string QueryName(string name)
        {
            var queryString = "{\"Name\":\"" + name + "\"}";
            var passwordEntityArrayJson = Query(queryString);

            // convert it to List<PasswordEntity>
            var passwordEntityList = JsonConvert.DeserializeObject<List<PasswordEntity>>(passwordEntityArrayJson);

            // select the first one
            var first = passwordEntityList[0];

            return first.ToJson();
        }
    }
}
