using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhibernateTutorial.Controllers
{
    public class AddressController : Controller
    {
        Dao.SimpleAddressDao _addressDao = new Dao.SimpleAddressDao(MvcApplication.NHibernateSessionFactory.GetCurrentSession());

        public ActionResult Index()
        {
            _addressDao.CreateAddress(new NhibernateMappings.Address
            {
                Address1 = "Berliner Strasse",
                Address2 = "",
                City = "Essen",
                State = "NRW",
                Zipcode = "45144"
            });
            return View();
        }
    }
}