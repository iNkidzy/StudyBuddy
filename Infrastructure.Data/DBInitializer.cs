using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(StudyBuddyContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            List<Topic> topicList1 = new List<Topic>();
            List<Topic> topicList2 = new List<Topic>();
            List<Comment> commentList1 = new List<Comment>();
            List<Comment> commentList2 = new List<Comment>();
            List<Course> courseList1 = new List<Course>();

            var user1 = ctx.Users.Add(new User()
            {
                Id = 1,
                Email = "email@email.email",
                UserType = UserType.Teacher,
                Name = "Mig",
                Courses = courseList1
            }).Entity;

            var user2 = ctx.Users.Add(new User()
            {
                Id = 2,
                Email = "email@email.email",
                UserType = UserType.Admin,
                Name = "Dig"
            }).Entity;

            var user3 = ctx.Users.Add(new User()
            {
                Id = 3,
                Email = "email@email.email",
                UserType = UserType.User,
                Name = "Ikke Mig"
            }).Entity;

            var course1 = ctx.Courses.Add(new Course()
            {
                Id = 1,
                Name = "SDM",
                Topics = topicList1
            }).Entity;

            var course2 = ctx.Courses.Add(new Course()
            {
                Id = 3,
                Name = "SDP",
                Topics = topicList2
            }).Entity;

            var topic1 = ctx.Topics.Add(new Topic()
            {
                Id = 1,
                Name = "HTML",
                Course = course1,
                MainBody = "HTML is a computer language devised to allow website creation. \n" +
                           "These websites can then be viewed by anyone else connected to the Internet. \n" +
                           "It is relatively easy to learn, with the basics being accessible to most people in one sitting; and quite powerful in what it allows you to create. \n" +
                           "It is constantly undergoing revision and evolution to meet the demands and requirements of the growing Internet audience under the direction of the » W3C, the organisation charged with designing and maintaining the language",
                Comments = commentList2
            }).Entity;

            var topic2 = ctx.Topics.Add(new Topic()
            {
                Id = 2,
                Name = "My Mental State",
                Course = course1,
                MainBody = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA \n" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA \n" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA \n" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA \n" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Comments = commentList1
            }).Entity;

            var topic3 = ctx.Topics.Add(new Topic()
            {
                Id = 7,
                Name = "Why are you here?",
                Course = course2,
                MainBody = "There's nothing here? Why do you bother?",
                Comments = new List<Comment>()
                {

                }
            }).Entity;

            var comment1 = ctx.Comments.Add(new Comment()
            {
                Id = 1,
                User = user1,
                Topic = topic2,
                DatePosted = DateTime.Now.AddDays(-2),
                MainBody = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
            }).Entity;

            var comment2 = ctx.Comments.Add(new Comment()
            {
                Id = 2,
                User = user2,
                Topic = topic2,
                DatePosted = DateTime.Now.AddDays(-1),
                MainBody = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
            }).Entity;

            var comment3 = ctx.Comments.Add(new Comment()
            {
                Id = 5,
                User = user3,
                Topic = topic1,
                DatePosted = DateTime.Now.AddDays(-3),
                MainBody = "I disagree"
            }).Entity;

            topicList1.Add(topic1);
            topicList1.Add(topic2);
            topicList2.Add(topic3);
            commentList1.Add(comment1);
            commentList1.Add(comment2);
            commentList2.Add(comment3);
            courseList1.Add(course1);
            ctx.SaveChanges();
        }
    }
}
