using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimonial.GlobleExceptionHandling.Utility.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string massage):base(massage)
        {
            
        }
    }
}
