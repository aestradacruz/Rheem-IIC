using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebApplication.Classes;

namespace WebApplication
{
    public partial class WebFormMain : System.Web.UI.Page
    {

        List<Folder> folderList = new List<Folder>();

        List<Files> fileList = new List<Files>();

        List<CheckBox> checkBoxes = new List<CheckBox>();

        List<Zone> zoneList = new List<Zone>();

        List<Options> optionList = new List<Options>();

        string documentsPath = ConfigurationManager.AppSettings["DocumentsPath"];

        string documentsURL  = ConfigurationManager.AppSettings["DocumentsURL"]; 

        string sliderPath    = ConfigurationManager.AppSettings["DocumentsSliderPath"];

        string sliderURL = ConfigurationManager.AppSettings["DocumentsSliderURL"];

        DBHelper dBHelper = new DBHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetFolders();

            FillSlider();

            

         
                if (!IsPostBack)
                {
                    CreateSession();
                    FillComboBoxes();
                }



        }

        private void FillComboBoxes()
        {   
            /*
            zoneList = dBHelper.GetZones();


            ZonesDropDownList.DataSource = zoneList;

            ZonesDropDownList.DataTextField = "Name";

            ZonesDropDownList.DataValueField = "Id";

            ZonesDropDownList.DataBind();

            ZonesDropDownList.Items.Insert(0, new ListItem("Lista de zonas", "")); */
        }
          

        private void CreateSession()
        {

            Session.Add("SliderFilled", false);
        }

        private void FillSlider()
        {
            var pdfFiles = Directory.GetFiles(sliderPath, "*.png");

            int j = 0;

            foreach (var directoryFile in pdfFiles)
            {
                var fileInfo = new DirectoryInfo(directoryFile);

                string name = fileInfo.Name;

                bool isActive = false;

                if (j == 0)
                    isActive = true;

                LiteralControl li = CreateLICarousel(j, isActive);

                Panel carouselItem = CreateItemCarousel(j, isActive, sliderURL + name);

                DivCarouselInner.Controls.Add(carouselItem);

                OLDataSlide.Controls.Add(li);

                j++;
            }

            pdfFiles = Directory.GetFiles(sliderPath, "*.jpg");

            foreach (var directoryFile in pdfFiles)
            {
                var fileInfo = new DirectoryInfo(directoryFile);

                string name = fileInfo.Name;

                bool isActive = false;

                if (j == 0)
                    isActive = true;

                LiteralControl li = CreateLICarousel(j, isActive);

                Panel carouselItem = CreateItemCarousel(j, isActive, sliderURL + name);

                DivCarouselInner.Controls.Add(carouselItem);

                OLDataSlide.Controls.Add(li);

                j++;
            }

            Session["SliderFilled"] = true;
        }

        private LiteralControl CreateLICarousel(int index, bool isActive)
        {
            string doubleQuote = "\"";

            LiteralControl li = new LiteralControl(@"<li data-target=" + doubleQuote + "#carouselExampleIndicators" + doubleQuote   
                                                     + "data-slide-to="+ doubleQuote + index + doubleQuote +"></li>");

            if(isActive)
                li.Text = @"<li data-target=" + doubleQuote + "#carouselExampleIndicators" + doubleQuote
                                                     + "data-slide-to=" + doubleQuote + index + doubleQuote + " class=" + doubleQuote + "active" + doubleQuote + "></li>"; 

            return li;            
        }

        private Panel CreateItemCarousel(int index, bool isActive, string imageSRC)
        {
            Panel panel = new Panel();

            panel.CssClass = "carousel-item";

            if (isActive)
                panel.CssClass = "carousel-item active";

            Image image = new Image();

            image.CssClass = "d-block w-100";

            image.ImageUrl = imageSRC;

            image.AlternateText = index + "slide";

            panel.Controls.Add(image);

            return panel;
        }


        private void GetFolders()
        {
            var directories = Directory.GetDirectories(documentsPath);

            folderList.Clear();

            int id = 0;

            foreach(var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);

                Folder folder = new Folder();

                folder.Id = id;
                folder.Name = directoryInfo.Name;

                if (!folder.Name.Contains("SLIDER"))
                {
                    FoldersPanel.Controls.Add(CreateCardFolderPanel(directoryInfo.Name, folder.Id));

                    folderList.Add(folder);

                    id++;
                }



            }

            Session["folderList"] = folderList;
        }

        private Panel CreateCardFolderPanel(string folderName, int id)
        {
            Panel columnPanel = CreateColumnPanel();

            Panel cardView = CreateCardView();
                     
            cardView.Controls[0].Controls.Add(CreateFolderImage(folderName, id));

            cardView.Controls[0].Controls.Add(new LiteralControl(@"<br />"));

            cardView.Controls[0].Controls.Add(CreateFolderLabel(folderName, "h6"));

            cardView.Controls[0].Controls.Add(CreateFolderLinkButton(id));

            columnPanel.Controls.Add(cardView);

            return columnPanel;
        }

        private Panel CreateColumnPanel()
        {
            Panel columnPanel = new Panel();

            columnPanel.CssClass = "col-xs-4 col-md-4 col-lg-4";

            return columnPanel;
        }

        private Panel CreateCardView()
        {
            Panel cardPanel = new Panel();

            cardPanel.CssClass = "card link-panel";

            cardPanel.Attributes.CssStyle.Add("margin-top", "10px");

            cardPanel.Attributes.CssStyle.Add("width", "90%");

            Panel cardBody = new Panel();

            cardBody.CssClass = "card-body text-center";

            cardPanel.Controls.Add(cardBody);

            return cardPanel;
        }
        
        private LinkButton CreateFolderImage(string folderName, int id)
        {
            LinkButton ImageLinkButton = new LinkButton();

            ImageLinkButton.ID = folderName;

            Image folderImage = new Image();

            folderImage.ImageUrl = documentsURL + folderName + "/icon.png";

            folderImage.Attributes.Add("Width", "15%");

            folderImage.CssClass = "img-center";

            ImageLinkButton.Attributes.Add("AutoPostBack", "true");

            ImageLinkButton.Click += ImageLinkButton_Click; ;

            ImageLinkButton.Controls.Add(folderImage);

            return ImageLinkButton;
        }

        private void ImageLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            string folderSelected = linkButton.ID;

            CreateFolderFilesRow(folderSelected);
            
        }

        private Label CreateFolderLabel(string folderName, string headerType)
        {
            Label label = new Label
            {
                Text = folderName + "<br/>"
            };

            label.CssClass =  headerType;
            label.Attributes.Add("font-weight", "bold");

            return label;
        }

        private LinkButton CreateFolderLinkButton(int id)
        {
            LinkButton folderLinkButton = new LinkButton
            {
                Text = "SELECCIONAR",
                ID = id.ToString(),
                
            };

            folderLinkButton.Click += FolderLinkButton_Click;

            folderLinkButton.Attributes.Add("AutoPostBack", "true");

            return folderLinkButton;
        }
                       
        private void FolderLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;

            string folderSelected = folderList[Int16.Parse(linkButton.ID)].Name;

            CreateFolderFilesRow(folderSelected);
            
            DoSome(folderSelected);
        }

        private void DoSome(string SelectedZone)
        {

            optionList = dBHelper.GetOptionsByZoneName(SelectedZone.Remove(0,3));
            
            if(optionList.Count > 0)
            {
                OptionsDropDownList.DataSource = optionList;

                OptionsDropDownList.DataTextField = "Name";

                OptionsDropDownList.DataValueField = "Id";

                OptionsDropDownList.DataBind();

                OptionsDropDownList.Items.Insert(0, new ListItem("Lista de elementos", ""));

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "ShowCFSPanel", "ShowCFSPanel();", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "HideCFSPanel", "HideCFSPanel();", true);

            }

        }


        public void CreateFolderFilesRow(string selectedFolder)
        {
            Session["SelectedFolder"] = selectedFolder;
            
            SelectedFolder.Text = selectedFolder.ToUpper();

            GetSelectedFolderFolders(selectedFolder);

            GetMainFolderPDF(selectedFolder, SelectedFolderPanel);

            GetMainFolderVideos(selectedFolder, SelectedFolderPanel);

            SearchTextBox.Text = "";

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "ShowPDFSection", "ShowPDFSection();", true);
        }

        private Image CreatePDFIcon()
        {
            Image pdfIcon = new Image();

            pdfIcon.ImageUrl = "Images/pdf-icon.png";

            pdfIcon.Attributes.Add("Width", "15%");

            pdfIcon.CssClass = "img-center";

            return pdfIcon;
        }

        private HyperLink CreatePDFLink(string id, string text, string href)
        {
            HyperLink link = new HyperLink();

            link.ID = id;
            link.Text = text;
                       
            link.CssClass = "pdf-link";
            link.Attributes["OnClick"] = "ShowFrame('" + href + "')";
            
            link.Attributes["runat"] = "server";

            link.Attributes.Add("download", "");
            return link;
        }
                
        private void GetSelectedFolderFolders(string selectedFolderName)
        {
            var directories = Directory.GetDirectories(documentsPath + selectedFolderName);

            int idRowPanel = 0;

            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);

                #region ROW TITLE

                Panel rowTitlePanel = CreateRowPanel();


                Panel titleColumn = new Panel();

                titleColumn.CssClass = "col-xs-10 col-md-10 col-lg-10 mar-top-20";

                titleColumn.Controls.Add(CreateFolderLabel(directoryInfo.Name.ToUpper(), ""));


                Panel buttonColumn = new Panel();

                buttonColumn.CssClass = "col-xs-1 col-md-1 col-lg-1 mar-top-20";


                rowTitlePanel.Controls.Add(buttonColumn);
                rowTitlePanel.Controls.Add(titleColumn);

                #endregion

                #region ROW FILES

                string filesRowPanelId = "FilesRowPanel" + idRowPanel;




                Panel filesRowPanel = CreateRowPanel();

                filesRowPanel.ID = filesRowPanelId;

                filesRowPanel.CssClass = "row TogglePanel";

//                filesRowPanel.Attributes.Add("hidden", "");

                #endregion

                SelectedFolderPanel.Controls.Add(rowTitlePanel);

                // GET PDF FILES
                var pdfFiles = Directory.GetFiles(documentsPath + selectedFolderName + @"\" + directoryInfo.Name, "*.pdf");

                int id = 0;
                
                foreach (var directoryFile in pdfFiles)
                {
                    var fileInfo = new DirectoryInfo(directoryFile);

                    Panel columnPanel = CreateColumnPanel(); 

                    Panel cardView = CreateCardView();
                    
                    Image pdfImage = CreatePDFIcon();

                    HyperLink link = CreatePDFLink(id.ToString(), fileInfo.Name.ToUpper(), documentsURL + selectedFolderName + "/" + directoryInfo.Name + "/" + fileInfo.Name);

                    link.ForeColor = System.Drawing.Color.SteelBlue;
                    
                    cardView.Controls[0].Controls.Add(pdfImage);
                    cardView.Controls[0].Controls.Add(link);

                    columnPanel.Controls.Add(cardView);

                    filesRowPanel.Controls.Add(columnPanel);


                    id++;
                }

                if (id > 0)
                {

                    filesRowPanel.CssClass += " ValidPanel";
                }

                // Obtenemos archivos MP4
                var videoFiles = Directory.GetFiles(documentsPath + selectedFolderName + @"\" + directoryInfo.Name, "*.mp4");

                foreach (var directoryVideo in videoFiles)
                {

                    Panel columnPanel = CreateColumnPanel();

                    var videoInfo = new DirectoryInfo(directoryVideo);

                    HtmlGenericControl video = new HtmlGenericControl("video");
                    video.Attributes["width"] = "100%";
                    video.Attributes.Add("controls", "");

                    HtmlGenericControl source = new HtmlGenericControl("source");

                    source.Attributes["src"] = documentsURL + selectedFolderName + "/" + directoryInfo.Name + "/" + videoInfo.Name;
                    source.Attributes["type"] = "video/mp4";

                    video.Controls.Add(source);

                    Label videoLabel = new Label()
                    {
                        Text = videoInfo.Name
                    };

                    Panel cardView = CreateCardView();

                    cardView.Controls[0].Controls.Add(video);

                    cardView.Controls[0].Controls.Add(videoLabel);

                    cardView.Controls[0].Controls.Add(CreateVideoIntructionsPanel());


                    columnPanel.Controls.Add(cardView);

                    filesRowPanel.Controls.Add(columnPanel);
                }

                if (pdfFiles.Length > 0 | videoFiles.Length > 0)
                {
                    HtmlInputButton button = new HtmlInputButton();

                    button.ID = "FilesRowButton" + idRowPanel;

                    button.Value = "VER";

                    button.Attributes.Add("class", "btn-info ToggleButton");

                    buttonColumn.Controls.Add(button);

                    button.Attributes.Add("onClick", "ToggleRowPanel('" + filesRowPanelId + "')");
                }

                idRowPanel++;

                SelectedFolderPanel.Controls.Add(filesRowPanel);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "HideRowPanel" + idRowPanel, "HideRowPanel('" + filesRowPanelId + "');", true);
            }
        }
               
        private void GetMainFolderPDF(string folderName, Panel targetPanel)
        {
            var directories = Directory.GetFiles(documentsPath + folderName, "*.pdf");

            if (directories.Length > 0)
            {
                int id = 0;

                Panel titlePanel = new Panel();

                titlePanel.CssClass = "col-xs-12 col-md-12 col-lg-12 mar-top-20";

                titlePanel.Controls.Add(new Label()
                {
                    Text = "OTROS",
                    CssClass = "card-title h5"
                });

                SelectedFolderPanel.Controls.Add(titlePanel);

                foreach (var directory in directories)
                {
                    var directoryInfo = new DirectoryInfo(directory);

                    Panel columnPanel = CreateColumnPanel();

                    Panel cardView = CreateCardView();

                    Image pdfImage = CreatePDFIcon();

                    HyperLink link = CreatePDFLink(id.ToString(), directoryInfo.Name.ToUpper(), documentsURL + folderName + "/" + directoryInfo.Name); 

                    cardView.Controls[0].Controls.Add(pdfImage);

                    cardView.Controls[0].Controls.Add(link);

                    columnPanel.Controls.Add(cardView);

                    targetPanel.Controls.Add(columnPanel);

                    id++;
                }

            }
        }

        private void GetMainFolderVideos(string folderName, Panel targetPanel)
        {
            var directories = Directory.GetFiles(documentsPath + folderName, "*.mp4");

            foreach (var directory in directories)
            {
                Panel columnPanel = CreateColumnPanel();

                var directoryInfo = new DirectoryInfo(directory);

                HtmlGenericControl video = new HtmlGenericControl("video");
                video.Attributes["width"] = "100%";
                video.Attributes.Add("controls", "");

                HtmlGenericControl source = new HtmlGenericControl("source");

                source.Attributes["src"] = documentsURL + folderName + "/" + directoryInfo.Name;
                source.Attributes["type"] = "video/mp4";

                video.Controls.Add(source);

                Label videoLabel = new Label()
                {
                    Text = directoryInfo.Name
                };

                Panel cardView = CreateCardView();

                cardView.Controls[0].Controls.Add(video);

                cardView.Controls[0].Controls.Add(videoLabel);

                cardView.Controls[0].Controls.Add(CreateVideoIntructionsPanel());

                columnPanel.Controls.Add(cardView);

                targetPanel.Controls.Add(columnPanel);
            }
        }


        private Panel CreateRowPanel()
        {
            Panel rowPanel = new Panel();

            rowPanel.CssClass = "row";

            return rowPanel;
        }          

        private Panel CreateVideoIntructionsPanel()
        {
            Panel container = new Panel();

            Panel extendVideoRowPanel = new Panel() {
                    CssClass = "row"
            };

            Panel escVideoRowPanel = new Panel()
            {
                CssClass = "row"
            };

            Panel imageColumn = new Panel() {

                CssClass = "col-xs-1 col-md-1 col-lg-1"
            };

            Panel instructionColumn = new Panel() {

                CssClass = "col-xs-10 col-md-10 col-lg-10 text-left"
            };


            Panel escImageColumn = new Panel() {
                CssClass = "col-xs-2 col-md-2 col-lg-2"
            }; 

            Panel escInstructionColumn = new Panel() {
                CssClass = "col-xs-10 col-md-10 col-lg-10 text-left"
            };



            Image extendIconImage = new Image()
            {
                ImageUrl = "Images/img - expand.svg"
            };            

            imageColumn.Controls.Add(extendIconImage);

            Label extendVideoLabel = new Label()
            {
                Text = "Pantalla completa"
            };

            instructionColumn.Controls.Add(extendVideoLabel);

            extendVideoRowPanel.Controls.Add(imageColumn);

            extendVideoRowPanel.Controls.Add(instructionColumn);

            Image escIconImage = new Image()
            {
                ImageUrl = "Images/img - esc.svg"
            };

            escImageColumn.Controls.Add(escIconImage);

            Label escVideoLabel = new Label()
            {
                Text = "Salir de pantalla completa"
            };

            escInstructionColumn.Controls.Add(escVideoLabel);

            escVideoRowPanel.Controls.Add(escImageColumn);
            escVideoRowPanel.Controls.Add(escVideoLabel);

            container.Controls.Add(extendVideoRowPanel);
            container.Controls.Add(escVideoRowPanel);


            return container;
        }

        protected void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(SearchTextBox.Text))
            {               
                SearchDocuments(SearchTextBox.Text);
            }
        }

        protected void SearchDocuments(string filesName)
        {
            string path = documentsPath + @"\" + Session["selectedFolder"];

            var directories = Directory.GetDirectories(path);

            Panel filesRowPanel = CreateRowPanel();


            int counter = 0;

            foreach(var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);


                var pdfFiles = Directory.GetFiles(directory+ @"\", "*"+ filesName+ "*.pdf");

                int countFiles = pdfFiles.ToList().Count;

                int id = 0;

                foreach (var directoryFile in pdfFiles)
                {

                    Panel columnPanel = CreateColumnPanel();

                    Panel cardView = CreateCardView();

                    var fileInfo = new DirectoryInfo(directoryFile);


                    Image pdfImage = CreatePDFIcon();

                    HyperLink link = CreatePDFLink(id.ToString(), fileInfo.Name.ToUpper(), documentsURL + Session["selectedFolder"] + "/" + directoryInfo.Name + "/" + fileInfo.Name);


                    cardView.Controls[0].Controls.Add(pdfImage);
                    cardView.Controls[0].Controls.Add(link);

                    columnPanel.Controls.Add(cardView);

                    filesRowPanel.Controls.Add(columnPanel);

                    id++;
                }


                var videoFiles = Directory.GetFiles(directory + @"\", "*" + filesName + "*.mp4");

                foreach (var directoryVideo in videoFiles)
                {

                    Panel columnPanel = CreateColumnPanel();

                    var videoInfo = new DirectoryInfo(directoryVideo);

                    HtmlGenericControl video = new HtmlGenericControl("video");
                    video.Attributes["width"] = "100%";
                    video.Attributes.Add("controls", "");

                    HtmlGenericControl source = new HtmlGenericControl("source");

                    source.Attributes["src"] = documentsURL + Session["selectedFolder"] + "/" + directoryInfo.Name + "/" + videoInfo.Name;                    //                     link.Attributes["href"] = documentsURL + selectedFolderName + "/" + directoryInfo.Name + "/" + file.Name;

                    source.Attributes["type"] = "video/mp4";

                    video.Controls.Add(source);

                    Label videoLabel = new Label()
                    {
                        Text = videoInfo.Name
                    };

                    Panel cardView = CreateCardView();

                    cardView.Controls[0].Controls.Add(video);

                    cardView.Controls[0].Controls.Add(videoLabel);

                    cardView.Controls[0].Controls.Add(CreateVideoIntructionsPanel());


                    columnPanel.Controls.Add(cardView);

                    filesRowPanel.Controls.Add(columnPanel);

                }

                ResultPanel.Controls.Add(filesRowPanel);

                counter++;
            }

        }

        protected void ZonesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string boe = "";
        }
    }
}

// 698