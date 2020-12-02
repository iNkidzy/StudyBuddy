using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService
{
    public interface ICommentService
    {
        Comment CreateCourse(long id, string name, DateTime datePosted, string MainBody);

        Comment Create(Comment Comment);

        Comment Update(Comment commentUpdate);

        Comment Delete(long id);

        Comment FindById(long id);

        public List<Comment> GetCourse();

    }
}
