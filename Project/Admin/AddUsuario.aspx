<%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="None" CodeBehind="AddUsuario.aspx.cs" Inherits="DBProject.AddStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

<style type = "text/css">
  
   

    html
    {
      background-image:url("/assets/staff9.jpg");   
      background-size: cover;
      background-position: 0 -90px;
      background-attachment: fixed;
    }
    body {
        background: none !important;
    }
    .backstretch {
        display: none !important;
    }

    .grad{

  background: linear-gradient(to right, rgba(30, 160, 100 , 0.15),rgba(150, 148, 255 , 1)); 
  border-radius:8px;
}
 
  #space
  {
    padding-bottom:50px;
  }

    
    
    </style>

</head>
<body>
    <form id="form1" runat="server">
      
        
        <div id ="myclass">    
        
        
        
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="/assets/font-awesome/css/font-awesome.min.css"/>
        <link rel="stylesheet" href="/assets/css/form-elements.css"/>
        <link rel="stylesheet" href="/assets/css/style.css"/>
        

            



       
             	                   
                      
        <div class="top-content">
       
            
            <div class="inner-bg">
            
                <div class="container grad">
                
                    

                    <div class="row">
                    
                        <div class="col-sm-8 col-sm-offset-2 text">
                        
                            <h1><strong>DoutorID</strong> Cadastro de Funcionário</h1>
                            
                            <div class="description">
                            	<p>
	                            	Formulário para <strong>"Cadastro de Funcionário"</strong> . 
	                            	
	                            	
                                    
                            	</p>
                            
                            </div>
                        </div>

                    </div>
                    </div>
                   </div>
            </div>
        
                                    
                                    
                                    
                                    <!--  Inicio dos registros :)-->
                                    
                                    <div class="container myclass">

                                       
                                        <div class ="row">

                                                      
                        
                        <div class="col-sm-2"></div>
                        	
                            <div class="col-sm-8">
                        	
                                <div class="form-box" id="spaces">
                                    <div class="form-top">
                                        <div class="form-top-left">
                                            <h3 style="font-family:Algerian">Cadastrar Funcionário
                                            
                                            </h3>

                                            <asp:Label ID="Msg" runat="server" ForeColor="Blue" Visible="False" Font-Bold="True" Font-Size="Large" Font-Strikeout="False"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="form-bottom">




                                        <!-- Dados para registro do Funcionário :)-->


                                        <div class="form-group">



                                            <asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="*Obrigatório" Display="dynamic" Font-Bold="False" SetFocusOnError="True" ControlToValidate="Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="Name" runat="server" type="text" class="form-username form-control" placeholder="Nome"></asp:TextBox>


                                        </div>
                                        <div class="form-group">


                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*Obrigatório" ControlToValidate="BirthDate" ID="BDateReqiured" Display="Dynamic" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="BirthDateValidator" runat="server" ErrorMessage="Data com formato incorreto" ControlToValidate="BirthDate" Display="Dynamic" ValidationExpression="((?:0[1-9])|(?:1[0-2]))\/((?:0[0-9])|(?:[1-2][0-9])|(?:3[0-1]))\/(\d{4})" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="BirthDate" runat="server" type="text" class="form-username form-control" placeholder="Data de Nascimento"></asp:TextBox>

                                        </div>


                                       <div class="form-group">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Apenas Números !" ControlToValidate="Phone" ValidationExpression='^[0-9]+$' Font-Strikeout="False" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="Phone" runat="server" type="text" class="form-username form-control" placeholder="Telefone "></asp:TextBox>
                                        
                                                                                
                                      </div>
                                   


                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorp" runat="server" ErrorMessage="Apenas Números!" ControlToValidate="Salary" ValidationExpression='^[0-9]+$' Font-Strikeout="False" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>


                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*Obrigatório" ControlToValidate="Designation" ID="RequiredFieldValidator1" Display="Dynamic" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                        

                                    <div class="form-group">



                                        <asp:TextBox ID="Salary" runat="server" type="text" placeholder="Salário" Width="221px"></asp:TextBox>

                                        <asp:TextBox ID="Qual" runat="server" type="text" placeholder="Setor"></asp:TextBox>
                                        <asp:TextBox ID="Designation" runat="server" type="text" placeholder="Função" Width="243px"></asp:TextBox>

                                    </div>







                                    <div class="form-group">


                                        <asp:TextBox ID="Address" runat="server" class="form-username form-control" type="text" placeholder="Endereço"></asp:TextBox>



                                    </div>





                                    <div class="form-group">

                                        <asp:RadioButton name="Gender" ID="Male" GroupName="Gender" runat="server" Text="Masculino" Checked="true" value="M" />

                                        <asp:RadioButton name="Gender" ID="Female" GroupName="Gender" runat="server" Text="Feminino" value="F" />

                                    </div>







                                    <asp:Button Text="Cadastrar" runat="server" type="submit" class="btn btn-primary" OnClick="StaffRegister"></asp:Button>






                                </div>
                             </div>
                        </div>
                        	
                      
                    </div>
                    
                </div>
            </div>
            


                                    

        





            

        
        <footer ">
        	<div class="container">
        		<div class="row">
        			
        			<div class="col-sm-8 col-sm-offset-2">
        				<div class="footer-border"></div>
        				<p style="color:darkslategrey">Se você tiver alguma dúvida, não hesite em contactar-nos. <i class="fa fa-smile-o"></i></p>
        			
                   
                    
                    </div>
        			
        		</div>
        	</div>
        </footer>

        <!-- Javascript -->
        <script src="/assets/js/jquery-1.11.1.min.js"></script>
        <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="/assets/js/jquery.backstretch.min.js"></script>
        <script src="/assets/js/scripts.js"></script>
        








     
    
    
    </form>
</body>


</html>
