<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="DBProject.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>DoutorID Login &amp; Cadastro</title>


 <script type="text/javascript">


     
     function validateEmail(Email)
     {
         if (Email == "") {
             alert("E-mail é obrigatório");
             return false;
         }

         else if (Email.indexOf("@") == -1 || Email.indexOf(".com") == -1) {
             alert("Seu endereço de email parece incorreto. Por favor, insira um novo.");
             return false;
         }

         else {
             var location = Email.indexOf("@");

             if (Email[0] == '@' || Email[location + 1] == '.') {
                 alert("Seu endereço de email parece incorreto. Por favor, insira um novo.");
                 return false;
             }

             var emailPat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
             var EmailmatchArray = Email.match(emailPat);

             if (EmailmatchArray == null) {
                 alert("Seu endereço de email parece incorreto. Por favor, insira um novo.");
                 return false;
             }
         }

         return true;
     }






     
     function validateS() 
     {
         var Name      = document.getElementById('<%=sName.ClientID %>').value;
         var Bdate     = document.getElementById('<%=sBirthDate.ClientID %>').value;
         var Email     = document.getElementById('<%=sEmail.ClientID %>').value;
         var phone     = document.getElementById('<%=Phone.ClientID %>').value;
         var pass      = document.getElementById('<%=sPassword.ClientID %>').value;
         var cpass     = document.getElementById('<%=scPassword.ClientID %>').value;
         
         

         if (Name == "")
         {
             alert("E-mail é obrigatório");
             return false;
         }


         var arrDbirth = Bdate.split("/");

         if (Bdate == "")
         {
             alert("Data de nascimento é obrigatório.");
             return false;
         }

         else if ((Bdate == arrDbirth[0]) || (arrDbirth[0].length != 2) || arrDbirth[1].length != 2 || arrDbirth[2].length != 4 || !arrDbirth[0].match(/^[0-9]*$/) || !arrDbirth[1].match(/^[0-9]*$/) || !arrDbirth[2].match(/^[0-9]*$/) || Number(arrDbirth[1]) > 12 || Number(arrDbirth[0]) > 31)
         {
             alert("Formato da data de nascimento Incorreto");
             return false;
         }


         if (!validateEmail(Email))
             return false;


         if (pass == "" || cpass == "")
         {
             alert("O Campo senha está vazio");
             return false;
         }

         else if (pass != cpass)
         {
             alert("Senhas não correspondem");
             return false;
         }
            

         if (phone.length != 11)
         {
             alert("O número de telefone deve ter 11 dígitos.");
             return false;
         }


         if (Request.Form["Gênero"] == null)
         {
             alert("Selecione gênero");
             return false;
         }
        
         return true;
     }





     
     function validateL() 
     {
         var Email        = document.getElementById('<%=loginEmail.ClientID %>').value;
         var Password     = document.getElementById('<%=loginPassword.ClientID %>').value;
         
         

         if (!validateEmail(Email))
             return false;


         if (Password == "")
         {
             alert("Senha ausente. Digite a senha.");
             return false;
         }

         return true;
     }

     

</script>


    
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="assets/css/form-elements.css"/>
    <link rel="stylesheet" href="assets/css/style.css"/>

    
    <link rel="shortcut icon" href="assets/ico/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>

    
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>


    <!-- Javascript -->
    <script src="assets/js/jquery-1.11.1.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.backstretch.min.js"></script>
    <script src="assets/js/scripts.js"></script>

</head>



<body>

    <form id="SignUpPage" runat ="server"  >
				       
        <div>    
        
             	                                
        <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                    
                   <div class="row">
                         <div class="col-sm-8 col-sm-offset-2 text">
                        
                            <h1><strong>DoutorID</strong> Login &amp; Registro</h1>
                            
                            <div class="description">
                            	<p>
	                            	Este é um formulário de <strong>"Registro e Login"</strong>. 
                            	</p>                            
                            </div>
                        </div>
                    </div>

                    
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-box">
                                <div class="form-top">
                                    <div class="form-top-left">
	                        		
                                        <h3>Acessar Sistema</h3>
	                            		<p>Insira seu email e senha de login:</p>

	                        		</div>
	                        		
                                    <div class="form-top-right">
	                        			<i class="fa fa-key"></i>
	                        		</div>
	                           </div>
	                            
                                
                                
                                <div class="form-bottom">
				                    
                                
                                            
                                <div class="form-group">
				                    		
                                    <asp:TextBox ID="loginEmail" runat="server" type="text" class="form-username form-control" placeholder="Email" ></asp:TextBox>
           
                                </div>

				                <div class="form-group">
				                        	
                                    <asp:TextBox ID="loginPassword" runat="server" type="password" class="form-username form-control" placeholder="Senha"></asp:TextBox>
           
                                </div>
				                 
                                 <asp:button ID="loginUserName"  runat="server"  type="submit" Text="Acessar"  class="btn btn-primary" OnClientClick="return validateL();"   onclick="loginV"></asp:button>
				                   
                                   
			                    
                                
                                </div>

		                    </div>
		                
	                        
                        </div>
                        

                        <div class="col-sm-1 middle-border"></div>
                        <div class="col-sm-1"></div>
                        	
                        <div class="col-sm-5">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>Se Cadastrar</h3>
	                            		<p>Preencha o Formulário</p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        
                                    
                                    
                            <div class="form-group">
			               
                                <asp:TextBox ID="sName" runat="server" type="text" class="form-username form-control" placeholder="Nome" ></asp:TextBox>
                                                       	                            
                            </div> 

				            <div class="form-group">
				                        	
                                <asp:TextBox ID="sBirthDate" runat="server" type="text" class="form-username form-control" placeholder="Data de Nascimento" ></asp:TextBox>
           	                            
                            </div>

				            <div class="form-group">
				            
                                    <asp:TextBox ID="sEmail" runat="server" type="text" class="form-username form-control" placeholder="Email" ></asp:TextBox>

                            </div>

                            <div class="form-group">
				                        
                                    <asp:TextBox ID="sPassword" runat="server" type="password" class="form-username form-control" placeholder="Senha" ></asp:TextBox>

                            </div>


                            <div class="form-group">
                                             				                        
                                    <asp:TextBox ID="scPassword" runat="server" type="password" class="form-username form-control" placeholder="Confirmar Senha" ></asp:TextBox>

                            </div>


                            <div class="form-group">
            
                                    <asp:TextBox ID="Phone" runat="server" type="text" class="form-username form-control" placeholder="Telefone" ></asp:TextBox>

                            </div>
                                    
                            <div class="form-group">

                                 <input type="radio" name="Gender" value="M" id="test" checked="checked" />
                                  Masculino
                                 <input type="radio" name="Gender" value="F" />
                                  Feminino

                            </div>


                            <div class="form-group">
                                				                        
                                <asp:TextBox id="Address" placeholder ="Endereço" TextMode="multiline" Columns="40" Rows="10" runat="server" Height="75px" Width="410px" />
        
                            </div>

				            <asp:button Text ="Cadastrar"  runat="server" type="submit" class="btn btn-primary" OnClientClick="return validateS();" onclick="signupV"></asp:button>
				                    
                                    
                    
                                            
                               </div>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
 

        
        <footer>
        	<div class="container">
        		<div class="row">
        			
        			<div class="col-sm-8 col-sm-offset-2">
        				<div class="footer-border"></div>
        				<p>Se você tiver alguma dúvida, entre em contato conosco. <i class="fa fa-smile-o"></i></p>
                    </div>
        			
        		</div>
        	</div>
        </footer>

       
        </div>
    </form>


</body>
</html>
