using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entities;
using DAL.Interface.Entity;

namespace BL.Mappers
{
    public static class BlCommentsMapper
    {
         public static DalComment ToDalComment(this CommentBL bllcomment)
            {
                return new DalComment()
                {
                    Id = bllcomment.Id,
                    IdPeople = bllcomment.IdPeople,
                    IdRecord = bllcomment.IdRecord,
                    Comments = bllcomment.Comments
                    
                    
                };
            }

            public static CommentBL ToBlComment(this DalComment dalComment)
            {
                return new CommentBL()
                {
                    Id = dalComment.Id,
                    IdPeople = dalComment.IdPeople,
                    IdRecord = dalComment.IdRecord,
                    Comments = dalComment.Comments,
                    Author = dalComment.Author.ToBlPerson()

                };
            }
        
    }
}
