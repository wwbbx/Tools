using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGeniusModel
{
    /// <summary>
    /// 1. search(anything) -> get [search result]
    /// 2. load(id) -> get(detail)
    /// 3. add(detail) -> save it
    /// </summary>
    public class Genius
    {
        public IDataService DataStorageService { get; set; }

        public void Search(string anything)
        {
            List<PasswordEntity> searchNameResults = DataStorageService.Search("{name:" + anything + "}");
            SearchResult = MergeSearchResult(SearchResult, searchNameResults);

            List<PasswordEntity> searchDescriptionResults = DataStorageService.Search("{description:" + anything + "}");
            SearchResult = MergeSearchResult(SearchResult, searchDescriptionResults);

            List<PasswordEntity> searchExtraResults = DataStorageService.Search("{extra:" + anything + "}");
            SearchResult = MergeSearchResult(SearchResult, searchExtraResults);
        }

        public List<PasswordEntity> MergeSearchResult(
            List<PasswordEntity> one, 
            List<PasswordEntity> another)
        {
            return one.Union<PasswordEntity>(another).ToList<PasswordEntity>();
        }

        private List<PasswordEntity> searchResult = new List<PasswordEntity>();
        public List<PasswordEntity> SearchResult 
        { 
            get
            {
                return searchResult;
            }
            set
            {
                searchResult = value;
            }
        }

        public PasswordEntity LoadByNameKey(string name)
        {
            // external should check whether this "name" key entity exist or not
            // before calling this function.
            // So we don't deal with if found result is empty or null.

            var querySetting = "{\"Name\":\"" + name + "\"}";
            var list = DataStorageService.Search(querySetting);
            return list[0];
        }

        public bool Has(PasswordEntity passwordEntity)
        {
            return DataStorageService.Contains(passwordEntity);
        }

        public void Add(PasswordEntity passwordEntityToInsert)
        {
            DataStorageService.Insert(passwordEntityToInsert);
        }
    }
}
