using AppStore.Business.Entities;
using AppStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppStore.Business.Mapper
{
    public static class UserMapper
    {
        public static User UserToModel (this UserModel userModel)
        {
            User user = new User()
            {
                Name = userModel.Name,
                TaxNumber = FormatCPF(userModel.TaxNumber),
                BirthDate = userModel.BirthDate,
                Gender = userModel.Gender,
                Address = userModel.Address,
                Number = userModel.Number,
                Neighborhood = userModel.Neighborhood,
                ZipCode = userModel.ZipCode,
                City = userModel.City,
                State = userModel.State,
                Country = userModel.Country
            };

            return user;
        }

        public static string FormatCPF (string text)
        {
            return text.Replace(".", string.Empty).Replace("-", string.Empty);
        }

    }
}
