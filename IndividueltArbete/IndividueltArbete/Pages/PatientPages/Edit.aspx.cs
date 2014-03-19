using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using IndividueltArbete.Model;

namespace IndividueltArbete.Pages.PatientPages
{
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public IndividueltArbete.Model.Patient PatientFormView_GetItem([RouteData]int id)
        {
            var service = new Service();
            try
            {
                return service.GetPatient(id);
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när patienten skulle skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PatientFormView_UpdateItem(int PatientID)
        {
            try
            {
                var patient = Service.GetPatient(PatientID);
                if (patient == null)
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Patiensen kunde inte hittas";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                    return;
                }

                if (TryUpdateModel(patient))
                {
                    
                    Service.UpdatePatient(patient);
                    Session["a"] = "Patienten har Ändrats!!!";
                    Response.Redirect(GetRouteUrl("PatientDetails", new { id = patient.PatientID }));
                }
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när patienten skulle skulle uppdateras";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
        }

        public IEnumerable<Doctor> DoctorDropDownList_GetData()
        {
            return Service.GetpDoctors();
        }

    }
}