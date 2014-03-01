using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    public interface IDataStorage
    {
        List<PasswordEntity> Search(string jsonQueryString);

        void Insert(PasswordEntity passwordEntityToInsert);
    }
}
