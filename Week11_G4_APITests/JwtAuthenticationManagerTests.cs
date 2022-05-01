using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week11_G4_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_G4_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Week11_G4_API.Data;
using Week11_G4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Week11_G4_API.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("notalegitstringtopass");

            User user = new User
            {
                username = "test",
                password = "password"
            };

            var test = manager.Authenticate(user.username, user.password);

            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void InstructorsTest()
        {
            //INSERT access
            Instructor addInst = new Instructor();
            addInst.InstructorId = "5";
            addInst.InstructorFirstName = "TestIntr";
            addInst.InstructorLastName = "TestIntrlast";
            addInst.InstructorEmail = "nobodyEmail@gmail.com";
            addInst.InstructorSalary = 100000;
            InstructorsController prsper = new InstructorsController("notalegitstringtopass");

            prsper.PutInstructor("5498456", addInst);

            var req = prsper.GetInstructor("6");

            prsper.DeleteInstructor("6");

            Assert.IsNotNull(req);
        }

        [TestMethod()]
        public void CreditTest()
        {
            //Checks for record with specific ID
            CreditsController cred = new CreditsController("notalegitstringtopass");

            var r = cred.GetCredit("C001");

            Assert.IsNotNull(r);
        }

        [TestMethod()]
        public void StudentsTest()
        {
            //DELETE access
            StudentsController stud = new StudentsController("stillnotalegitstringtopass");

            stud.DeleteStudent("S007");

            Student addStud = new Student();

            addStud.StudentId = "S010";
            addStud.StudentFirstName = "Travis";
            addStud.StudentLastName = "Monsuke";
            addStud.StudentEmail = "travmonsuke@gmail.com";
            addStud.StudentPhoneNumber = "555-525-2352";

            var rep = stud.GetStudent("S007");

            stud.PutStudent("552231", addStud);

            Assert.IsNotNull(rep);
        }

        [TestMethod()]
        public void CoursesTest()
        {
            CoursesController cur = new CoursesController("notalegitstringtopass");
            var res = cur.GetCourses();

            Assert.IsNotNull(res);
        }
    }
}