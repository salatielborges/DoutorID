using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

 
namespace DBProject.DAL
{
	//Camada de banco de dados de arquitetura de três camadas
	public class myDAL
    {
		//cadeia de conexão do banco de dados do servidor
		private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;






		//-----------------------------------------------------------------------------------//
		//																					 //
		//									LOGIN / CADASTRO											 //
		//																					 //
		//-----------------------------------------------------------------------------------//



		/*VERIFICA SE É UM USUÁRIO VÁLIDO E DEVOLVE SEU TIPO*/
		public int validateLogin (string Email, string Password, ref int type , ref int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                SqlCommand cmd1 = new SqlCommand("Login", con);     
                cmd1.CommandType = CommandType.StoredProcedure;

				


				cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password; 

                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@type", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();
				
                int status = (int)cmd1.Parameters["@status"].Value;
                type = (int)cmd1.Parameters["@type"].Value;
                id = (int)cmd1.Parameters["@ID"].Value;

                return status;
            }

            catch(SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();   
            }
        }






		/*ESTA FUNÇÃO VALIDARÁ TODAS AS INFORMAÇÕES DO USUÁRIO (PACIENTE)*/
		public int validateUser (string Name, string BirthDate, string Email , string Password , string PhoneNo , string gender , string Address, ref int id)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                


                SqlCommand cmd1 = new SqlCommand("PatientSignup", con);              
                cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = Name;
				cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = Address;
				cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
				cmd1.Parameters.Add("@date", SqlDbType.Date).Value = BirthDate;
				cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
				cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;
				cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Value = PhoneNo;
				
                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				
                cmd1.ExecuteNonQuery();           

                int status = (int)cmd1.Parameters["@status"].Value;

                if (status != 0)
                {
                    id = (int)cmd1.Parameters["@ID"].Value;
                }


                return status; 
            }

            catch(SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();   
            }
        }







		//-----------------------------------------------------------------------------------//
		//                                                                                   //
		//                                       ADMIN                                       //
		//                                                                                   //
		//-----------------------------------------------------------------------------------//



		/*ESTA FUNÇÃO VERIFICA SE O E-MAIL DE UM MÉDICO JÁ EXISTE NA BASE DE DADOS*/

		public int DoctorEmailAlreadyExist(string Email)
        {
            int status = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();


          


            SqlCommand cmd = new SqlCommand("CheckDoctorEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = Email;
            cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            status = (int)cmd.Parameters["@status"].Value;
            con.Close();

            return status;
        }







		/*ESTA FUNÇÃO ADICIONARÁ O DOUTOR À BASE DE DADOS */
		public void AddDoctor(string Name, string Clinic, string Email, string Password, string BirthDate, int dept, string Phone, char gender, string Address, int exp, int salary, int Charges_per_visit, string spec, string qual)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();


            SqlCommand cmd = new SqlCommand("AddDoctor", con);
            cmd.CommandType = CommandType.StoredProcedure;

           

            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
			cmd.Parameters.Add("@Clinic", SqlDbType.VarChar, 40).Value =Clinic;
			cmd.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = Email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30).Value = Password;
            cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = BirthDate;
            cmd.Parameters.Add("@dept", SqlDbType.VarChar, 30).Value = dept;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = Address;
            cmd.Parameters.Add("@Exp", SqlDbType.VarChar, 30).Value = exp;
            cmd.Parameters.Add("@Salary", SqlDbType.VarChar, 30).Value = salary;
            cmd.Parameters.Add("@charges", SqlDbType.VarChar, 30).Value = Charges_per_visit;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 30).Value = Phone;
            cmd.Parameters.Add("@spec", SqlDbType.VarChar, 30).Value = spec;
            cmd.Parameters.Add("@qual", SqlDbType.VarChar, 30).Value = qual;

            cmd.ExecuteNonQuery();
            con.Close();


        }





        
        public int AddStaff(string Name, string BirthDate, string Phone, char gender, string Address, int salary, string Qual, string Designation)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand cmd = new SqlCommand("AddStaff", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {


                
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
                cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = BirthDate;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 30).Value = Phone;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
                cmd.Parameters.Add("@salary", SqlDbType.Int, 30).Value = salary;
                cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 30).Value = Designation;
                cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 1).Value = Qual;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;

                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            con.Close();
            return 1;

        }







        public void GetAdminHomeInformation(ref DataTable[] arrTable)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();


            SqlCommand cmd = new SqlCommand("SELECT * FROM Total_Patient", con);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(arrTable[0]);

            cmd.CommandText = "SELECT * FROM Total_Doctors";
            Adapter.Fill(arrTable[1]);

            cmd.CommandText = "SELECT * FROM Income";
            Adapter.Fill(arrTable[2]);

            cmd.CommandText = "SELECT * FROM Department_View";
            Adapter.Fill(arrTable[3]);

            cmd.CommandText = "SELECT * FROM Appointment_view";
            Adapter.Fill(arrTable[4]);


            con.Close();

        }






        public int DeleteDoctor(int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            con.Close();
            return 1;

        }



        public int DeleteStaff(int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DELETESTAFF", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            return 1;
        }


        public void LoadDoctor(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand(
				"SELECT Doctor.DoctorID as ID , Doctor.Name , Doctor.Clinic , D.DeptName as Department FROM Doctor JOIN Department D ON D.DeptNo = Doctor.DeptNo" +
                " WHERE Doctor.Status = 1",
                con);

            }
            else
            {
                cmd = new SqlCommand(
                "SELECT a.DoctorID as ID,  a.Name, D.DeptName as Department FROM department D join (SELECT * FROM Doctor WHERE Doctor.Status = 1 AND Doctor.Name like  '%' + @DName + '%')  a ON a.DeptNo = D.DeptNo",
                con);
                cmd.Parameters.AddWithValue("@DName", SearchQuery);
            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }






        
        public void LoadPatient(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand("SELECT * FROM PATIENT_VIEW", con);

            }
            else
            {
                cmd = new SqlCommand("SELECT Patient.PatientID, Patient.Name, Patient.Phone from Patient" +
                " WHERE patient.name like '%' + @SName + '%' ", con);
                cmd.Parameters.AddWithValue("@SName", SearchQuery.Trim());

            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }





		
		public void LoadOtherStaff(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand("SELECT * FROM STAFF_VIEW", con);

            }
            else
            {
                cmd = new SqlCommand("SELECT StaffID as ID , Name , Designation from OtherStaff WHERE Name like '%' + @pName + '%'", con);
                cmd.Parameters.AddWithValue("@PName", SearchQuery.Trim());
            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }





        public int GETPATIENT(int pid, ref string name, ref string phone, ref string address, ref string birthDate, ref int age, ref string gender)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {
				

                SqlCommand cmd1 = new SqlCommand("RetrievePatientData", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@id", SqlDbType.Int).Value = pid;

                
                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@birthDate", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@gender", SqlDbType.Char, 1).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();

               
                name = (string)cmd1.Parameters["@name"].Value.ToString();
                phone = (string)cmd1.Parameters["@phone"].Value.ToString();
                address = (string)cmd1.Parameters["@address"].Value.ToString();
                birthDate = (string)cmd1.Parameters["@birthDate"].Value.ToString();
                age = Convert.ToInt32((cmd1.Parameters["@age"].Value));
                gender = (string)cmd1.Parameters["@gender"].Value.ToString();


                return 0;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }










        public int GET_DOCTOR_PROFILE(int dID, ref string name, ref string phone, ref string gender, ref float charges_Per_Visit, ref float ReputeIndex, ref int PatientsTreated, ref string qualification, ref string specialization, ref int workE, ref int age)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {
               

                SqlCommand cmd1 = new SqlCommand("GET_DOCTOR_PROFILE", con);

                cmd1.CommandType = CommandType.StoredProcedure;


                
                cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;

                
                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@charges", SqlDbType.Float).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@RI", SqlDbType.Float).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@PTreated", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@qualification", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@specialization", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@workE", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd1.ExecuteNonQuery();

                
                name = (string)cmd1.Parameters["@name"].Value;
                phone = (string)cmd1.Parameters["@phone"].Value;
                gender = (string)cmd1.Parameters["@gender"].Value;
                charges_Per_Visit = Convert.ToSingle(cmd1.Parameters["@charges"].Value);
                ReputeIndex = Convert.ToSingle(cmd1.Parameters["@RI"].Value);
                PatientsTreated = (int)cmd1.Parameters["@PTreated"].Value;
                qualification = (string)cmd1.Parameters["@qualification"].Value;
                specialization = (string)cmd1.Parameters["@specialization"].Value;
                workE = (int)cmd1.Parameters["@workE"].Value;
                age = (int)cmd1.Parameters["@age"].Value;



            }

            catch (SqlException ex)
            {
                return -1;
            }

            con.Close();
            return 1;
        }



        public int GETSATFF(int id, ref string name, ref string phone, ref string address, ref string gender, ref string desig, ref int sal)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("GET_STAFF", con);
            cmd1.CommandType = CommandType.StoredProcedure;


            
            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = id;

            
            cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@address", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@desig", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@sal", SqlDbType.Int).Direction = ParameterDirection.Output;

            
            {
                cmd1.ExecuteNonQuery();


                
                name = (string)cmd1.Parameters["@name"].Value;
                phone = (string)cmd1.Parameters["@phone"].Value;
                gender = (string)cmd1.Parameters["@gender"].Value;
                address = (string)cmd1.Parameters["@address"].Value;
                desig = (string)cmd1.Parameters["@desig"].Value;
                sal = (int)cmd1.Parameters["@sal"].Value;

            }
            //catch
            {
                //return -1;
            }


            return 1;


        }





		//-----------------------------------------------------------------------------------//
		//                                                                                   //
		//                                       PACIENTE                                    //
		//                                                                                   //
		//-----------------------------------------------------------------------------------//










		/*------------------- EXIBE INFORMAÇÃO DO PACIENTE NA HOME --------------------------------------- */

		public int patientInfoDisplayer(int pid, ref string name, ref string phone, ref string address, ref string birthDate, ref int age, ref string gender)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();


			try
			{


				SqlCommand cmd1 = new SqlCommand("RetrievePatientData", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@id", SqlDbType.Int).Value = pid;

				
				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@birthDate", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@gender", SqlDbType.Char, 1).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();            

				
				name = (string)cmd1.Parameters["@name"].Value;
				phone = (string)cmd1.Parameters["@phone"].Value;
				address = (string)cmd1.Parameters["@address"].Value;
				birthDate = (string)cmd1.Parameters["@birthDate"].Value;
				age = (int)cmd1.Parameters["@age"].Value;
				gender = (string)cmd1.Parameters["@gender"].Value;


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();
			}
		}


		


		/*---------------------------Gerar Histórico Financeiro--------------------------------------*/

		public int getBillHistory(int id, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				


				cmd1 = new SqlCommand("RetrieveBillHistory", con); 
				cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = id;

				
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];     
				return (int)cmd1.Parameters["@count"].Value;



			}
			
			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}





		//-------------------------------------Consultas Agendadas------------------------------------------//

		public int appointmentTodayDisplayer(int pid, ref string dName, ref string timings)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				

				cmd1 = new SqlCommand("RetrieveCurrentAppointment", con);
				cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@pid", SqlDbType.Int).Value = pid;

                
                cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   

				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------Histórico de Tratamento------------------------------------------//
		public int getTreatmentHistory(int id, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{


				cmd1 = new SqlCommand("RetrieveTreatmentHistory", con);   
				cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = id;
				
				
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];      
				return (int)cmd1.Parameters["@count"].Value;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




		
		public int getdeptInfo(ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{
				/*EXECUTAR QUERY*/
				cmd1 = new SqlCommand("select* from deptInfo", con);
				cmd1.CommandType = CommandType.Text;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];
				return 1;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();
			}
		}




		

		public int getDeptDoctorInfo(string deptName, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				


				cmd1 = new SqlCommand("RetrieveDeptDoctorInfo", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@deptName", SqlDbType.VarChar, 30).Value = deptName;
				
				cmd1.ExecuteNonQuery();  

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);   
				}

				result = ds.Tables[0];

				return 1;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}







		


		public int doctorInfoDisplayer(int dID, ref string name, ref string phone, ref string gender, ref float charges_Per_Visit, ref float ReputeIndex, ref int PatientsTreated, ref string qualification, ref string specialization, ref int workE, ref int age)//, ref string clinic)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();


			try
			{
				

				SqlCommand cmd1 = new SqlCommand("RetrieveDoctorData", con);             

				cmd1.CommandType = CommandType.StoredProcedure;


				//Entradas
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				
				//Saidas
				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@charges", SqlDbType.Float).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@RI", SqlDbType.Float).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@PTreated", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@qualification", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@specialization", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@workE", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;
				//cmd1.Parameters.Add("@Clinic", SqlDbType.Int).Direction = ParameterDirection.Output;


				cmd1.ExecuteNonQuery();    

				
				name = (string)cmd1.Parameters["@name"].Value;
				phone = (string)cmd1.Parameters["@phone"].Value;
				gender = (string)cmd1.Parameters["@gender"].Value;
				charges_Per_Visit = Convert.ToSingle(cmd1.Parameters["@charges"].Value);
				ReputeIndex = Convert.ToSingle(cmd1.Parameters["@RI"].Value);
				PatientsTreated = (int)cmd1.Parameters["@PTreated"].Value;
				qualification = (string)cmd1.Parameters["@qualification"].Value;
				specialization = (string)cmd1.Parameters["@specialization"].Value;
				workE = (int)cmd1.Parameters["@workE"].Value;
				age = (int)cmd1.Parameters["@age"].Value;
				//clinic = (string)cmd1.Parameters["@Clinic"].Value;


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();    
			}
		}



		public int getFreeSlots(int dID, int pID, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				
				cmd1 = new SqlCommand("RetrieveFreeSlots", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				cmd1.Parameters.Add("@pID", SqlDbType.Int).Value = pID;

				
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);   
				}
				result = ds.Tables[0];     

				return (int)cmd1.Parameters["@count"].Value;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------Enviar Solicitação de consulta------------------------------------------//

		public int insertAppointment(int dID, int pID, int freeSlot, ref string mes)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			string m = "";

			con.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
			{
				m += "\n" + e.Message;
			};


			try
			{

				
				cmd1 = new SqlCommand("insertInAppointmentTable", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				cmd1.Parameters.Add("@pID", SqlDbType.Int).Value = pID;
				cmd1.Parameters.Add("@freeSlot", SqlDbType.Int).Value = freeSlot;
				
				cmd1.ExecuteNonQuery();   
				mes = m;

				return 0;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}





		//-------------------------------------NOTIFICAÇÕES------------------------------------------//

		public int getNotifications(int pid, ref string dName, ref string timings)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				

				cmd1 = new SqlCommand("RetrievePatientNotifications", con); 
				cmd1.CommandType = CommandType.StoredProcedure;

				
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = pid;
			
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   


				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}






		

		public int isFeedbackPending(int pid, ref string dName, ref string timings, ref int aID)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				

				cmd1 = new SqlCommand("RetrievePendingFeedback", con);   
				cmd1.CommandType = CommandType.StoredProcedure;

				
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = pid;
				
				
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@aID", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   
				
				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					aID = (int)cmd1.Parameters["@aID"].Value;

					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1; 
			}

			finally
			{
				con.Close();
			}
		}




		

		public int givePendingFeedback(int aID)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				

				cmd1 = new SqlCommand("storeFeedback", con);   
				cmd1.CommandType = CommandType.StoredProcedure;

				
				cmd1.Parameters.Add("@aId", SqlDbType.Int).Value = aID;

				cmd1.ExecuteNonQuery();


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}

















		//-----------------------------------------------------------------------------------//
		//                                                                                   //
		//                                       MÉDICO                                     //
		//                                                                                   //
		//-----------------------------------------------------------------------------------//






		
		public int docinfo_DAL(int doctorid, ref DataTable result)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;

			try
			{

				cmd = new SqlCommand("Doctor_Information_By_ID1", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ID", SqlDbType.Int);
				cmd.Parameters["@id"].Value = doctorid;
				cmd.ExecuteNonQuery();

				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				    da.Fill(ds);

				result = ds.Tables[0];

			}

			catch (SqlException ex)
			{
				return 0;
			}

			finally
			{ 
			    con.Close();
			}

			return 1;
		}






		
		public void GetAllpendingappointments_DAL(int doctorid, ref DataTable DT)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			
			try
			{
                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand("PENDING_APPOINTMENTS2", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DOCTOR_ID", SqlDbType.Int);
				cmd.Parameters["@DOCTOR_ID"].Value = doctorid;
				cmd.ExecuteNonQuery();

                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }

               DT = ds.Tables[0];

            }

            catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
			}

			finally
			{
				con.Close();
			}
		}




		
		public int UpdateAppointment_DAL(int Appointmentid)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			int result = 0;


            try
            {
                cmd = new SqlCommand("APPROVE_APPOINTMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@APPOINT_ID", SqlDbType.Int).Value = Appointmentid;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

			return result;
		}



		
		public int Deleteappointment_DAL(int appointmentid)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			


			try
			{
				cmd = new SqlCommand("delete_APPOINTMENT", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@APPOINT_ID", SqlDbType.Int).Value = appointmentid;
				cmd.ExecuteNonQuery();
			}

			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
				return -1;
			}

			finally
			{
				con.Close();

			}
			return 1;
			
		}




		
		public int search_patient_DAL(int did, ref DataTable result)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();

			SqlCommand cmd;

            try
            {


                cmd = new SqlCommand("TODAYS_APPOINTMENTS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = did;

                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }



                result = ds.Tables[0];
            }

            catch (SqlException ex)
            {

            }
            
            finally
            {
                con.Close();
            }

            return 1;
		}






		
		public int update_prescription_DAL(int did, int appointid, string disease, string progres, string prescrip)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			try
			{
				cmd = new SqlCommand("UpdatePrescription", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
				cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appointid;
				cmd.Parameters.Add("@Disease", SqlDbType.VarChar, 30).Value = disease;
				cmd.Parameters.Add("@progress", SqlDbType.VarChar, 50).Value = progres;
				cmd.Parameters.Add("@prescription", SqlDbType.VarChar, 60).Value = prescrip;

				cmd.ExecuteNonQuery();
			}
			
			catch (SqlException ex)
			{
				return 0;
			}
			finally
			{ 
			con.Close();
			}

			return 1;
			

		}


		

		public int generate_bill_DAL(int docid, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("generate_bill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dId", SqlDbType.Int);
                cmd.Parameters["@did"].Value = docid;


                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);

                }

                result = ds.Tables[0];
              
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }

            return 1;
		}




		public void paid_bill_DAL(int did, int appoint)
		{

			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			
			cmd = new SqlCommand("finishedPaid", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
			cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appoint;
			
			cmd.ExecuteNonQuery();

            con.Close();
		}


        public void Unpaid_bill_DAL(int did, int appoint)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            cmd = new SqlCommand("finishedUnPaid", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appoint;

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public int getPHistory(int id, ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {


                cmd1 = new SqlCommand("RetrievePHistory", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                
                cmd1.Parameters.Add("@dId", SqlDbType.Int).Value = id;

                cmd1.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(ds);
                }

                result = ds.Tables[0];
                return 1;
            }

            
            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }


    }


}
