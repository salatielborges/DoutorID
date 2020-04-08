using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;


namespace DBProject
{
    public partial class ViewDoctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["dID"] = "";
            deptDoctorInfo(sender, e);
        }

        
        protected void TDoctorGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int16 num = Convert.ToInt16(e.CommandArgument);

                string dID = TDoctorGrid.Rows[num].Cells[2].Text;
  
                Session["dID"] = dID;

                Response.BufferOutput = true;
                Response.Redirect("DoctorProfile.aspx");

                return;
            }
        }



        

        protected void deptDoctorInfo(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            DataTable DT = new DataTable();

            string deptName = (string) Session["deptOriginal"];

            int status = objmyDAl.getDeptDoctorInfo(deptName, ref DT);


            if (status == -1)
            {
                TDoctor.Text = "Ocorreu algum erro ao recuperar as informações do médico.";
            }

            else
            {
                TDoctor.Text = "Médicos especializados em " + Session["deptOriginal"] + " Especialidade(s):";
                TDoctorGrid.DataSource = DT;
                TDoctorGrid.DataBind();
            }

            return;
        }


        
    }
}