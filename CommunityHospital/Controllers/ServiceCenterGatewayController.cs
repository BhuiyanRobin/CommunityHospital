using System.Linq;
using System.Web.Mvc;
using CommunityHospital.Models;

namespace CommunityHospital.Controllers
{
    public class ServiceCenterGatewayController : Controller
    {
        ServiceCenterGateway aCenterGateway = new ServiceCenterGateway();

        public ActionResult FindThisDistrict(int districtId)
        {
            ViewBag.districtId = districtId;
            var relations = aCenterGateway.Relations.Where(x => x.DistrictId == districtId).ToList();

            var prQuery = (aCenterGateway.Relations.Join(aCenterGateway.Thanas, p => p.ThanaId, prd => prd.ThanaId,
                (p, prd) => new { p, prd }).Where(@t => @t.p.DistrictId == districtId).Select(@t => new
                {
                    @t.prd.ThanaId,
                    @t.prd.Name
                })).ToList();

            //var relations = aCenterGateway.Relations.Where(x => x.DistrictId == districtId).ToList();

            //var prQuery = (from p in aCenterGateway.Relations
            //               join prd in aCenterGateway.Thanas on p.ThanaId equals prd.ThanaId
            //               where p.DistrictId == districtId
            //               select new
            //               {
            //                   prd.ThanaId,
            //                   prd.Name
            //               }).ToList();

            return Json(prQuery, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindServiceCenter(int thanaId)
        {
            ViewBag.thanaId = thanaId;
            var serviceCenters = (from p in aCenterGateway.ServiceCenters
                where p.ThanaId == thanaId
                select new
                {
                    Name = p.Name,
                    ServiceCenterId = p.ServiceCenterId,
                });
            
                
            return Json(serviceCenters, JsonRequestBehavior.AllowGet);
        }
    }


}