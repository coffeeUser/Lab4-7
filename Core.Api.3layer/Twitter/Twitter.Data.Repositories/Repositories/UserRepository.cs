using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Contracts.Entities;
using Twitter.Data.Contracts.Repositories;

namespace Twitter.Data.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User target)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User target)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
