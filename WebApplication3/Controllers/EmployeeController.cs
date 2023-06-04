using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using busnisslayer;
namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
       
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.GetAllEmployess();

            return View(employees);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.GetAllEmployess().Single(emp => emp.ID == id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.UpdateEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(string name, string gender, string city, decimal Salary, DateTime dateOfBirth)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Gender = gender;
            employee.City = city;
            employee.Salary = Salary;
            employee.DateOfBirth = dateOfBirth;
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}