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

            // send query string to DataStorage

            // convert returned string as PasswordEntity array

            throw new NotImplementedException();
        }

        public void Insert(PasswordEntity passwordEntityToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
