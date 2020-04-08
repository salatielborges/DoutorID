<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="AppointmentRequestSent.aspx.cs" Inherits="DBProject.AppointmentNotificationSent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <title>Agendar Consulta</title>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br /><br /><br />
    <h3><strong>Clique neste botão para enviar uma solicitação de consulta ao médico</strong> </h3>
   
    <asp:Button runat ="server" OnClick="sendARequest" Text ="Agendar Consulta" Font-Bold ="true" />

    <br /><br />
    <asp:Label ID="Message" runat="server"></asp:Label>
    <br /><br />

</asp:Content>
