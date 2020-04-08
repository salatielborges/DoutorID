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
    public partial class BillsHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            billHistory(sender, e);
        }


        

        protected void billHistory(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            DataTable DT = new DataTable();


            int id = (int)Session["idoriginal"];


            int status = objmyDAl.getBillHistory(id, ref DT);


            if (status == -1)
            {
                BHistory.Text = "Ocorreu algum erro ao recuperar o histórico de contas do paciente.";
            }

            else if (status == 0)
            {
                BHistory.Text = "No momento, não há seu histórico de faturamento.";
            }

            else
            {
                BHistory.Text = status + " Faturas encontradas: ";
                BHistoryGrid.DataSource = DT;
                BHistoryGrid.DataBind();
            }

            return;
        }


        


    }

}