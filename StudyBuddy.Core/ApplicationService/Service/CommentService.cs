using Core.Entity;
using StudyBuddy.Core.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudyBuddy.Core.ApplicationService.Service
{
    public class CommentService : ICommentService
    {
        readonly ICommentRepository _comRepo;
        public CommentService(ICommentRepository commentRepository) 
        {
            _comRepo = commentRepository;
        }
        public Comment Create(Comment comment)
        {
            return _comRepo.Create(comment);
        }

        public Comment CreateComment(DateTime datePosted, string mainBody, Topic topic, User user)
        {
            var comment = new Comment()
            {
                DatePosted = datePosted,
                MainBody = mainBody,
                Topic = topic,
                User = user
            };
            return comment;
        }

        public Comment Delete(long id)
        {
            return _comRepo.Delete(id);
        }

        public Comment FindById(long id)
        {
            return _comRepo.FindById(id);
        }

        public List<Comment> GetComment()
        {
            return _comRepo.GetComment().ToList();
        }

        public Comment Update(Comment commentUpdate)
        {
            if (commentUpdate.MainBody.Length < 1)
            {
                throw new InvalidDataException("comment must be atleast 1 character");
            }
            else 
            {
                var comment = FindById(commentUpdate.Id);
                comment.MainBody = commentUpdate.MainBody;
                comment.Topic = commentUpdate.Topic;
                comment.User = commentUpdate.User;
                comment.DatePosted = commentUpdate.DatePosted;
                return comment;
            }
           // return _comRepo.Update(commentUpdate);
        }
    }
}
