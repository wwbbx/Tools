using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    // DataService is the linkage between real data storage (DB or file)
    // with upper level requirement by Genius.
    // QueryString is JSON PasswordEntity as query setting.
    // returned JSON will be converted as list of PasswordEntity.
    public interface IDataService
    {
        List<PasswordEntity> Search(string jsonQueryString);

        void Insert(PasswordEntity passwordEntityToInsert);
    }
}
