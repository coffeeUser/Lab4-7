using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Contracts.ViewModels;

namespace Twitter.Domain.Contracts.Services
{
    public interface ITweetService
    {
        TweetViewModel GetById(int id);
        IEnumerable<TweetViewModel> GetAll();
        void Add(TweetViewModel tweet);
        void DeleteById(int id);
        void Edit(TweetViewModel tweet);
    }
}
