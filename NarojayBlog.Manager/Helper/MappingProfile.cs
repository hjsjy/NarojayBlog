using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.ManagerEntity;
using NarojayBlog.ViewModel;

namespace NarojayBlog.Manager.Helper
{
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
            #region Article
            CreateMap<Article, ArticleEntity>();
            CreateMap<ArticleEntity, Article>();
            CreateMap<ArticleAddViewModel, ArticleEntity>();
            CreateMap<ArticleEntity, ArticleAddViewModel>();
            #endregion


            #region Catalog

            CreateMap<Catalog, CatalogEntity>();
            CreateMap<CatalogEntity, Catalog>();
            CreateMap<CatalogAddViewModel, CatalogEntity>();
            CreateMap<CatalogEntity, CatalogAddViewModel>();

            #endregion


        }
        }
    
}
