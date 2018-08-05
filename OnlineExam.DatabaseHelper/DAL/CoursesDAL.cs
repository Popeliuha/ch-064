﻿using OnlineExam.Framework;
using System.Linq;


namespace OnlineExam.DatabaseHelper.DAL
{
    public class CoursesDAL
    {
        public Courses GetCourse()
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.Find();
                return result;
            }
        }

        public Courses GetCourseByCourseName(string Coursename)
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.First(c => c.Name.Equals(Coursename));
                return result;
            }
        }

        public Courses GetCourseByCourseID(string ID)
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.First(c => c.Id.ToString() == ID);
                return result;
            }
        }

        public Courses GetCourseById(int id)
        {
            using (var ctx = new DataModel(BaseSettings.fields.ConnectionString))
            {
                var result = ctx.Courses.Find(id);
                return result;
            }
        }

    }
}
