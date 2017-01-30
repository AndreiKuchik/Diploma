using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.Interface.Entities;
using PLnew.Models;
using PLnew.ViewModels;

namespace PLnew.Infrastructure.Mappers
{
    public static class MVCCommentMapper
    {
        public static CommentBL ToBlComment(this CommentViewModel comment)
        {

            return new CommentBL()
            {
                Id = comment.Id,
                IdPeople = comment.IdUser,
                IdRecord = comment.IdRecord,
                Comments = comment.Comment
               
            };
        }

        public static CommentViewModel ToMVCComment(this CommentBL comment)
        {
            return new CommentViewModel()
            {
                Id = comment.Id,
                IdUser = comment.IdPeople,
                IdRecord = comment.IdRecord,
                Comment = comment.Comments,
                Author = comment.Author.ToPLUser()
                
            };
        }
    }
}