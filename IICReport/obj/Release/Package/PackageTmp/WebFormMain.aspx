<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="IICReport.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IIC REPORT</title>

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
   
    <link rel="shortcut icon" type="image/x-icon" href="images/rheem.ico" />

    <link rel="stylesheet" href="Content/bootstrap.css" />

    <link href="project-styles.css" rel="stylesheet" />

    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet"/>

    <link href="Animation/FadeIn.css" rel="stylesheet" />
  
    <!-- jQuery library -->
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Animation/SmoothScroll.js"></script>

</head>
<body class="montserrat-font fade-in" style="overflow:hidden;">
        
  <%--  <section class="project-navbar">
  
        <p class="text-color-white text-center pt-2 pb-2">RHEEM</p>
                
    </section>--%>


    <form id="form1" runat="server" >

        <div class="row mar-top-100">
            
            <div class="col-xs-12 col-md-12 col-lg-12 pad-left-5">


                <img src="Images/Rheem Logo.png" width="80"/>

                

            </div>

        </div>
        
        <div class="row mar-top-120">
            
            <div class="col-xs-6 col-md-6 col-lg-6 pad-left-5">


                
                <h1 class="mar-top-20"><strong>INTERACTIVE</strong></h1>
                
                <h1 class="mar-top-20"><strong>INFORMATION CENTER</strong></h1> 
                
                <h5 class="mar-top-250 text-color-gray">NUMBERS</h5>

            </div>

            <div class="col-xs-6 col-md-6 col-lg-6 text-white">


                <div class="pad-left-5">
                                    <img src="Images/img-number.svg" width="50"/>

                    <h4 class="mar-top-30">TOTAL</h4>
                    <br />
                    <asp:Label runat="server" ID="TotalLabel" Text="50" CssClass="h4 text-color-red"></asp:Label>
                </div>

                <div class="mar-top-20 text-right pad-right-5">
                                    <img src="Images/img-clock.svg" width="50"/>

                    <h4 class="mar-top-30">LAST LOG IN</h4>
                    <br />
                    <asp:Label runat="server" ID="LastLogLabel" Text="2020-02-26 13:29" CssClass="h4 text-color-red"></asp:Label>
                </div>



            </div>

        </div>


      

    </form>
</body>
</html>
