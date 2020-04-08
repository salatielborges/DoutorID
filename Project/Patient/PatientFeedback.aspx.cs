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
    public partial class PatientFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				Session["aID"] = "";
				pendingFeedback(sender, e);
			}
        }



        
        

        protected void pendingFeedback(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            int pid = (int)Session["idoriginal"];

            string dName = "";
            string timings = "";

            int aID = 0;

            int status = objmyDAl.isFeedbackPending(pid, ref dName, ref timings, ref aID);

            if (status == -1)
            {
                Feedback.Text = "Ocorreu um erro ao recuperar os comentários pendentes.";
            }

            else if (status == 0)
            {
                Feedback.Text = "Não há feedbacks pendentes :)";
            }

            else
            {
                Session["aID"] = aID;

                FDoctor.Text = "Sua opinião sobre a consulta com o Doctor " + dName + " esta pendente por favor nos de sua opnião!.";
                FTimings.Text = "Sua consulta foi : " + timings;

                
                Message.Visible = true;
                List.Visible = true;
                button1.Visible = true;

                return;
            }
        }




        

        protected void giveFeedback(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            int aID = (int)Session["aID"];


            int rating = Convert.ToInt32(List.SelectedItem.Value);


            int status = objmyDAl.givePendingFeedback(aID);

            if (status == -1)
            {
                F.Text = "Ocorreu algum erro.";
            }

            else if (status == 0)
            {
                F.Text = "Obrigado pelo seu feedback :)";
            }

            return;
        }



        



    }
}