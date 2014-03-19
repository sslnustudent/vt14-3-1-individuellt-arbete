using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IndividueltArbete.App_Start
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("PatientListing", "", "~/Pages/PatientPages/Listing.aspx");
            routes.MapPageRoute("PatientCreate", "patienter/ny", "~/Pages/PatientPages/Create.aspx");
            routes.MapPageRoute("PatientDetails", "patienter/{id}", "~/Pages/PatientPages/Details.aspx");
            routes.MapPageRoute("PatientEdit", "patienter/{id}/edit", "~/Pages/PatientPages/Edit.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/PatientPages/Listing.aspx");
            routes.MapPageRoute("DoctorListing", "Läkare", "~/Pages/DoctorPages/Listing.aspx");

        }
    }
}