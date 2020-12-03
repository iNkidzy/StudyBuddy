using Core.Entity;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class CommentRepo : ICommentRepository
    {
        private static List<Comment> _commentList = new List<Comment>();
        readonly ICommentService _comService;
        public CommentRepo(ICommentService commentService)
        {
            _comService = commentService;
        }
        public Comment Create(Comment comment)
        {
            _commentList.Add(comment);
            return comment;
            /* Comment c = _ctx.Comments.Add(comment).Entity;
             _ctx.SaveChanges();
             return c;*/
        }

        public Comment Delete(long id)
        {
            /*  Comment c = GetComment().ToList().Find(x => x.Id == id);
            GetComment().ToList().Remove(c);
            if (c != null) 
            {
                return c;
            }
            return null;*/
            throw new NotImplementedException();
        }

        public Comment FindById(long id)
        {
            var comment = _commentList.Find(x => x.Id == id);
            return comment;
            /*return _ctx.Comments
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);*/
           
        }

        public IEnumerable<Comment> GetComment()
        {
            return _commentList.ToList();
            /*
            return _ctx.Comments.Include(c => c.Topic).ToList();*/

            throw new NotImplementedException();
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
