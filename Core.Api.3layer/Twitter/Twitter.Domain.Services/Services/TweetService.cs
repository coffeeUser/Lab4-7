using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Contracts.Services;
using Twitter.Domain.Contracts.ViewModels;

namespace Twitter.Domain.Services.Services
{
    public class TweetService : ITweetService
    {
        public void Add(TweetViewModel tweet)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(TweetViewModel tweet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TweetViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TweetViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
