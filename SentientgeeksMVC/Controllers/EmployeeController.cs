using SentientgeeksMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SentientgeeksMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmpDataContext objDataContext = new EmpDataContext();

        #region Employee Details
        [HttpGet]
        public ActionResult Empdetails()
        {
            return View(objDataContext.employees.ToList());
        }
        #endregion

        #region Insert Employee
        [HttpGet]
        public ActionResult create()
        {
            return PartialView("_PartialCreate");
        }
        [HttpPost]
        public ActionResult create(Employee objEmp)
        {
           
                try
                {
                    if (string.IsNullOrWhiteSpace(objEmp.Name))
                    {

                        Response.Write("<script>Name not declare</script>");
                    }
                    else if (string.IsNullOrWhiteSpace(objEmp.Email))
                    {
                        return Content("Email not declare");
                    }
                    else if (string.IsNullOrWhiteSpace(objEmp.Address))
                    {
                        return Content("Address Not Declare");
                    }
                    else if (string.IsNullOrWhiteSpace(objEmp.Phoneno))
                    {
                        return Content("Phoneno Not Declare");
                    }
                    else
                    {
                        objDataContext.employees.Add(objEmp);
                        objDataContext.SaveChanges();
                        return RedirectToAction("Empdetails");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
             
            return RedirectToAction("Empdetails");
        }

        #endregion

        #region Details
        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        #endregion

        #region Edit/Update
        [HttpGet]
        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp1 = objDataContext.employees.Find(empId);
            
            return PartialView("_PartialCreate",emp1);
        }

        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
            var data = objDataContext.employees.Find(objEmp.EmpId);
            if (data != null)
            {
                data.Name = objEmp.Name;
                data.Email = objEmp.Email;
                data.Address = objEmp.Address;
                data.Phoneno = objEmp.Phoneno;
            }
            objDataContext.SaveChanges();
            return RedirectToAction("Empdetails");
        }
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            int empId = (id);
            var emp = objDataContext.employees.Find(empId);
            return PartialView("_PartialDelete", emp);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            objDataContext.employees.Remove(emp);
            objDataContext.SaveChanges();
            return RedirectToAction("Empdetails");
        }

        [HttpPost]
        public ActionResult DeleteAll(int[] eids)
        {
            if (eids != null)
            {
                foreach (int eid in eids)
                {
                    var emp = objDataContext.employees.Find(eid);
                    objDataContext.employees.Remove(emp);
                }
                objDataContext.SaveChanges();
                return Json("All the customers deleted successfully!");

            }
            else
            {
                Response.Write("<script>alert('Please select checkbox which data you wants to delete');</script>");
            }
            return RedirectToAction("Empdetails");
        }
        #endregion
    }
}