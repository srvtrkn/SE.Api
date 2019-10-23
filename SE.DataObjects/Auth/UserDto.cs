using System;
using System.Collections.Generic;
using System.Text;

namespace SE.DataObjects.Auth
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
