<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="ogrenciler.aspx.cs" Inherits="ogrenciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                //var height = $(window).height() - ($("header").outerHeight() + $("footer").outerHeight());
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width('150px')
                        .height('150px');
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
        <table class="table">
            <tr>
                <td><label>Öğrenci Adı</label></td>
                <td><asp:TextBox ID="txtOgrenciAdi" runat="server" placeholder="Öğrenci Adı" CssClass="form-control"></asp:TextBox></td>
                <td><img id="blah" /></td>
            </tr>
            <tr>
               <td><label>T.C No</label></td>
               <td><asp:TextBox ID="txtTcNo" class="tcno" MaxLength="11" runat="server" placeholder="T.C Kimlik Numarası" CssClass="form-control"></asp:TextBox></td>
               <td><asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTcNo" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{11,}$" runat="server" ErrorMessage="11 Karakter Girmelisiniz."></asp:RegularExpressionValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Sadece Sayı Girmelisiniz." Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtTcNo"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td><label>Okul Numarası</label></td>
                <td><asp:TextBox ID="txtOkulNo" required="required"  placeholder="Okul Numarası" class="form-control" runat="server" /></td>
                <td><asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Sadece Sayı Girmelisiniz." Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtOkulNo"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td><label>Bakiye</label></td>
                <td><asp:TextBox ID="txtBakiye" required="required"  placeholder="Bakiye" class="form-control" runat="server" Text="0" /></td>
                <td><asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Tam Sayı veya Ondalıklı Sayı Girmelisiniz. Örnek: 12,50 Girilmezse Varsayılan Sıfırdır." Operator="DataTypeCheck" Type="Currency" ControlToValidate="txtBakiye"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td><label>Sınıf</label></td>
                <td><asp:DropDownList ID="drpSinif" class="form-control" runat="server"></asp:DropDownList></td>
                <td><asp:TextBox ID="txtSinif" runat="server" MaxLength="1000" placeholder="Yeni Sınıf" CssClass="form-control"></asp:TextBox></td>                
            </tr>
            <tr>
                <td><label>Resim Seçin</label></td>
                <td><asp:FileUpload ID="fileResim" accept="image/*" multiple="false" onchange="readURL(this);" CssClass="form-control" runat="server" /></td>
            </tr>
        </table>
        
    </div>
    <div class="pull-right">
        <asp:Button ID="btnogrenciekle" runat="server" CssClass="btn btn-success" Text="Öğrenci Ekle" OnClick="btnogrenciekle_Click" />
    </div>  
    <table class="table">
        <thead>
            <tr>
                <th>Sıra</th>
                <th>Öğrenci Adı</th>
                <th>T.C No</th>
                <th>Okul No</th>
                <th>Sınıf</th>
                <th>Bakiye</th>
                <th>Düzenle</th>
                <th>Sil</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="lticerik" runat="server"></asp:Literal>
        </tbody>
    </table>

    <script type="text/javascript">
        var elems = document.getElementsByClassName('confirmation');
        var confirmIt = function (e) {
            if (!confirm('Silmek İstediğinize Emin Misiniz?')) e.preventDefault();
        };
        for (var i = 0, l = elems.length; i < l; i++) {
            elems[i].addEventListener('click', confirmIt, false);
        }
    </script>
</asp:Content>

