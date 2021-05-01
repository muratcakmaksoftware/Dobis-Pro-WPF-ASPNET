<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="dilekvesikayetoku.aspx.cs" Inherits="dilekvesikayetoku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <label>Konu</label>
    <asp:TextBox ID="txtkonu" runat="server" CssClass="form-control"></asp:TextBox><br />
    <label>Mesaj</label>
    <asp:TextBox ID="txtmesaj" TextMode="MultiLine" runat="server" CssClass="form-control" Height="500px"></asp:TextBox><br />
    <div class="pull-right">
        <asp:Button ID="btnsil" runat="server" CssClass="btn btn-danger" Text="Sil" onClientClick="return confirm('Silmek İstediğinize Emin Misiniz ?');" OnClick="btnsil_Click" /><br />
    </div>
</asp:Content>

