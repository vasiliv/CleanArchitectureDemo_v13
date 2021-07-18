using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.MVC.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PersonController(IPersonService personService, IWebHostEnvironment hostEnvironment)
        {
            _personService = personService;
            this._hostEnvironment = hostEnvironment;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    PersonViewModel model = _personService.GetPersons();
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult Index(string personSearch)
        {
            //ViewData["PersonSearch"] = personSearch;
            if (!String.IsNullOrEmpty(personSearch)) { 
                PersonViewModel model = _personService.Search(personSearch);
                return View(model);
            }
            else {
                PersonViewModel model = _personService.GetPersons();
                return View(model);
                 }
        }
        public IActionResult Create()
        {
            PersonViewModel model = _personService.GetContacts();
            ViewBag.Contact = new SelectList(model.ContactInformations ,"Id", "ContactType");
            return View();
        }
        [HttpPost]
        //[Bind("Id,FirstNameGeorgian,FirstNameLatin,SecondNameGeorgian,SecondNameLatin,IdentityNumber,BornDate,Address,ImageFile")]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
            //save image to wwwroot folder
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string FileName = Path.GetFileNameWithoutExtension(personViewModel.Person.ImageFile.FileName);
            string extension = Path.GetExtension(personViewModel.Person.ImageFile.FileName);
            personViewModel.Person.ImageName = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwrootPath + "/Images/" + FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                personViewModel.Person.ImageFile.CopyTo(fileStream);
            }
                PersonViewModel model = _personService.GetContacts();
                ViewBag.Contact = new SelectList(model.ContactInformations, "Id", "ContactType");
                _personService.Add(personViewModel);            
            return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Edit(Guid? id)
        {
            PersonViewModel model = _personService.GetPersonById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid) { 
            _personService.Update(personViewModel);            
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid? id)
        {
            PersonViewModel model = _personService.GetPersonById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                _personService.Remove(personViewModel);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
