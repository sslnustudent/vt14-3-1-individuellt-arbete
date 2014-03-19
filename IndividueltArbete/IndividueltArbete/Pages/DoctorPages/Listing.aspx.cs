using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IndividueltArbete.Model;

namespace IndividueltArbete.Pages.DoctorPages
{
    public partial class Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<IndividueltArbete.Model.Doctor> PatientListView_GetData()
        {
            var service = new Service();
            return service.GetpDoctors();
        }

        public IEnumerable<DoctorType> DoctorTypeDropDownList_GetData()
        {
            var service = new Service();
            return service.GetDoctorType();
        }

        public void PatientListView_InsertItem(Doctor doctor)
        {

                try
                {
                    var service = new Service();
                    service.AddDoctor(doctor);
                    //Session["a"] = "Kontakten har blivit upplagd!!!";
                    //Response.Redirect("~/Default.aspx");
                }
                catch
                {
                    //CustomValidator cv = new CustomValidator();
                    //cv.ErrorMessage = "Ett fel inträffade när kontakten skulle läggas up";
                    //cv.IsValid = false;
                    //Page.Validators.Add(cv);
                }
            
        }


        public void PatientListView_DeleteItem(int DoctorID)
        {
            var service = new Service();
            service.DeleteDoctor(DoctorID);
        }

        public void PatientListView_UpdateItem(int DoctorID)
        {
            var service = new Service();
            
            var doctor = service.GetDoctor(DoctorID);
            if (doctor == null)
            {
                CustomValidator cv = new CustomValidator();
                //cv.ErrorMessage = "Ett fel inträffade när kontakten skulle uppdateras";
                //cv.IsValid = false;
                //Page.Validators.Add(cv);
            }
            if (TryUpdateModel(doctor))
            {
                service.UpdateDoctor(doctor);
                //Session["a"] = "Kontakten har blivit uppdaterad!!!";
                //Response.Redirect("~/Default.aspx");
            }
        }
    }
}