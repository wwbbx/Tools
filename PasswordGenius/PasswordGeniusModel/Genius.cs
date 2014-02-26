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
        public IDataStorage DataStorageService { get; set; }

        public void Search(string p)
        {
            throw new NotImplementedException();
        }

        public List<PasswordEntity> SearchResult { get; set; }
    }
}
