using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Contracts.Services;
using Twitter.Domain.Contracts.ViewModels;

namespace Twitter.Domain.Services.Services
{
    public class UserService : IUserService
    {
        public void Add(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
