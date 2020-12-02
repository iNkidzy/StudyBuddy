using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class CommentService : ICommentService
    {
        public Comment Create(Comment Comment)
        {
            throw new NotImplementedException();
        }

        public Comment CreateComment(long id, string name, DateTime datePosted, string MainBody, Topic topic, User user)
        {
            throw new NotImplementedException();
        }

        public Comment Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Comment FindById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComment()
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment commentUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
