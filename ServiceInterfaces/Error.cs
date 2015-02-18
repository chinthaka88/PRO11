using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public class Error
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string  value1;

        public string  Value
        {
            get { return value1; }
            set { value1 = value; }
        }
        
    }
}
