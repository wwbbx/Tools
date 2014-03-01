using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    public class GeniusDataStorage:IDataService
    {
        public IDataStorage DataStorage { get; set; }

        public List<PasswordEntity> Search(string jsonQueryString)
        {
            throw new NotImplementedException();
        }

        public void Insert(PasswordEntity passwordEntityToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
