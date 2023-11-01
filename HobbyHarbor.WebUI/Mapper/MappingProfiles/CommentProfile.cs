﻿using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Mapper.ValueResolvers;
using HobbyHarbor.WebUI.Models;

namespace HobbyHarbor.WebUI.Mapper.MappingProfiles
{
    public class CommentProfile : AutoMapper.Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dist => dist.ProfileImage, opt => opt.MapFrom(src => src.Author.Profile.Images.ElementAt(0)))
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.Author.Profile.Name))
                .ForMember(dist => dist.Surname, opt => opt.MapFrom(src => src.Author.Profile.Surname))
                .ForMember(dist => dist.Username, opt => opt.MapFrom(src => src.Author.Username))
                .ForMember(dist => dist.ReplyCommentUsername, opt => opt.MapFrom(src => src.ReplyTo.Author.Username))
                .ForMember(dist => dist.Likes, opt => opt.MapFrom<CommentLikesValueResolver>())
				.ForMember(dist => dist.Dislikes, opt => opt.MapFrom<CommentDislikesValueResolver>());
        }
    }
}
