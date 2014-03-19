using IndividueltArbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueltArbete.Pages.PatientPages
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

        public IEnumerable<Patient> PatientListView_GetData()
        {
            try
            { 
                return Service.Getpatients(); 
            }
            catch
            {

                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när patienterna skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
            
        }
    }
}
