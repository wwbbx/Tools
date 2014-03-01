using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeniusModel
{
    // For any PasswordEntity, "Name" is the key.
    // We don't allow duplicated "Name" to be stored.
    // "Name" has same effect as "ID".
    // That is why we don't use "ID".
    public class PasswordEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Extra { get; set; }

    }
}
