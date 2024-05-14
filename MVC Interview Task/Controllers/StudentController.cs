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
            ViewBag.Students = uow.StudentRepo.GetAll();
            ViewBag.Subjects = uow.SubjectRepo.GetAll();
            return View();
        }

        public IActionResult Edit(int id) 
        {
            ViewBag.Subjects = uow.SubjectRepo.GetAll();
            Student std = uow.StudentRepo.GetById(id);
            return View(std);
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

        public IActionResult Update(Student std)
        {
            uow.StudentRepo.Update(std);
            return RedirectToAction("Index");
        }
    }
}
