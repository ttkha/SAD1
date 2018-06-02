using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecruitmentService.Models;

namespace RecruitmentService.Controllers
{
    public class RecruitmentController : ApiController
    {
        public List<Recruitment> GetCandidate()

        {
            Data data = new Data();
            List<Recruitment> listrecruitment = data.GetInf();
            return listrecruitment;
        }




       
    }
}
