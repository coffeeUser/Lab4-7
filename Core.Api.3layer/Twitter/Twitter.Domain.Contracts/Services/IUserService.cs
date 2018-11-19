using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Contracts.ViewModels;

namespace Twitter.Domain.Contracts.Services
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        IEnumerable<UserViewModel> GetAll();
        void Add(UserViewModel user);
        void DeleteById(int id);
        void Edit(UserViewModel user);
    }
}
