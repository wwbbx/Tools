using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGeniusModel
{
    public interface IDataStorage
    {

        string Query(string queryString);

        void Add(string json);

        void Update(string nameKey, string json);
    }
}
