using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruitmentService.Models.entityframework;

namespace RecruitmentService.Models
{
    public class Data
    {
        public List<Recruitment> GetInf()
        {

            List<Recruitment> RecruitmentList = new List<Recruitment>();


            using (SADEntities1 db1 = new SADEntities1())
            {
                var rec = db1.Candidates.ToList();
                foreach (var item in rec)
                {

                    RecruitmentList.Add(new Recruitment
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Address = item.Address,
                        Email = item.Email,
                        Phone = item.Phone

                    });
                }
            }
            return RecruitmentList;
        }
    }
}