<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="form-group">
        <label>Okul Adı</label>
        <asp:TextBox ID="txtOkulAdi" runat="server" placeholder="Okul Adı" CssClass="form-control"></asp:TextBox><br />
        <label>Slayt Bekleme Süresi</label>        
        <asp:TextBox ID="txtSlaytBekleme" TextMode="Number" required="required" data-validate-minmax="0,100" placeholder="Slayt Bekleme Süresi" class="form-control" runat="server" /><br /> 
        <label>Ana Menü Zaman Aşımı Süresi</label>        
        <asp:TextBox ID="txtzamanAsimi" TextMode="Number" required="required" data-validate-minmax="0,100" placeholder="Slayt Bekleme Süresi" class="form-control" runat="server" /><br />
        <label>Yazıcı Sayfa Başı Ödeme Fiyatı</label>       
        <asp:TextBox ID="txtSayfaBasiYaziciMiktar" required="required"  placeholder="Bakiye" class="form-control" runat="server" Text="0" /><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Tam Sayı veya Ondalıklı Sayı Girmelisiniz. Örnek: 12,50 Girilmezse Varsayılan Sıfırdır." Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtSayfaBasiYaziciMiktar"></asp:CompareValidator>
        <br />
    </div>
    <div class="pull-right">
        <asp:Button ID="btnguncelle" runat="server" CssClass="btn btn-success" Text="Güncelle" OnClick="btnguncelle_Click"  />
    </div>  
</asp:Content>

