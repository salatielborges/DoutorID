<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctormaster.Master" AutoEventWireup="true" CodeBehind="DoctorHome.aspx.cs" Inherits="doctor.doctorhome" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Médicos Inicio</title>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="Cp1" runat="server">


    <div style="background-image:url(/assets/img/backgrounds/PatientHome.jpg); background-position:center; background-size:20px; margin-left:50px">

            <h1>Dados do Médico</h1>
             <br />        
            <h3>Nome:       <asp:label id="Label1" runat="server"   Font-Bold="true" Font-Size="Medium"  /><br /><br /> </h3>   

            <h4>Telefone:      <asp:label id="Label2" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Endereço: <asp:label id="Label3" runat="server" Font-Bold="true" Font-Size="Medium"   />  </h4>
             <br />
            <h4> Dt Aniversário:   <asp:label id="Label4" runat="server"  Font-Bold="true" Font-Size="Medium" /></h4>

            <br />
            <br />
            <h4>Gênero:  <asp:label id="Label5" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  Consultório: <asp:label id="Label6" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>

            <br />
            <br />
           <h4>Valor da Consulta: R$ <asp:label id="Label7" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  Salário: <asp:label id="Label8" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
            <br />
            <br />
           <h4>Avaliação Média: <asp:label id="Label9" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp  Pacientes Atendidos: <asp:label id="Label10" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
            <br />
             <br />
          
            <h4>Formação: <asp:label id="Label11" runat="server"   Font-Bold="true" Font-Size="Medium"  /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Clínica: <asp:label id="Label15" runat="server"   Font-Bold="true" Font-Size="Medium"  /> <br /><br /> Especialização: <asp:label id="Label12" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp </h4>
            <h4>Experiência Profissional: <asp:label id="Label13" runat="server"   Font-Bold="true" Font-Size="Medium"  />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  Situação: <asp:label id="Label14" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
            <br />
</div>    
        
    </asp:Content>