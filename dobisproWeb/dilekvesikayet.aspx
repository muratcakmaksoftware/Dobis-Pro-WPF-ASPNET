<%@ Page Title="" Language="C#" MasterPageFile="~/anamaster.master" AutoEventWireup="true" CodeFile="dilekvesikayet.aspx.cs" Inherits="dilekvesikayet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="table">
         <thead>
            <tr>
                <th>Sıra</th>
                <th>Konu</th>
                <th>Mesaj</th>
                <th>Durum</th>                
                <th>Oku</th>
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

