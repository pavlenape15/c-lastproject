using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Project
{
    public class User
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProgramName { get; set; }


        public override string ToString()
        {
            return $"{UserName} --- {ProgramName}";
        }
    }
}
