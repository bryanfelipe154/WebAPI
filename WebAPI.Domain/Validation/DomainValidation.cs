using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string? message) : base(message)
        {
        }

        public static void Check(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainValidation(errorMessage);
        }
    }
}
