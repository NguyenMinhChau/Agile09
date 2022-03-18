using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.Common
{
    [Serializable]
    public class ManagerLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
    }
}