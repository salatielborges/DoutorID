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
    public partial class PatientNotifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Notifications(sender, e);
        }



        
        
        protected void Notifications(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            int pid = (int)Session["idoriginal"];

            string dName = "";
            string timings = "";

            int status = objmyDAl.getNotifications(pid, ref dName, ref timings);

            if (status == -1)
            {
                Notify.Text = "Ocorreu algum erro ao recuperar as notificações do paciente.";
            }

            else if (status == 0)
            {
                Notify.Text = "Não há novas notificações :)";
            }

            else
            {
                if (status == 1)
                {
                    NDoctor.Text = "Sua consulta solicitada com o médico " + dName + " foi agendada! :)";
                    NTimings.Text = "O horário da consulta é : " + timings;
                    return;
                }

                else if (status == 2)
                {
                    NDoctor.Text = "Sua consulta solicitada com o médico " + dName + " foi cancelada! :(";
                    NTimings.Text = "O horário da consulta era : " + timings;
                    return;
                }

                else if (status == 3)
                {
                    NDoctor.Text = "Sua consulta solicitada com o médico " + dName + " foi realizada. Esperamos que você esteja se sentindo melhor agora!";
                    NTimings.Text = "O horário da consulta foi : " + timings;
                    return;
                }

                return;
            }
        }

    
        















    }
}