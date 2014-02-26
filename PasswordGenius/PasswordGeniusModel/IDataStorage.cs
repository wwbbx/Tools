using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    public interface IDataStorage
    {
        // return serialized JSON string for PasswordEntity array.
        // input is also JSON query string.
        string Read(string queryString);

        void Create(string detailJson);

        void Update(string detailJsonWithId);

        void Delete(string idString);
    }
}
