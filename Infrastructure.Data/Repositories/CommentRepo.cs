using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CommentRepo : ICommentRepository
    {
        private StudyBuddyContext _ctx;

        public CommentRepo(StudyBuddyContext ctx)
        {
            _ctx = ctx;
        }

        public Comment Create(Comment comment)
        {
            Comment c = _ctx.Comments.Add(comment).Entity;
             _ctx.SaveChanges();
             return c;
        }

        public Comment Delete(long id)
        {
            Comment c = GetComment().ToList().Find(x => x.Id == id);
            GetComment().ToList().Remove(c);
            if (c != null) 
            {
                return c;
            }
            return null;
        }

        public Comment FindById(long id)
        {
            return _ctx.Comments
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
           
        }

        public IEnumerable<Comment> GetComment()
        {
            
            return _ctx.Comments.Include(c => c.Topic).ToList();
        }

        public Comment Update(Comment commentUpdate)
        {
            var commentDB = FindById(commentUpdate.Id);
            if (commentDB != null)
            {
                commentDB.MainBody = commentUpdate.MainBody;
                return commentDB;
            }
            return null;
            
        }
    }
}
