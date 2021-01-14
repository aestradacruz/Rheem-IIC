<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormWelcome.aspx.cs" Inherits="WebApplication.WebFormWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido</title>

    
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
   
    <link rel="shortcut icon" type="image/x-icon" href="images/rheem.ico" />

    <link rel="stylesheet" href="Content/bootstrap.css" />

    <link href="project-styles.css" rel="stylesheet" />

    <script src="Animation/SmoothScroll.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet"/>

    <link href="Animation/FadeIn.css" rel="stylesheet" />

    <!-- jQuery library -->
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <link href="Animation/BottomToTop.css" rel="stylesheet" />

    <link href="Animation/FadeIn.css" rel="stylesheet" />
</head>
<body class="background-color-black montserrat-font fade-in">
    <form id="form1" runat="server">
        <div>
            
            <div class="text-center mar-top-230 bottom-to-top">

                <h5 class="text-color-red">RHEEM MEXICALI</h5>
                
                <h2 class="text-color-white mar-top-50" style="font-size:42px;">INTERACTIVE INFORMATION CENTER</h2>
                            

                <h5 class="text-color-gray mar-top-30">CENTRO DE AYUDAS VISUALES</h5>
                
                <asp:Button ID="ButtonGo" runat="server" Text="IR" OnClick="ButtonGo_Click" CssClass="btn-info mar-top-50" style="width:200px;" />

            </div>




        </div>
    </form>
</body>
</html>
