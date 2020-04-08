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
    public partial class TakeAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["deptOriginal"] = "";
            deptInfo(sender, e);

        }

        protected void TDeptGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int16 num = Convert.ToInt16(e.CommandArgument);

                string deptName = TDeptGrid.Rows[num].Cells[2].Text;

                Session["deptOriginal"] = deptName;

                Response.BufferOutput = true;
                Response.Redirect("ViewDoctors.aspx");

                return;
            }
        }



        

        protected void deptInfo(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            DataTable DT = new DataTable();


            int status = objmyDAl.getdeptInfo(ref DT);


            if (status == -1)
            {
                TDept.Text = "Ocorreu um erro ao recuperar as informações de especialidades.";
            }

            else
            {
                TDept.Text = "Especialidades disponíveis para está Clínica : ";
                TDeptGrid.DataSource = DT;
                TDeptGrid.DataBind();
            }

            return;
        }


        





    }
}