﻿using AutoMapper;
using NarojayBlog.DatabaseRepository.Model;
using NarojayBlog.Manager.Entiy;
using NarojayBlog.ViewModel;

namespace NarojayBlog.Webapi.Helper
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

            #region GuestBook
            CreateMap<GuestBook, GuestBookEntity>();
            CreateMap<GuestBookEntity, GuestBook>();
            #endregion

        }
        }
    
}
