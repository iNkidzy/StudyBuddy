using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.DomainService
{
    public interface ICommentRepository
    {
        Comment Create(Comment comment);

        Comment Update(Comment commentUpdate);

        Comment Delete(long id);

        Comment FindById(long id);

        public IEnumerable<Comment> GetComment();
    }
}
