﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirmManagment.Models;
using WebFirmManagment.Models.Entities;
using WebFirmManagment.Models.ViewModels;

namespace WebFirmManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private FirmManagementContext db = new FirmManagementContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,WorkPermitDate,Gender,isOperator,Workplace,Hobbies,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,WorkPermitDate,Gender,isOperator,Workplace,Hobbies,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            EmployeeSearch model = new EmployeeSearch();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search([Bind(Include = "GenderString,NameString,WorkplaceString,HobbyString")] EmployeeSearch search)
        {
            var allUsers = db.Employees.ToList();
            List<Employee> finalList = new List<Employee>();

            if (!String.IsNullOrEmpty(search.NameString))
            {
                List<Employee> firstNameQuery = allUsers.Where(m => m.FirstName.Contains(search.NameString)).ToList<Employee>();
                List<Employee> lastNameQuery = allUsers.Where(m => m.LastName.Contains(search.NameString)).ToList<Employee>();

                firstNameQuery.AddRange(lastNameQuery);
                finalList = firstNameQuery;
            }

            if (!String.IsNullOrEmpty(search.HobbyString))
            {
                List<Employee> hobbyQuery = allUsers.Where(m => m.Hobbies.Contains(search.HobbyString)).ToList<Employee>();
                if (finalList.Any())
                    finalList.Union<Employee>(hobbyQuery);
                else
                    finalList = hobbyQuery;
            }

            EmployeeSearch model = new EmployeeSearch
            {
                SearchedEmployees = finalList
            };
                return View(model);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
