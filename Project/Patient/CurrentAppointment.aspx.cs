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
    public partial class CurrentAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            appointmentToday(sender, e);
        }




        protected void appointmentToday(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();

            int pid = (int)Session["idoriginal"];

            string dName = "";
            string timings = "";

            int status = objmyDAl.appointmentTodayDisplayer(pid, ref dName, ref timings);

            if (status == -1)
            {
                Appointment.Text = "Ocorreu algum erro ao recuperar a consulta do paciente.";
            }

            else if (status == 0)
            {
                Appointment.Text = "Hoje você não tem consulta com nenhum médico.";
            }

            else
            {
                if (status == 3)
                {
                    ADoctor.Text = "Você teve uma consulta atrasada com o médico " + dName + " ao qual ele não respondeu. Portanto, essa consulta será cancelada.";
                    ATimings.Text = "o horário da consulta era : " + timings;
                    return;
                }

                else if (status == 2)
                {
                    ADoctor.Text = "Você solicitou agendar uma consulta com o Doutor " + dName + " que ainda não foi aprovada por ele.";
                }

                else
                {
                    ADoctor.Text = "Hoje você tem uma consulta com Doutor " + dName;
                }

                ATimings.Text = "O horário da consulta é : " + timings;
            }

            return;
        }


        






    }
}