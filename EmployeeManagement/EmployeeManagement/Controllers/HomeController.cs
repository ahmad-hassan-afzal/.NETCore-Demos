using EmployeeManagement.Models;
using EmployeeManagement.Security;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    //[Route("[controller]")]
    [Authorize]
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDataProtector protector;

        public HomeController(IEmployeeRepository employeeRepository,
                              IHostingEnvironment hostingEnvironment,
                              IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));

            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }
        //[Route("")]
        //[Route("/")]
        //[Route("[action]")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees()
                                        .Select(e =>
                                        {
                                            e.EncryptedId = protector.Protect(e.Id.ToString());
                                            return e;
                                        });
            return View(model);
        }

        //[Route("[action]/{Id?}")]
        [AllowAnonymous]
        public ViewResult Details(string? Id)
        {
            //throw new Exception("Exception");

            int empId = Convert.ToInt32(protector.Unprotect(Id));

            Employee employee = _employeeRepository.GetEmployee(empId);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", empId);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = employee;
            return View(homeDetailsViewModel);
        }

        //[Route("[action]")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = await ProcessUploadedFileAsync(model);
                Employee employee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFilename
                };
                Employee new_employee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = employee.Id });
            }
            else
            {
                return View();
            }
        }

        //[Route("[action]/{Id?}")]
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        //[Route("[action]/{Id?}")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = await ProcessUploadedFileAsync(model);
                }

                Employee new_employee = _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        private async Task<string> ProcessUploadedFileAsync(EmployeeCreateViewModel model)
        {
            string uniqueFilename = null;
            if (model.Photo != null)
            {
                string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolderPath, uniqueFilename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }
            }

            return uniqueFilename;
        }

        //[Route("[action]/{Id?}")]
        public string Delete (int? id)
        {
            return "Delete: " + (id ?? 1);
        }
    }
}
