﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="WebApplication.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IIC</title>

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


    <script>

        $(document).ready(function () {

            // HidePanels();
            setupTimers();

            // HideCFSPanel();
        });

        var timeoutInMiliseconds = 300000;
        var timeoutId; 

        function resetTimer() { 
            window.clearTimeout(timeoutId)
            startTimer();
        }

        function startTimer() { 
            // window.setTimeout returns an Id that can be used to start and stop a timer
            timeoutId = window.setTimeout(doInactive, timeoutInMiliseconds)
        }
  
        function doInactive() {
            window.location.href = 'WebFormWelcome.aspx';
        }
 
        function setupTimers () {
            document.addEventListener("mousemove", resetTimer, false);
            document.addEventListener("mousedown", resetTimer, false);
            document.addEventListener("keypress", resetTimer, false);
            document.addEventListener("touchmove", resetTimer, false);
     
            startTimer();
        }

        function ShowFrame(href) {
             $("#IFrame").attr("src", href);

            $("#InsertedInspectionModal").modal('show');
        }

        function HidePanels() {
            HidePDFSection();
        }


        function HidePDFSection() {
            $("#PDFSection").hide();
        }

        function ShowCFSPanel() {
            $("#CFSSection").show();
        }

        function HideCFSPanel() {
            $("#CFSSection").hide();
        }

        function ShowPDFSection() {

            $("#PDFSection").show();

            $("#PDFSection").addClass('fade-in');

            initScroll('PDFSection');

        }

        function ToggleRowPanel(panelId) {

            var elements = document.getElementsByClassName('ValidPanel');

            var buttons = document.getElementsByClassName('ToggleButton');

            var panelIdentifier = "#" + panelId;
                       
            for (var i = 0; i < elements.length; i++) {

                if (elements[i].id != panelId) {

                    var state = $(elements[i]).is(":hidden");

                    if (state == false) {

                        $(elements[i]).toggle(1000);
                    }

                    $(buttons[i]).val("VER");
                }
                else {

                    var state = $(elements[i]).is(":hidden");

                    if (state == false) {
                        $(buttons[i]).val("VER");
                    }

                    else {
                        $(buttons[i]).val("CERRAR");
                    }
                }
            }
            
            $(panelIdentifier).toggle(1000); 
        }

        function HideRowPanel(panelId) {
            
            var panelIdentifier = "#" + panelId;

            $(panelIdentifier).hide();
        }        

        function RefreshPage() {
            location.reload();
        }

        function CloseModal() {
            $('#InsertedInspectionModal').modal('hide');
        }

    </script>



</head>
<body class="body fade-in montserrat-font">

    <!-- SUCCESS MODAL -->

    <div class="modal fade" id="InsertedInspectionModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" >
      <div class="modal-dialog modal-dialog-centered" role="document" style="width:100%;">
        <div class="modal-content">

            <!-- <div class="modal-header"> </div> -->
          <div class="modal-body">
              
              <div class="text-right">

              <button class="btn-danger search-button" value="Hpla" onclick="CloseModal();">CERRAR</button>
              </div>
              
              <iframe src="#" id="IFrame" style="width:100%; height:55rem" class="mar-top-10"></iframe>

          </div>

        </div>
      </div>
    </div>




    
    <section class="project-navbar">
  
        <p class="text-color-white text-center pt-2 pb-2">RHEEM</p>
                
    </section>

                               

    <form id="form1" runat="server" class="montserrat-font-family">


         <div class="float-button">
             <button class="btn-danger search-button" onclick="RefreshPage();">
                 INICIO
             </button>
         </div>
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            
            <asp:UpdatePanel ID="MainUpdatePanel" runat="server">
                <ContentTemplate>
                    

                    <div class="container">       

                      
                        <h3 class="text-center mar-top-30">CENTRO INTERACTIVO DE INFORMACIÓN</h3>
                        <h6 class="text-center mar-top-10">INTERACTIVE INFORMATION CENTER</h6>
                        

                        <section class="row card mar-top-30">
                            <article class="card-body">



                               <h5><strong><span class="text-color-red">ZONAS</span></strong></h5>

                                <p>Selecciona una de las zonas disponibles.</p>

                                
                                <asp:UpdatePanel ID="SliderUpdatePanel" runat="server">
                                    <ContentTemplate> 

                                
                                <asp:Panel ID="SliderPanel" runat="server" CssClass="mar-top-30" >

                                    <div class="w-50 center">
                                        
                                        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                            
                                            <ol class="carousel-indicators" id="OLDataSlide" runat="server">

                                            </ol>
                                            
                                            <div class="carousel-inner" id="DivCarouselInner" runat="server">

                                            </div>
                                            
                                            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                            
                                            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                <span class="sr-only">Next</span>
                                            </a>

                                        </div>       
                                        
                                    </div>

                                </asp:Panel>   
                                        
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel> 

                            

                                <asp:Panel ID="FoldersPanel" runat="server" CssClass="row">
                                

                                </asp:Panel>

                                                              

                            </article>
                        </section>



                        <section id="PDFSection" class="row card mar-top-30 fade-in">
                            <article class="card-body">

                                <h5 class="text-color-red""><strong><asp:Label ID="SelectedFolder" runat="server" Text="CARPETA"></asp:Label> </strong></h5>
                                
                                <div class="row">
                                    
                                    <div class="col-xs-6 col-md-6 col-lg-6">
                                        
                                        <p>Selecciona el archivo que deseas visualizar.</p>

                                    </div>

                                    <div class="col-xs-6 col-md-6 col-lg-6">

                                        <asp:UpdatePanel ID="SearchUP" runat="server">
                                           <ContentTemplate>
                                               
                                               <div class="row">

                                                  <div class="col-xs-10 col-md-10 col-lg-10">
                                                      
                                                      <asp:TextBox runat="server" ID="SearchTextBox" CssClass="form-control rounded-text-box" placeholder="BUSCAR"></asp:TextBox>

                                                  </div>
                                                   
                                                   <div class="col-xs-1 col-md-1 col-lg-1">
                                                       
                                                       <asp:ImageButton ID="SearchButton" runat="server" CssClass="btn btn-primary search-button background-accent-color" OnClick="SearchButton_Click"  Text="Buscar" ImageUrl="~/Images/baseline_search_white_18dp.png" />
                                                   
                                                   </div>

                                               </div>

                                               

                                           </ContentTemplate>
                                       </asp:UpdatePanel>
                                        
                                    </div>
                                </div>

                                    <div id="CFSSection" class="row">
                                    
                                        <div class="col-xs-12 col-md-12 col-lg-12">
                                        
                                            <p>CF'S</p>

                                        </div>

                                        <div class="col-xs-12 col-md-12 col-lg-12">
                                              <asp:UpdatePanel ID="SecondUpdateModalUpdatePanel" runat="server">
                                            <ContentTemplate>

                                                <div class="row">

                                                    <%--<div class="col-2">

                                                         <p><span class="text-color-red">Á</span>rea</p>

                                                        <asp:DropDownList ID="ZonesDropDownList"
                                                                          runat="server"
                                                                          CssClass="form-control-sm"
                                                            style="width:100%;" 
                                                            OnSelectedIndexChanged="ZonesDropDownList_SelectedIndexChanged"
                                                            


                                                                          />

                                                    </div>--%>

                                                    <div class="col-4">
                                                
                                                        <p><span class="text-color-red">E</span>lemento</p>   
                                                
                                                        <asp:DropDownList ID="OptionsDropDownList"
                                                                          runat="server"
                                                                          CssClass="form-control-sm"
                                                                          style="width:100%;"
                                                                         />

                                                    </div>
                                                
                                                    <div class="col-3">
                                                                                                            <p><span class="text-color-red">P</span>eriodo</p>   



                                                         <asp:DropDownList ID="PeriodDropDownList1"
                                                                          runat="server"
                                                                          CssClass="form-control-sm"
                                                                          style="width:100%;">
                                                             <asp:ListItem>7:00 AM / 4:30 PM</asp:ListItem>
                                                             <asp:ListItem>7:30 AM / 5:00 PM</asp:ListItem>
                                                             <asp:ListItem>8:00 AM / 5:30 PM</asp:ListItem>
                                                             <asp:ListItem>8:30 AM / 6:00 PM</asp:ListItem>
                                                             <asp:ListItem>9:00 AM / 6:30 PM</asp:ListItem>
                                                             <asp:ListItem>9:30 AM / 7:00 PM</asp:ListItem>
                                                             <asp:ListItem>10:00 AM / 7:30 PM</asp:ListItem>
                                                             <asp:ListItem>10:30 AM / 8:00 PM</asp:ListItem>
                                                             <asp:ListItem>11:00 AM / 8:30 PM</asp:ListItem>
                                                             <asp:ListItem>11:30 AM / 9:00 PM</asp:ListItem>
                                                             <asp:ListItem>12:00 PM / 9:30 PM</asp:ListItem>
                                                             <asp:ListItem>12:30 PM / 10:00 PM</asp:ListItem>
                                                             <asp:ListItem>1:00 PM / 10:30 PM</asp:ListItem>
                                                             <asp:ListItem>1:30 PM / 11:00 PM</asp:ListItem>
                                                             <asp:ListItem>2:00 PM / 11:30 PM</asp:ListItem>
                                                             <asp:ListItem>2:30 PM / 12:00 AM</asp:ListItem>
                                                             <asp:ListItem>3:00 PM / 12:30 AM</asp:ListItem>
                                                             <asp:ListItem>3:30 PM / 1:00 AM</asp:ListItem>
                                                             <asp:ListItem>4:00 PM / 1:30 AM</asp:ListItem>
                                                             <asp:ListItem>4:30 PM / 2:00 AM</asp:ListItem>
                                                             <asp:ListItem>5:00 PM / 2:30 AM</asp:ListItem>
                                                             <asp:ListItem>5:30 PM / 3:00 AM</asp:ListItem>
                                                             <asp:ListItem>6:00 PM / 3:30 AM</asp:ListItem>
                                                             <asp:ListItem>6:30 PM / 4:00 AM</asp:ListItem>
                                                             <asp:ListItem>7:00 PM / 4:30 AM</asp:ListItem>
                                                             <asp:ListItem>5:00 AM</asp:ListItem>
                                                             <asp:ListItem>5:30 AM</asp:ListItem>
                                                             <asp:ListItem Value="6:00 AM">6:00 AM</asp:ListItem>
                                                             <asp:ListItem>6:30 AM</asp:ListItem>

                                                         </asp:DropDownList>

                                                    </div>

                                                       <div class="col-3">
                                                                                                            <p><span class="text-color-red">C</span>antidad</p>   

                                                              <input id="UpdateModalMissingEmployeesTextBox"
                                                       runat="server"
                                                       class="text-center"
                                                       placeholder="Ej. 20"
                                                    onkeypress="return event.keyCode != 13;"
                                                       onkeydown="return(!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106 || (event.keyCode >= 48 && event.keyCode <= 57 && isNaN(event.key))) && event.keyCode!=32);" />

                                               

                                                    </div>

                                                       <div class="col-2">
                                                                                                            <p>.</p>   
                                                       
                                                       <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btn btn-primary search-button background-accent-color" OnClick="SearchButton_Click"  Text="Buscar" ImageUrl="~/Images/baseline_send_white_18dp.png" />
                                                   
                                                   </div>


                                                    </div>

                                                </ContentTemplate>
                                                  </asp:UpdatePanel>
                                        </div>                                    
                                    
                                    </div>


                                
                                
                                
                                
                                <asp:Panel ID="SelectedFolderPanel" runat="server">


                                    

                                       

                                    <asp:UpdatePanel ID="SearchResultPanel" runat="server">
                                        <ContentTemplate>
                                            
                                            <asp:Panel ID="ResultPanel" runat="server" CssClass="fade-in">


                                            </asp:Panel>

                                     
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                        
             



         
                                </asp:Panel>

                            </article>
                        </section>
                        

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        
        


    </form>
</body>
</html>
