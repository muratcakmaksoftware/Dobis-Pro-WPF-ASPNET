<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="dersprogram.aspx.cs" Inherits="dersprogram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">
        <label>Sınıf</label>
        <asp:DropDownList ID="drpSinif" class="form-control" runat="server"></asp:DropDownList><br />
        <label>Ders Programı Excel Dosyasını Seçin</label>                                      
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.xls|.XLS|.xlsx|.XLSX)$" ControlToValidate="fileExcel" runat="server" ForeColor="Red" ErrorMessage="Lütfen sadece excel dosyası seçiniz." Display="Dynamic" />
        <asp:FileUpload ID="fileExcel" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" multiple="false" CssClass="form-control" runat="server" />        
        
    </div>
    <div class="pull-right">
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Ders Programı Ekle" OnClick="Button1_Click"  />
    </div>  

    <div class="form-group">
        <label>Ders Programını Görüntüleme</label>
        <asp:DropDownList ID="drpSinifFiltrele" class="form-control" runat="server" OnSelectedIndexChanged="drpSinifFiltrele_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
        <table class="table">
            <thead>
                <tr>
                    <th>Ders</th>
                    <th>Giriş</th>
                    <th>Çıkış</th>
                    <th>Pazartesi</th>
                    <th>Salı</th>
                    <th>Çarşamba</th>
                    <th>Perşembe</th>
                    <th>Cuma</th>
                </tr>
            </thead>

            <tbody>
                <asp:Literal ID="ltdersprogram" runat="server"></asp:Literal>
            </tbody>

        </table>

        
    </div>
</asp:Content>

