using System;
using System.Collections.Generic;
using System.Text;

namespace projekt003.Models
{
    public class User : IEquatable<User>
    {
        public string Id { get; set; }

        public string Login { get ; set; }

        public string Pin { get; set; }

        public bool Equals(User other)
        {
            return this.Id == other.Id;
        }
    }
}
