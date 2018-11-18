using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Contracts.Entities;
using Twitter.Data.Contracts.Repositories;
using Twitter.Data.Repositories.Context;

namespace Twitter.Data.Repositories.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        TwitterContext context;

        public TweetRepository(TwitterContext context)
        {
            this.context = context;
        }

        public void Add(Tweet target)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Tweet target)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tweet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tweet GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
