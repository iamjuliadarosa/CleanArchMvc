using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation {
    public class DomainExceptionValidation:Exception {
        public DomainExceptionValidation(string message) : base(message) {
        }
        public DomainExceptionValidation(string message,Exception innerException) : base(message,innerException) {
        }
        public static void When(bool hasError,string message) {
            if(hasError) {
                throw new DomainExceptionValidation(message);
            }
        }
        public static void When(bool hasError,string message,Exception innerException) {
            if(hasError) {
                throw new DomainExceptionValidation(message,innerException);
            }
        }
    }
}
