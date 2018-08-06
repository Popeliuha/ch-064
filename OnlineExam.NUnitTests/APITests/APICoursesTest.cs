﻿using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;
using System;

namespace OnlineExam.NUnitTests.APITests
{
    [Category("APITests")]
    [TestFixture]
    public class APICoursesTest
    {
        private APICoursesClient client;

        [SetUp]
        public void SetUp()
        {
            client = new APICoursesClient();
        }

        [Test]
        public void GetCourse()
        {
            string CourseName = "C# Essential";
            client = new APICoursesClient();
            client.Get();
            var actual = new CoursesDAL().GetCourseByCourseName(CourseName);
            Assert.AreEqual(actual.Name, CourseName);
        }

        [Test]
        public void Post()
        {
            Guid g = new Guid();
            var obj = new
            {
                //        id = 0,
                //        name = "string",
                //        description = "string",
                //        isActive = true,
                //        creationDate = "2018-08-06T12:49:40.211Z",
                //        userId = "string",
                //        user = {
                //        id = "string",
                //            userName = "string",
                //            email = "string",
                //            userRating = 0,
                //            doneTaskNumber = 0
                //               }
                //};

                CourseId = "1",
                CourseName = "C# CourseName",
                Description = "Description for new Course",
                isActive = "True",
                CreatingDate = "2018-08-05 16:30:00.4611346",
                UserId = "c557d51b-2a7e-46b4-8ed0-fe9253d8f861"
            };

            client = new APICoursesClient();
            client.Post(obj);
            var actual = new CoursesDAL().GetCourseByCourseID(obj.CourseId);
            Assert.AreEqual(actual.Id, obj.CourseId);
        }

        [Test]
        public void Delete()
        {
            int CourseId = 2;
            client = new APICoursesClient();
            client.Delete(CourseId);
            var actual = new CoursesDAL().GetCourseByCourseID(CourseId.ToString());
            Assert.IsEmpty(actual.ToString());
        }
    }
}