using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDocumentService.Models.EnityFrameWork;
using StaffDocumentService.Security;
using NHibernate;
using EmployeeDocumentService.Models.Nhibernate;
using NHibernate.Linq;

namespace EmployeeDocumentService.Models
{
    public class Data
    {
        EncryptMd5 Enmd5 = new EncryptMd5();
        DecryptionMd5 demd5 = new DecryptionMd5();


        //// =================================Entity===============================//
        public bool CheckID(EmployeeDoc EmpId)
        {
            using (SADEntities1 db = new SADEntities1())
            {
                if (db.Employees.Any(p => p.ID == EmpId.ID))
                {
                    return true;
                }
                return false;
            }
        }

        public Employee InsertInfor(EmployeeDoc employeeinfor)
        {
            using (SADEntities1 db = new SADEntities1())
            {
                Employee employee = new Employee();
                employee.ID = employeeinfor.ID;
                employee.Name = employeeinfor.Name;
                employee.Department = employeeinfor.Department;
                employee.Salary = Enmd5.Encrypt(employeeinfor.Salary);
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }
        public List<EmployeeDoc> GetAllInfor()
        {

            List<EmployeeDoc> EmployeeList = new List<EmployeeDoc>();


            using (SADEntities1 db = new SADEntities1())
            {
                var emp = db.Employees.ToList();
                foreach (var item in emp)
                {

                    EmployeeList.Add(new EmployeeDoc
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Department = item.Department,
                        Salary = demd5.Decrypt(item.Salary)
                    });
                }
            }

            return EmployeeList;
        }


        ////===================================Nhibernate===================================================================//
        //public List<EmployeeDoc> GetAllInfor()
        //{
        //    //var sessin = NHibernateHelper.OpenSession();
        //    //var list = sessin.Query<EmployeeDoc>().ToList();
        //    List<EmployeeDoc> EmployeeList = new List<EmployeeDoc>();
        //    using (var session = NHibernateHelper.OpenSession())
        //    {
        //        var emp = session.Query<EmployeeDoc>().ToList();
        //        foreach (var item in emp)
        //        {
        //            EmployeeList.Add(new EmployeeDoc
        //            {
        //                ID = item.ID,
        //                Name = item.Name,
        //                Department = item.Department,
        //                Salary = demd5.Decrypt(item.Salary)
        //                //Salary = item.Salary
        //            });
        //        }

        //    }
        //    return EmployeeList;
        //}

        //public bool CheckID(EmployeeDoc EmpId)
        //{
        //    using (ISession session = NHibernateHelper.OpenSession())
        //    {
        //        bool exist = session.Query<EmployeeDoc>().Any(x => x.ID == EmpId.ID);
        //        return exist;
        //    }
        //}

        //public Employee InsertInfor(EmployeeDoc employeeinfor)
        //{

        //    Employee employee = new Employee();
        //    using (ISession session = NHibernateHelper.OpenSession())
        //    {
        //        using (var trans = session.BeginTransaction())
        //        {

        //            employeeinfor.Salary = Enmd5.Encrypt(employeeinfor.Salary);
        //            session.SaveOrUpdate(employeeinfor);
        //            trans.Commit();
        //            return employee;
        //        }
        //    }


    }

    }
