using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
   public class RegexConst
    {
        public const string username = @"^[0-9a-z._@]{5,50}$";
        public const string password = @"^(?=.*[0-9])[a-zA-Z0-9!@#$%^&*]{6,20}$";
        public const string date = @"(((19|20)\d\d)\-(0[1-9]|1[0-2])\-((0|1)[0-9]|2[0-9]|3[0-1]))$";
        public const string maBV = @"^[0-9]{5}$";
    }
}
