using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParentChildrenApp.Models;
using ParentChildrenApp.Models.DTO;
using ParentChildrenApp.Repository;
using System.Linq;

namespace ParentChildrenApp.Controllers
{
    public class ChildController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChildrenRepository _childRepository;
        private readonly IWebHostEnvironment _env;

        public ChildController(ILogger<HomeController> logger, IChildrenRepository childRepository, IWebHostEnvironment env)
        {
            _logger = logger;
            _childRepository = childRepository;
            _env= env;
        }

        public IActionResult Index()
        {
            List<ChildModel> children = new List<ChildModel>();
            int parentId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            children = _childRepository.GetMyChildren(parentId);
            if(children.Count>0)
                return View(children);
            else
                return View();
        }
       

        // GET: Child/AddChildren    
        public ActionResult AddChildren()
        {
            return View();
        }

        // POST: Child/AddChildren    
        [HttpPost]
        public ActionResult AddChildren(ChildModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ChildDTO child = new ChildDTO();
                    child.NoOfChild = Emp.NoOfChild;
                    child.ParentId= Convert.ToInt32(HttpContext.Session.GetString("userId"));
                    child.FirstName= Emp.FirstName;
                    child.LastName= Emp.LastName;
                    child.Age= Emp.Age;
                    child.Gender= Emp.Gender;
                    string uniuefilename = string.Empty;

                    if (Emp?.Image != null)
                    {
                        string folderpath = Path.Combine(_env.WebRootPath, "images");
                        uniuefilename = Guid.NewGuid() + "_" + Emp?.Image?.FileName?.Split("\\").LastOrDefault();
                        string FilePath = Path.Combine(folderpath, uniuefilename);
                        Emp.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                    child.Photo= uniuefilename;
                    bool result = _childRepository.AddChildren(child);
                    if (result)
                    {
                        ViewBag.Message = "Child details added successfully";
						return RedirectToAction("Index");
					}
                    else
                    {
                        ViewBag.Message = "Some error occurred while adding Child info!";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Child/EditChildDetails/5
        [HttpGet]
        public ActionResult EditChildDetails(int id)
        {
            int parentId = Convert.ToInt32(HttpContext.Session.GetString("userId"));

            return View(_childRepository.GetMyChildren(parentId).Find(c=>c.Id == id));

        }

        // POST: Child/EditChildDetails/5    
        [HttpPost]

        public ActionResult EditChildDetails(int id, ChildModel obj)
        {
            try
            {
                string uniuefilename = string.Empty;
                ChildDTO child = new ChildDTO();
                child.Id = id;
                child.NoOfChild = obj.NoOfChild;
                child.ParentId = obj.ParentId;
                child.FirstName = obj.FirstName;
                child.LastName = obj.LastName;
                child.Age = obj.Age;
                child.Gender = obj.Gender;
                child.Photo = obj.Photo;
				if (obj?.Image != null)
                {
                    string folderpath = Path.Combine(_env.WebRootPath, "images");
                    uniuefilename = Guid.NewGuid() + "_" + obj?.Image?.FileName?.Split("\\").LastOrDefault();
                    string FilePath = Path.Combine(folderpath, uniuefilename);
                    obj.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
					child.Photo = uniuefilename;
				}
                bool result = _childRepository.EditChildren(child);
                if(result)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Child/DeleteChild/5    
        public ActionResult DeleteChild(int id)
        {
            try
            {
                bool result = _childRepository.DeleteChildren(id);
                if (result)
                {
                    ViewBag.AlertMsg = "Child details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
