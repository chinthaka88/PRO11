using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public class AppErrors : IAppErrors
    {
            List<Error> elist=new List<Error>();           
            public void AddError(string key, string errorMessage)
            {
                elist.Add(new Error() { Key = key, Value = errorMessage });
            }
            public bool IsValid
            {
                get { 
                    if(elist.Count==0)
                    {
                        return true;
                    }
                    return false;
                
                }
            }
    

        public List<Error> GetErrors()
        {
            return elist;
        }
}
}
