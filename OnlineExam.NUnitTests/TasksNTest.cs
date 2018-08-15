﻿using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OnlineExam.Framework;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TasksNTest : BaseNTest
    {

        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            string courseName = "C# Essential";
            var header = ConstructPage<Header>();
           LogProgress("Go to log in page");
            var logInPage = header.GoToLogInPage();
           LogProgress($"Log in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
           LogProgress("Go to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
           LogProgress("get list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
               LogProgress($"search course with {courseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                   LogProgress("Click on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }

        [Test]
        public void IsTaskAvailable()
        {
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var ActualName = firstblock.GetName();
                Assert.AreEqual(TaskName, ActualName, "Task with this name isn't available on this page, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void ClickOnTasksButton()
        {
            string BaseTitle = "Task View - WebApp";
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstBlock.ClickOnTasksButton();
                var ActualTitle = driver.GetCurrentTitle();
                Assert.AreEqual(BaseTitle, ActualTitle, "\"Tasks\" button doesn't work, because of expected title isn't equal to actual title");
            }

        }


        [Test]
        public void StarsCount()
        {
            string StarsCount = "4";
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var count = firstBlock.GetStarsss().ToString();
                Assert.AreEqual(StarsCount, count, "Stars count isn't correct, , because of expected stars cont isn't equal to actual stars count");
            }
        }
    }
}