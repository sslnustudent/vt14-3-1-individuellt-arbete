using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndividueltArbete.Model;

namespace IndividueltArbete.Pages.PatientPages
{
    public partial class Create : System.Web.UI.Page
    {
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Doctor> DoctorDropDownList_GetData()
        {
            return Service.GetpDoctors();
        }

        public void FormView1_InsertItem(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.AddPatient(patient);
                    Session["a"] = "Patienten har sparats!!!";
                    Response.Redirect("~/Pages/PatientPages/Listing.aspx");
                }
                catch
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Ett fel inträffade när patienten skulle skulle skapas";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                }
            }
        }
    }
}