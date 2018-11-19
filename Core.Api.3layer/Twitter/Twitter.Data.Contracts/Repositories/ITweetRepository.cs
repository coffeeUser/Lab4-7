using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Contracts.Entities;

namespace Twitter.Data.Contracts.Repositories
{
    public interface ITweetRepository : IRepository<Tweet>
    {
    }
}
