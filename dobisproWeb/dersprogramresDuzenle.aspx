<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="dersprogramresDuzenle.aspx.cs" Inherits="dersprogramresDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                //var height = $(window).height() - ($("header").outerHeight() + $("footer").outerHeight());
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width('100%')
                        .height('100%');
                };

                reader.readAsDataURL(input.files[0]);
            }
            else {
                $('#blah').attr('src', '');
                $('#blah').width('0px');
                $('#blah').height('0px');
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group">
        <label>Sınıf</label>
        <asp:DropDownList ID="drpSinif" class="form-control" runat="server"></asp:DropDownList><br /><br />
        <label>Resim Adı</label>        
        <asp:TextBox ID="txtResimAdi" placeholder="Resim Adı" class="form-control" runat="server" /><br />
        <label>Ders Program Resmini Seçin</label>        
        <asp:FileUpload ID="fileResim" accept="image/*" multiple="false" onchange="readURL(this);" CssClass="form-control" runat="server" />
        <asp:Literal ID="ltresim" runat="server"></asp:Literal>
    </div>
    <div class="pull-right">
        <asp:Button ID="btnguncelle" runat="server" CssClass="btn btn-success" Text="Güncelle" OnClick="btnguncelle_Click" />
    </div> 
    <asp:Button ID="btn" runat="server" CssClass="btn btn-danger" Text="Sil" onClientClick="return confirm('Silmek İstediğinize Emin Misiniz ?');" OnClick="btn_Click" /><br />
    <img id="blah" />
</asp:Content>

