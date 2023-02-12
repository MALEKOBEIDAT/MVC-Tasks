using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codeFirst.Models
{
    public class User
    {
        public long  Id { get; set; }  //بس يشوف id مباشره بعملو PK
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}