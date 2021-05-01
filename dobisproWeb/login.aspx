<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Yap</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
</head>
<body class="login">
    <form id="form1" runat="server">
        <div>
            <div>
          <a class="hiddenanchor" id="signup"></a>
          <a class="hiddenanchor" id="signin"></a>

          <div class="login_wrapper">
            <div class="animate form login_form">
              <section class="login_content">
                <form>
                  <h1>Dobis Pro Giriş Yap</h1>
                  <div>
                    <asp:TextBox ID="txtKullaniciAdi" runat="server" placeholder="Kullanıcı Adı" CssClass="form-control"></asp:TextBox>
                  </div>
                  <div>
                    <asp:TextBox ID="txtsifre" TextMode="Password" runat="server" placeholder="Şifre" CssClass="form-control"></asp:TextBox>
                  </div>
                  <br />
                  <div>
                      <div class="pull-right">
                            <asp:Button ID="btngirisyap" runat="server" CssClass="btn btn-default submit" Text="Giriş Yap" OnClick="btngirisyap_Click" />                
                      </div>
                  </div>

                  <div class="clearfix"></div>

                  <div class="separator">
                    <div class="clearfix"></div>
                    <br />

                    <div>
                      <p>©2016 All Rights Reserved. Theme Edit Author Murat Çakmak</p>
                    </div>
                  </div>
                </form>
              </section>
            </div>        
          </div>
        </div>
        </div>
    </form>

    
</body>
</html>
