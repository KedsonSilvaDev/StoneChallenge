using AppStore.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Business.Validator
{
    public class UserValidator
    {
        public static void Validate (User user)
        {
            if (user.TaxNumber.Length != 11)
                throw new Exception("CPF Inválido.");
        }
    }
}
