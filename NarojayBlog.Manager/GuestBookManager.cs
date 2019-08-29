using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.IManager;
using NarojayBlog.ManagerEntity;
using NarojayBlog.Repository.Repository;
using System.Collections.Generic;

namespace NarojayBlog.Manager
{
    public class GuestBookManager : BaseManager<GuestBook, GuestBookEntity, GuestBookRepository>, IGuestBookManager
    {
        public GuestBookManager(GuestBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public IEnumerable<GuestBookEntity> GetAllGuestBook()
        {
            return GetAll();
        }
    }
}
