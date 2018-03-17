using AutoMapper;
using Shop.Model.Models;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Mappings
{
    public static class AutoMapperConfiguration   
    {
        public static void RegisterMappings()
        {
            //CreateMap<Post, PostViewModel>().ReverseMap();
            //CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
            //CreateMap<PostTag, PostTagViewModel>().ReverseMap();
            //CreateMap<Tag, TagViewModel>().ReverseMap();
            //CreateMap<Product, ProductViewModel>().ReverseMap();
            //CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();.
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostViewModel>();
            });
            Mapper.Initialize(cfg => {
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
            });
            Mapper.Initialize(cfg => {
                cfg.CreateMap<PostTag, PostTagViewModel>();
            });
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Tag, TagViewModel>();
            });
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Product, ProductViewModel>();
            });
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
            });
        }

    }
}