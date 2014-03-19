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
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["a"] != null)
            {
                LabelOk.Text = Convert.ToString(Session["a"]);
                OkDiv.Visible = true;
                Session.Remove("a");
            }
        }

        public IEnumerable<IndividueltArbete.Model.Doctor> PatientListView_GetData()
        {
            try
            {
                return Service.GetpDoctors();
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när läkarna skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
        }

        public IEnumerable<DoctorType> DoctorTypeDropDownList_GetData()
        {
            try
            {
                return Service.GetDoctorType();
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när läkartyperna skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
        }

        public void PatientListView_InsertItem(Doctor doctor)
        {

                try
                {
                    var service = new Service();
                    service.AddDoctor(doctor);
                    Session["a"] = "Läkaren har blivit upplagd!!!";
                    Response.Redirect("~/Pages/DoctorPages/Listing.aspx");
                }
                catch
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Ett fel inträffade när läkaren skulle läggas up";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                }
        }


        public void PatientListView_DeleteItem(int DoctorID)
        {
            try
            {
                Service.DeleteDoctor(DoctorID);
                Session["a"] = "Läkaren har blivit bortagen!!!";
                Response.Redirect("~/Pages/DoctorPages/Listing.aspx");
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när läkaren skulle raderas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
        }

        public void PatientListView_UpdateItem(int DoctorID)
        {
            var doctor = Service.GetDoctor(DoctorID);
            if (doctor == null)
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när kontakten skulle uppdateras";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
            if (TryUpdateModel(doctor))
            {
                Service.UpdateDoctor(doctor);
                Session["a"] = "Läkaren har blivit uppdaterad!!!";
                Response.Redirect("~/Pages/DoctorPages/Listing.aspx");
            }
        }
    }
}