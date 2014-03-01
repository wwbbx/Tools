using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    public class GeniusDataService:IDataService
    {
        public IDataStorage DataStorage { get; set; }

        public List<PasswordEntity> Search(string jsonQueryString)
        {
            // extract jsonQueryString as query setting
            var setting = ConvertJsonStringToPasswordEntity(jsonQueryString);

            // send query string to DataStorage
            var queryString = ConvertPasswordEntityToJsonString(setting);

            // convert returned string as PasswordEntity array
            var queryResult = DataStorage.Query(queryString);
            var result = JsonConvert.DeserializeObject(queryResult, typeof(List<PasswordEntity>));

            return result as List<PasswordEntity>;
        }

        public bool Contains(PasswordEntity passwordEntity)
        {
            var queryJson = ConvertPasswordEntityToJsonString(passwordEntity);

            var exists = Search(queryJson);

            return exists.Count > 0 ? true : false;
        }

        public void Insert(PasswordEntity passwordEntityToInsert)
        {
            if (Contains(passwordEntityToInsert))
            {
                Update(passwordEntityToInsert);
            }
            else
            {
                Add(passwordEntityToInsert);
            }
        }

        private void Add(PasswordEntity passwordEntityToInsert)
        {
            var json = ConvertPasswordEntityToJsonString(passwordEntityToInsert);
            DataStorage.Add(json);
        }

        private void Update(PasswordEntity passwordEntityToInsert)
        {
            var json = ConvertPasswordEntityToJsonString(passwordEntityToInsert);
            DataStorage.Update(passwordEntityToInsert.Name, json);
        }

        private string ConvertPasswordEntityToJsonString(PasswordEntity passwordEntity)
        {
            return JsonConvert.SerializeObject(passwordEntity);
        }

        private PasswordEntity ConvertJsonStringToPasswordEntity(string json)
        {
            return JsonConvert.DeserializeObject<PasswordEntity>(json);
        }

    }
}
