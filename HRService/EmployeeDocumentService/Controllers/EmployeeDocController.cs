using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDocumentService.Models;

namespace EmployeeDocumentService.Controllers
{
    public class EmployeeDocController : ApiController
    {
        public IEnumerable<EmployeeDoc> GetEmployee()
        {
            Data data = new Data();
            var listEmployee = data.GetAllInfor();
            return listEmployee;
        }

        public HttpResponseMessage CreateNewInfor(HttpRequestMessage request, EmployeeDoc Employeeinfor)
        {

            Data data = new Data();
            if (data.CheckID(Employeeinfor) == true)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.OK, data.InsertInfor(Employeeinfor));
            }


        }

    }
}
