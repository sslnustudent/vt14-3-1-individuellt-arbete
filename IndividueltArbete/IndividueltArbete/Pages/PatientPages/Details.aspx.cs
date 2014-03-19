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
    public partial class Details : System.Web.UI.Page
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
        public IndividueltArbete.Model.Patient PatientFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetPatient(id);
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
        public void PatientFormView_DeleteItem(int PatientID)
        {
            try
            {
                Service.DeletePatient(PatientID);
                Session["a"] = "Patienten har blivit raderad!!!";
                Response.Redirect("~/Pages/PatientPages/Listing.aspx");
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när patienten skulle raderas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
        
        }
    }
}