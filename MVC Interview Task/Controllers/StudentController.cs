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

        public IActionResult Index()
        {
            var students = uow.StudentRepo.GetAll();
            ViewBag.Students = students;
            ViewBag.Subjects = uow.SubjectRepo.GetAll();
            return View();
        }

        public void Add(Student std)
        {
            uow.StudentRepo.Add(std);
        }
    }
}
