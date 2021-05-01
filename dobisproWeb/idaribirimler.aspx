﻿<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="idaribirimler.aspx.cs" Inherits="idaribirimler" %>

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
        <label>Bölge</label>        
        <asp:TextBox ID="txtResimAdi" placeholder="Bölge Adı" class="form-control" runat="server" /><br />
        <label>İdari Birimlerin Resmini Seçin</label>        
        <asp:FileUpload ID="fileResim" accept="image/*" multiple="false" onchange="readURL(this);" CssClass="form-control" runat="server" />        
    </div>
    <div class="pull-right">
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="İdari Birim Ekle" OnClick="Button1_Click" />
    </div>  

    <img id="blah"/>
    
    <table class="table">
        <thead>
        <tr>
            <th>Sıra</th>
            <th>Resim Adı</th>
            <th>Resim</th>
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

