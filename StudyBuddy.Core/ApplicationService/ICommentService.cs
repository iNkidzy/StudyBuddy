using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface ICommentService
    {
        Comment CreateComment(DateTime datePosted, string mainBody, Topic topic, User user);

        Comment Create(Comment comment);

        Comment Update(Comment commentUpdate);

        Comment Delete(long id);

        Comment FindById(long id);

        public List<Comment> GetComment();

    }
}
