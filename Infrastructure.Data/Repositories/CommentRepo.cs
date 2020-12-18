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
            Comment com = FindById(id);
            _ctx.Attach(com).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return com;
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
            _ctx.Attach(commentUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return commentUpdate;

        }
    }
}
