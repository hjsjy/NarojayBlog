using System.Collections.Generic;
using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Manager.Entiy;
using NarojayBlog.Manager.IManager;
using NarojayBlog.Repository.Repository;

namespace NarojayBlog.Manager.Manager
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
