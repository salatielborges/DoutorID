<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctormaster.Master" AutoEventWireup="true" CodeBehind="Bill.aspx.cs" Inherits="doctor.bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Ganhos Gerais</title>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="Cp3" runat="server">



    <h1>Sua conta para esta consulta é :      <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true" Font-Size="Medium" ></asp:Label> </h1>
   
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />


    &nbsp&nbsp&nbsp&nbsp<asp:Button ID="Bill" runat="server" Text="Conta Paga" OnClick="bill_paid" Font-Bold ="true" />
   

     &nbsp&nbsp&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="Conta não Paga" OnClick="bill_Unpaid" Font-Bold ="true" />
   




</asp:Content>
