using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Models;
using DataAccessLayer.UniteOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Interview_Task.Controllers
{
    public class StudentController : Controller
    {
        readonly IUnitOfWork uow;

        public StudentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Students = await uow.StudentRepoInc.GetAll();
            ViewBag.Subjects = await uow.SubjectRepo.GetAll();
            return View();
        }

        public async Task<IActionResult> Edit(int id) 
        {
            ViewBag.Subjects = await uow.SubjectRepo.GetAll();
            Student std = await uow.StudentRepoInc.GetById(id);
            return View(std);
        }

        public async Task<IActionResult> Add(StudentDTO std)
        {
            // Create a new student
            var student = new Student
            {
                Name = std.Name,
                Date = std.Date,
                Address = std.Address
            };

            // Add the selected subjects to the student
            foreach (var subjectId in std.SelectedSubjectIds)
            {
                student.StudentSubjects.Add(new StudentSubject
                {
                    SubjectId = subjectId,
                    StudentId = student.Id,
                    Student = student,
                    Subject = await uow.SubjectRepo.GetById(subjectId)
                });
            }

            // Add the student to the database
            await uow.StudentRepo.Add(student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            // Delete the student from the database
            await uow.StudentRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(StudentDTO std)
        {
            var student = await uow.StudentRepoInc.GetById(std.Id);

            // Update the student's properties
            student.Name = std.Name;
            student.Date = std.Date;
            student.Address = std.Address;

            // Clear the student's subjects
            student.StudentSubjects.Clear();

            // Add the selected subjects to the student
            foreach (var subjectId in std.SelectedSubjectIds)
            {
                student.StudentSubjects.Add(new StudentSubject
                {
                    SubjectId = subjectId,
                    StudentId = student.Id,
                    Student = student,
                    Subject = await uow.SubjectRepo.GetById(subjectId)
                });
            }

            await uow.StudentRepo.Update(student);
            return RedirectToAction("Index");
        }
    }
}
