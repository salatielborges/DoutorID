<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="DoctorProfile.aspx.cs" Inherits="DBProject.DoctorProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Perfil do Médico</title>

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <link rel="stylesheet" href="/assets/css/grid-view.css"/>

    
    <div style="background-image:url(/assets/img/backgrounds/PatientHome.jpg); background-position:center; background-size:20px">

        <br />
        <h1><strong style="margin:37%">Perfil do Médico</strong></h1>
        <br /><br />

        <div style="margin-left: 70px">

            <h4><strong>Nome: </strong></h4>
            <asp:Label ID="DName" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Telefone: </strong></h4>
            <asp:Label ID="DPhone" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Formação:</strong></h4>
            <asp:Label ID="DQualification" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br />
            <br />

            <h4><strong>Clínica:</strong> CLÍNICA AMÉRICA</h4>
            <asp:Label ID="DClinic" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br />
            <br />

            <h4><strong>Especialidade:</strong></h4>
            <asp:Label ID="DSpecialization" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Experiência:</strong></h4>
            <asp:Label ID="DWork" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Idade: </strong></h4>
            <asp:Label ID="DAge" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Gênero:</strong></h4>
            <asp:Label ID="DGender" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Consultório:</strong></h4>
            <asp:Label ID="DDept" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Valor da Consulta:</strong></h4>
            <asp:Label ID="DCharges" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Avaliação Média:</strong></h4>
            <asp:Label ID="DRI" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <h4><strong>Número de pacientes tratados:</strong></h4>
            <asp:Label ID="DPT" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
            <br /><br />

            <asp:Button ID="AppointmentB" runat="server" Text="MARCAR CONSULTA" OnClick="RedirectToAppointmentTaker" Font-Bold="true" Height="41px" Width="217px"  />

        </div>

    </div>

</asp:Content>
