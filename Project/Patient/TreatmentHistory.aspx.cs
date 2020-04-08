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
    public partial class TreatmentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            treatmentHistory(sender, e);
        }



        protected void treatmentHistory(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            DataTable DT = new DataTable();


            int id = (int)Session["idoriginal"];


            int status = objmyDAl.getTreatmentHistory(id, ref DT);


            if (status == -1)
            {
                THistory.Text = "Ocorreu algum erro ao recuperar o histórico de tratamento do paciente.";
            }

            else if (status == 0)
            {
                THistory.Text = "Você não tem histórico de tratamentos.";
            }

            else
            {
                THistory.Text = "Histórico de tratamento " + status + " Fatura(s) encontrada(s) ";
                THistoryGrid.DataSource = DT;
                THistoryGrid.DataBind();
            }

            return;
        }
        

        




    }
}