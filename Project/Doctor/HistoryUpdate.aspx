<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctormaster.Master" AutoEventWireup="true" CodeBehind="HistoryUpdate.aspx.cs" Inherits="doctor.Historyupdate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Atualizar histórico</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cp1" runat="server">

<h1>Atualizar histórico  </h1>

<h4>Doença:</h4><asp:TextBox ID="Disease" runat="server"></asp:TextBox>
   <h4>Progresso:</h4> <asp:TextBox ID="progress" runat="server"></asp:TextBox>
    <h4>Prescrição</h4><asp:TextBox ID="Prescription" runat="server"></asp:TextBox>
    <br />
      <br />
      <br />

    <asp:Button ID="submit" runat="server" Text="Salvar" Onclick="saveindatabase" Font-Bold="true" />  
    <asp:Button ID="Bill" runat="server" Text="Gerar Fatura" OnClick="generate_bill" Font-Bold ="true" />

</asp:Content>
