using Newtonsoft.Json;
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

        public string ToJson()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return jsonString;
        }

        public void ParseJson(string jsonString)
        {
            var passwordEntity = JsonConvert.DeserializeObject<PasswordEntity>(jsonString);
            
            this.Name = passwordEntity.Name;
            this.Description = passwordEntity.Description;
            this.Password = passwordEntity.Password;
            this.Extra = passwordEntity.Extra;
        }

    }
}
