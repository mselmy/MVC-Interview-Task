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

        public IActionResult Add(Student std)
        {
            uow.StudentRepo.Add(std);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            uow.StudentRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
