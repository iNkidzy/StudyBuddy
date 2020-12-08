using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Validators
{
    public class CommentValidator : ICommentValidator
    {
        public void DefaultValidation(Comment comment)
        {
            if(comment == null)
            {
                throw new NullReferenceException("Comment can not be null");
            }
            if(comment.User == null)
            {
                throw new NullReferenceException("Comment must have a User");
            }
            if(comment.Topic == null)
            {
                throw new NullReferenceException("Comment must have a Topic");
            }
            if (string.IsNullOrEmpty(comment.MainBody)){
                throw new ArgumentException("Comment must not be empty");
            }
            if(comment.DatePosted > DateTime.Now)
            {
                throw new ArgumentException("DatePosted can not be in the future");
            }
        }
    }
}
