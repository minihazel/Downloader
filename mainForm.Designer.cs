namespace Downloader
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            hubPanel = new Panel();
            titleStatus = new Label();
            btnViewOptions = new Button();
            btnSaveURL = new Button();
            btnBrowsePath = new Button();
            label2 = new Label();
            textwarning = new Label();
            pathbox = new Panel();
            destinationpath = new TextBox();
            lblURL = new Label();
            urlbox = new Panel();
            destinationurl = new TextBox();
            settingsPanel = new Panel();
            btnViewMain = new Button();
            listSettings = new Panel();
            textytdlp = new TextBox();
            titleSavedPath = new Label();
            chkToggleFirstTimeMessage = new CheckBox();
            listDefaultVideoExt = new ComboBox();
            titleDefaultAudioExt = new Label();
            listDefaultAudioExt = new ComboBox();
            titleDefaultVideoExt = new Label();
            chkToggleOpen = new CheckBox();
            chkToggleSave = new CheckBox();
            titleSettings = new Label();
            panelVideoSettings = new Panel();
            btnReturnToMainPage = new Button();
            textPlaceholderLink = new Label();
            divider4 = new Panel();
            chkShowInfo = new CheckBox();
            chkForceFileExtension = new CheckBox();
            btnClearSettings = new Button();
            lblSettingsSaved = new Label();
            btnSaveExtensionSettings = new Button();
            listPreferFPS = new ComboBox();
            lblPreferFPS = new Label();
            statusAudioWarning = new Label();
            btnDownloadVideo = new Button();
            listPreferRes = new ComboBox();
            lblPreferRes = new Label();
            listAudioExt = new ComboBox();
            lblAudioExt = new Label();
            listVideoExt = new ComboBox();
            divider1 = new Panel();
            lblForceExtVideo = new Label();
            titleFetched = new Label();
            panelFirstTime = new Panel();
            linkffmpeg = new Label();
            statusytdlp = new Label();
            btnBrowseYTDLP = new Button();
            btnAcknowledgeFirstTime = new Button();
            linkytdlp = new Label();
            linkvlc = new Label();
            lblFirstTime = new Label();
            panelDownloading = new Panel();
            panelInfo = new Panel();
            btnCancelDownload = new Button();
            infoExportFolder = new Label();
            infoFileName = new Label();
            infoTimePassed = new Label();
            dataOutputBorder = new Panel();
            dataOutput = new RichTextBox();
            statusDownloading = new Label();
            pathTooltip = new ToolTip(components);
            hubPanel.SuspendLayout();
            pathbox.SuspendLayout();
            urlbox.SuspendLayout();
            settingsPanel.SuspendLayout();
            listSettings.SuspendLayout();
            panelVideoSettings.SuspendLayout();
            panelFirstTime.SuspendLayout();
            panelDownloading.SuspendLayout();
            panelInfo.SuspendLayout();
            dataOutputBorder.SuspendLayout();
            SuspendLayout();
            // 
            // hubPanel
            // 
            hubPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hubPanel.Controls.Add(titleStatus);
            hubPanel.Controls.Add(btnViewOptions);
            hubPanel.Controls.Add(btnSaveURL);
            hubPanel.Controls.Add(btnBrowsePath);
            hubPanel.Controls.Add(label2);
            hubPanel.Controls.Add(textwarning);
            hubPanel.Controls.Add(pathbox);
            hubPanel.Controls.Add(lblURL);
            hubPanel.Controls.Add(urlbox);
            hubPanel.Location = new Point(12, 38);
            hubPanel.Name = "hubPanel";
            hubPanel.Size = new Size(1026, 583);
            hubPanel.TabIndex = 0;
            // 
            // titleStatus
            // 
            titleStatus.Font = new Font("Bahnschrift Light", 10F);
            titleStatus.ForeColor = Color.Gray;
            titleStatus.Location = new Point(363, 489);
            titleStatus.Name = "titleStatus";
            titleStatus.Padding = new Padding(0, 20, 0, 0);
            titleStatus.Size = new Size(300, 91);
            titleStatus.TabIndex = 16;
            titleStatus.Text = "Fetching video information...";
            titleStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnViewOptions
            // 
            btnViewOptions.BackColor = Color.FromArgb(38, 40, 42);
            btnViewOptions.Cursor = Cursors.Hand;
            btnViewOptions.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnViewOptions.FlatStyle = FlatStyle.Flat;
            btnViewOptions.Font = new Font("Bahnschrift Light", 14F);
            btnViewOptions.ForeColor = Color.DarkGray;
            btnViewOptions.Location = new Point(10, 10);
            btnViewOptions.Name = "btnViewOptions";
            btnViewOptions.Size = new Size(135, 45);
            btnViewOptions.TabIndex = 15;
            btnViewOptions.Text = "⚙️  Main";
            btnViewOptions.TextAlign = ContentAlignment.MiddleLeft;
            btnViewOptions.UseVisualStyleBackColor = false;
            btnViewOptions.Click += btnViewOptions_Click;
            // 
            // btnSaveURL
            // 
            btnSaveURL.BackColor = Color.FromArgb(38, 40, 42);
            btnSaveURL.Cursor = Cursors.Hand;
            btnSaveURL.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnSaveURL.FlatStyle = FlatStyle.Flat;
            btnSaveURL.Font = new Font("Bahnschrift Light", 14F);
            btnSaveURL.ForeColor = Color.DarkGray;
            btnSaveURL.Location = new Point(363, 436);
            btnSaveURL.Name = "btnSaveURL";
            btnSaveURL.Size = new Size(300, 50);
            btnSaveURL.TabIndex = 14;
            btnSaveURL.Text = "📥  Fetch video info";
            btnSaveURL.UseVisualStyleBackColor = false;
            btnSaveURL.Click += btnSaveURL_Click;
            // 
            // btnBrowsePath
            // 
            btnBrowsePath.BackColor = Color.FromArgb(38, 40, 42);
            btnBrowsePath.Cursor = Cursors.Hand;
            btnBrowsePath.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnBrowsePath.FlatStyle = FlatStyle.Flat;
            btnBrowsePath.Font = new Font("Bahnschrift Light", 14F);
            btnBrowsePath.ForeColor = Color.DarkGray;
            btnBrowsePath.Location = new Point(835, 311);
            btnBrowsePath.Name = "btnBrowsePath";
            btnBrowsePath.Size = new Size(45, 45);
            btnBrowsePath.TabIndex = 13;
            btnBrowsePath.Text = "🔍";
            btnBrowsePath.UseVisualStyleBackColor = false;
            btnBrowsePath.Click += btnBrowsePath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Light", 8F);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(147, 359);
            label2.Name = "label2";
            label2.Size = new Size(181, 13);
            label2.TabIndex = 12;
            label2.Text = "We suggest your Downloads folder.";
            // 
            // textwarning
            // 
            textwarning.AutoSize = true;
            textwarning.Font = new Font("Bahnschrift Light", 8F);
            textwarning.ForeColor = Color.Gray;
            textwarning.Location = new Point(147, 259);
            textwarning.Name = "textwarning";
            textwarning.Size = new Size(219, 13);
            textwarning.TabIndex = 4;
            textwarning.Text = "URL origin cannot contain a restricted link.";
            // 
            // pathbox
            // 
            pathbox.BackColor = Color.FromArgb(20, 22, 24);
            pathbox.BorderStyle = BorderStyle.FixedSingle;
            pathbox.Controls.Add(destinationpath);
            pathbox.Cursor = Cursors.Hand;
            pathbox.Location = new Point(147, 311);
            pathbox.Name = "pathbox";
            pathbox.Size = new Size(682, 45);
            pathbox.TabIndex = 3;
            // 
            // destinationpath
            // 
            destinationpath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            destinationpath.BackColor = Color.FromArgb(20, 22, 24);
            destinationpath.BorderStyle = BorderStyle.None;
            destinationpath.Cursor = Cursors.Hand;
            destinationpath.Font = new Font("Bahnschrift Light", 12F);
            destinationpath.ForeColor = Color.DarkGray;
            destinationpath.Location = new Point(11, 12);
            destinationpath.Name = "destinationpath";
            destinationpath.PlaceholderText = "Browse for a destination..";
            destinationpath.ReadOnly = true;
            destinationpath.Size = new Size(655, 20);
            destinationpath.TabIndex = 3;
            destinationpath.KeyDown += destinationpath_KeyDown;
            destinationpath.MouseDown += destinationpath_MouseDown;
            // 
            // lblURL
            // 
            lblURL.Font = new Font("Bahnschrift Light", 14F);
            lblURL.Location = new Point(147, 10);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(733, 198);
            lblURL.TabIndex = 2;
            lblURL.Text = "Downloader - your one-stop shop for downloading videos";
            lblURL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // urlbox
            // 
            urlbox.BackColor = Color.FromArgb(20, 22, 24);
            urlbox.BorderStyle = BorderStyle.FixedSingle;
            urlbox.Controls.Add(destinationurl);
            urlbox.Cursor = Cursors.IBeam;
            urlbox.Location = new Point(147, 211);
            urlbox.Name = "urlbox";
            urlbox.Size = new Size(733, 45);
            urlbox.TabIndex = 0;
            urlbox.MouseDown += urlbox_MouseDown;
            // 
            // destinationurl
            // 
            destinationurl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            destinationurl.BackColor = Color.FromArgb(20, 22, 24);
            destinationurl.BorderStyle = BorderStyle.None;
            destinationurl.Cursor = Cursors.IBeam;
            destinationurl.Font = new Font("Bahnschrift Light", 12F);
            destinationurl.ForeColor = Color.DarkGray;
            destinationurl.Location = new Point(11, 11);
            destinationurl.Name = "destinationurl";
            destinationurl.PlaceholderText = "Paste the URL...";
            destinationurl.Size = new Size(706, 20);
            destinationurl.TabIndex = 3;
            destinationurl.KeyDown += destinationurl_KeyDown;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(btnViewMain);
            settingsPanel.Controls.Add(listSettings);
            settingsPanel.Controls.Add(titleSettings);
            settingsPanel.Location = new Point(12, 38);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(1026, 583);
            settingsPanel.TabIndex = 1;
            // 
            // btnViewMain
            // 
            btnViewMain.BackColor = Color.FromArgb(38, 40, 42);
            btnViewMain.Cursor = Cursors.Hand;
            btnViewMain.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnViewMain.FlatStyle = FlatStyle.Flat;
            btnViewMain.Font = new Font("Bahnschrift Light", 14F);
            btnViewMain.ForeColor = Color.DarkGray;
            btnViewMain.Location = new Point(10, 10);
            btnViewMain.Name = "btnViewMain";
            btnViewMain.Size = new Size(135, 45);
            btnViewMain.TabIndex = 16;
            btnViewMain.Text = "⚙️  Settings";
            btnViewMain.TextAlign = ContentAlignment.MiddleLeft;
            btnViewMain.UseVisualStyleBackColor = false;
            btnViewMain.Click += btnViewMain_Click;
            // 
            // listSettings
            // 
            listSettings.BackColor = Color.FromArgb(24, 26, 28);
            listSettings.Controls.Add(textytdlp);
            listSettings.Controls.Add(titleSavedPath);
            listSettings.Controls.Add(chkToggleFirstTimeMessage);
            listSettings.Controls.Add(listDefaultVideoExt);
            listSettings.Controls.Add(titleDefaultAudioExt);
            listSettings.Controls.Add(listDefaultAudioExt);
            listSettings.Controls.Add(titleDefaultVideoExt);
            listSettings.Controls.Add(chkToggleOpen);
            listSettings.Controls.Add(chkToggleSave);
            listSettings.Font = new Font("Bahnschrift Light", 14F);
            listSettings.Location = new Point(260, 80);
            listSettings.Name = "listSettings";
            listSettings.Size = new Size(507, 391);
            listSettings.TabIndex = 0;
            // 
            // textytdlp
            // 
            textytdlp.BackColor = Color.FromArgb(20, 22, 24);
            textytdlp.Cursor = Cursors.Hand;
            textytdlp.ForeColor = Color.LightGray;
            textytdlp.Location = new Point(257, 262);
            textytdlp.Multiline = true;
            textytdlp.Name = "textytdlp";
            textytdlp.PlaceholderText = "Path...";
            textytdlp.ReadOnly = true;
            textytdlp.Size = new Size(236, 30);
            textytdlp.TabIndex = 9;
            textytdlp.MouseDown += textytdlp_MouseDown;
            // 
            // titleSavedPath
            // 
            titleSavedPath.Location = new Point(1, 251);
            titleSavedPath.Name = "titleSavedPath";
            titleSavedPath.Padding = new Padding(12, 0, 0, 0);
            titleSavedPath.Size = new Size(250, 50);
            titleSavedPath.TabIndex = 8;
            titleSavedPath.Text = "Saved path to yt-dlp.exe:";
            titleSavedPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkToggleFirstTimeMessage
            // 
            chkToggleFirstTimeMessage.BackColor = Color.FromArgb(20, 22, 24);
            chkToggleFirstTimeMessage.Cursor = Cursors.Hand;
            chkToggleFirstTimeMessage.Location = new Point(1, 101);
            chkToggleFirstTimeMessage.Name = "chkToggleFirstTimeMessage";
            chkToggleFirstTimeMessage.Padding = new Padding(15, 0, 0, 0);
            chkToggleFirstTimeMessage.Size = new Size(505, 50);
            chkToggleFirstTimeMessage.TabIndex = 6;
            chkToggleFirstTimeMessage.Text = "Display first-time message";
            chkToggleFirstTimeMessage.TextAlign = ContentAlignment.MiddleCenter;
            chkToggleFirstTimeMessage.UseVisualStyleBackColor = false;
            chkToggleFirstTimeMessage.CheckedChanged += chkToggleFirstTimeMessage_CheckedChanged;
            // 
            // listDefaultVideoExt
            // 
            listDefaultVideoExt.BackColor = Color.FromArgb(24, 26, 28);
            listDefaultVideoExt.Cursor = Cursors.Hand;
            listDefaultVideoExt.DropDownStyle = ComboBoxStyle.DropDownList;
            listDefaultVideoExt.ForeColor = Color.LightGray;
            listDefaultVideoExt.FormattingEnabled = true;
            listDefaultVideoExt.Location = new Point(257, 162);
            listDefaultVideoExt.Name = "listDefaultVideoExt";
            listDefaultVideoExt.Size = new Size(236, 31);
            listDefaultVideoExt.TabIndex = 5;
            listDefaultVideoExt.SelectedIndexChanged += listDefaultVideoExt_SelectedIndexChanged;
            // 
            // titleDefaultAudioExt
            // 
            titleDefaultAudioExt.Location = new Point(1, 201);
            titleDefaultAudioExt.Name = "titleDefaultAudioExt";
            titleDefaultAudioExt.Padding = new Padding(12, 0, 0, 0);
            titleDefaultAudioExt.Size = new Size(250, 50);
            titleDefaultAudioExt.TabIndex = 4;
            titleDefaultAudioExt.Text = "Default audio extension:";
            titleDefaultAudioExt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listDefaultAudioExt
            // 
            listDefaultAudioExt.BackColor = Color.FromArgb(24, 26, 28);
            listDefaultAudioExt.Cursor = Cursors.Hand;
            listDefaultAudioExt.DropDownStyle = ComboBoxStyle.DropDownList;
            listDefaultAudioExt.ForeColor = Color.LightGray;
            listDefaultAudioExt.FormattingEnabled = true;
            listDefaultAudioExt.Location = new Point(257, 212);
            listDefaultAudioExt.Name = "listDefaultAudioExt";
            listDefaultAudioExt.Size = new Size(236, 31);
            listDefaultAudioExt.TabIndex = 3;
            listDefaultAudioExt.SelectedIndexChanged += listDefaultAudioExt_SelectedIndexChanged;
            // 
            // titleDefaultVideoExt
            // 
            titleDefaultVideoExt.Location = new Point(1, 151);
            titleDefaultVideoExt.Name = "titleDefaultVideoExt";
            titleDefaultVideoExt.Padding = new Padding(12, 0, 0, 0);
            titleDefaultVideoExt.Size = new Size(250, 50);
            titleDefaultVideoExt.TabIndex = 2;
            titleDefaultVideoExt.Text = "Default video extension:";
            titleDefaultVideoExt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkToggleOpen
            // 
            chkToggleOpen.BackColor = Color.FromArgb(20, 22, 24);
            chkToggleOpen.Cursor = Cursors.Hand;
            chkToggleOpen.Location = new Point(1, 51);
            chkToggleOpen.Name = "chkToggleOpen";
            chkToggleOpen.Padding = new Padding(15, 0, 0, 0);
            chkToggleOpen.Size = new Size(505, 50);
            chkToggleOpen.TabIndex = 1;
            chkToggleOpen.Text = "Ask where to save downloaded video";
            chkToggleOpen.TextAlign = ContentAlignment.MiddleCenter;
            chkToggleOpen.UseVisualStyleBackColor = false;
            chkToggleOpen.CheckedChanged += chkToggleOpen_CheckedChanged;
            // 
            // chkToggleSave
            // 
            chkToggleSave.BackColor = Color.FromArgb(20, 22, 24);
            chkToggleSave.Cursor = Cursors.Hand;
            chkToggleSave.Location = new Point(1, 1);
            chkToggleSave.Name = "chkToggleSave";
            chkToggleSave.Padding = new Padding(15, 0, 0, 0);
            chkToggleSave.Size = new Size(505, 50);
            chkToggleSave.TabIndex = 0;
            chkToggleSave.Text = "Open destination folder on save";
            chkToggleSave.TextAlign = ContentAlignment.MiddleCenter;
            chkToggleSave.UseVisualStyleBackColor = false;
            chkToggleSave.CheckedChanged += chkToggleSave_CheckedChanged;
            // 
            // titleSettings
            // 
            titleSettings.Font = new Font("Bahnschrift Light", 14F);
            titleSettings.Location = new Point(260, 10);
            titleSettings.Name = "titleSettings";
            titleSettings.Size = new Size(507, 45);
            titleSettings.TabIndex = 3;
            titleSettings.Text = "Downloader - settings";
            titleSettings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelVideoSettings
            // 
            panelVideoSettings.Controls.Add(btnReturnToMainPage);
            panelVideoSettings.Controls.Add(textPlaceholderLink);
            panelVideoSettings.Controls.Add(divider4);
            panelVideoSettings.Controls.Add(chkShowInfo);
            panelVideoSettings.Controls.Add(chkForceFileExtension);
            panelVideoSettings.Controls.Add(btnClearSettings);
            panelVideoSettings.Controls.Add(lblSettingsSaved);
            panelVideoSettings.Controls.Add(btnSaveExtensionSettings);
            panelVideoSettings.Controls.Add(listPreferFPS);
            panelVideoSettings.Controls.Add(lblPreferFPS);
            panelVideoSettings.Controls.Add(statusAudioWarning);
            panelVideoSettings.Controls.Add(btnDownloadVideo);
            panelVideoSettings.Controls.Add(listPreferRes);
            panelVideoSettings.Controls.Add(lblPreferRes);
            panelVideoSettings.Controls.Add(listAudioExt);
            panelVideoSettings.Controls.Add(lblAudioExt);
            panelVideoSettings.Controls.Add(listVideoExt);
            panelVideoSettings.Controls.Add(divider1);
            panelVideoSettings.Controls.Add(lblForceExtVideo);
            panelVideoSettings.Controls.Add(titleFetched);
            panelVideoSettings.Location = new Point(12, 38);
            panelVideoSettings.Name = "panelVideoSettings";
            panelVideoSettings.Size = new Size(1026, 583);
            panelVideoSettings.TabIndex = 2;
            // 
            // btnReturnToMainPage
            // 
            btnReturnToMainPage.BackColor = Color.FromArgb(38, 40, 42);
            btnReturnToMainPage.Cursor = Cursors.Hand;
            btnReturnToMainPage.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnReturnToMainPage.FlatStyle = FlatStyle.Flat;
            btnReturnToMainPage.Font = new Font("Bahnschrift Light", 10F);
            btnReturnToMainPage.ForeColor = Color.DarkGray;
            btnReturnToMainPage.Location = new Point(840, 19);
            btnReturnToMainPage.Name = "btnReturnToMainPage";
            btnReturnToMainPage.Size = new Size(183, 47);
            btnReturnToMainPage.TabIndex = 54;
            btnReturnToMainPage.Text = "↩️  Back to search";
            btnReturnToMainPage.UseVisualStyleBackColor = false;
            btnReturnToMainPage.Click += btnReturnToMainPage_Click;
            // 
            // textPlaceholderLink
            // 
            textPlaceholderLink.Cursor = Cursors.Hand;
            textPlaceholderLink.Font = new Font("Bahnschrift Light", 11F);
            textPlaceholderLink.ForeColor = Color.DodgerBlue;
            textPlaceholderLink.Location = new Point(192, 73);
            textPlaceholderLink.Name = "textPlaceholderLink";
            textPlaceholderLink.Size = new Size(642, 26);
            textPlaceholderLink.TabIndex = 53;
            textPlaceholderLink.Text = "Placeholder link";
            textPlaceholderLink.TextAlign = ContentAlignment.TopCenter;
            textPlaceholderLink.Click += textPlaceholderLink_Click;
            textPlaceholderLink.MouseEnter += textPlaceholderLink_MouseEnter;
            textPlaceholderLink.MouseLeave += textPlaceholderLink_MouseLeave;
            // 
            // divider4
            // 
            divider4.Location = new Point(192, 401);
            divider4.Name = "divider4";
            divider4.Size = new Size(642, 20);
            divider4.TabIndex = 52;
            divider4.Paint += divider4_Paint;
            // 
            // chkShowInfo
            // 
            chkShowInfo.Appearance = Appearance.Button;
            chkShowInfo.BackColor = Color.FromArgb(32, 32, 32);
            chkShowInfo.Cursor = Cursors.Hand;
            chkShowInfo.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            chkShowInfo.FlatAppearance.BorderSize = 0;
            chkShowInfo.FlatAppearance.CheckedBackColor = Color.FromArgb(32, 32, 32);
            chkShowInfo.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            chkShowInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 32, 32);
            chkShowInfo.FlatStyle = FlatStyle.Flat;
            chkShowInfo.Font = new Font("Bahnschrift Light", 10F);
            chkShowInfo.Location = new Point(534, 363);
            chkShowInfo.Name = "chkShowInfo";
            chkShowInfo.Padding = new Padding(10, 0, 0, 0);
            chkShowInfo.Size = new Size(300, 40);
            chkShowInfo.TabIndex = 50;
            chkShowInfo.Text = "◻️  Only show important download info";
            chkShowInfo.UseVisualStyleBackColor = false;
            chkShowInfo.CheckedChanged += chkShowInfo_CheckedChanged;
            // 
            // chkForceFileExtension
            // 
            chkForceFileExtension.Appearance = Appearance.Button;
            chkForceFileExtension.BackColor = Color.FromArgb(32, 32, 32);
            chkForceFileExtension.Cursor = Cursors.Hand;
            chkForceFileExtension.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            chkForceFileExtension.FlatAppearance.BorderSize = 0;
            chkForceFileExtension.FlatAppearance.CheckedBackColor = Color.FromArgb(32, 32, 32);
            chkForceFileExtension.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 32, 32);
            chkForceFileExtension.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 32, 32);
            chkForceFileExtension.FlatStyle = FlatStyle.Flat;
            chkForceFileExtension.Font = new Font("Bahnschrift Light", 10F);
            chkForceFileExtension.Location = new Point(192, 363);
            chkForceFileExtension.Name = "chkForceFileExtension";
            chkForceFileExtension.Padding = new Padding(10, 0, 0, 0);
            chkForceFileExtension.Size = new Size(300, 40);
            chkForceFileExtension.TabIndex = 49;
            chkForceFileExtension.Text = "◻️  Remux file (may cause issues)";
            chkForceFileExtension.TextAlign = ContentAlignment.MiddleRight;
            chkForceFileExtension.UseVisualStyleBackColor = false;
            chkForceFileExtension.CheckedChanged += chkForceFileExtension_CheckedChanged;
            // 
            // btnClearSettings
            // 
            btnClearSettings.BackColor = Color.FromArgb(38, 40, 42);
            btnClearSettings.Cursor = Cursors.Hand;
            btnClearSettings.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnClearSettings.FlatStyle = FlatStyle.Flat;
            btnClearSettings.Font = new Font("Bahnschrift Light", 10F);
            btnClearSettings.ForeColor = Color.DarkGray;
            btnClearSettings.Location = new Point(534, 300);
            btnClearSettings.Name = "btnClearSettings";
            btnClearSettings.Size = new Size(300, 47);
            btnClearSettings.TabIndex = 48;
            btnClearSettings.Text = "🗑️ Clear settings";
            btnClearSettings.UseVisualStyleBackColor = false;
            btnClearSettings.Click += btnClearSettings_Click;
            // 
            // lblSettingsSaved
            // 
            lblSettingsSaved.Font = new Font("Bahnschrift", 10F);
            lblSettingsSaved.ForeColor = Color.MediumSeaGreen;
            lblSettingsSaved.Location = new Point(192, 486);
            lblSettingsSaved.Name = "lblSettingsSaved";
            lblSettingsSaved.Size = new Size(642, 35);
            lblSettingsSaved.TabIndex = 47;
            lblSettingsSaved.Text = "❗️   Settings saved";
            lblSettingsSaved.TextAlign = ContentAlignment.MiddleCenter;
            lblSettingsSaved.Visible = false;
            // 
            // btnSaveExtensionSettings
            // 
            btnSaveExtensionSettings.BackColor = Color.FromArgb(38, 40, 42);
            btnSaveExtensionSettings.Cursor = Cursors.Hand;
            btnSaveExtensionSettings.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnSaveExtensionSettings.FlatStyle = FlatStyle.Flat;
            btnSaveExtensionSettings.Font = new Font("Bahnschrift Light", 10F);
            btnSaveExtensionSettings.ForeColor = Color.DarkGray;
            btnSaveExtensionSettings.Location = new Point(192, 300);
            btnSaveExtensionSettings.Name = "btnSaveExtensionSettings";
            btnSaveExtensionSettings.Size = new Size(300, 47);
            btnSaveExtensionSettings.TabIndex = 46;
            btnSaveExtensionSettings.Text = "💾 Save settings";
            btnSaveExtensionSettings.UseVisualStyleBackColor = false;
            btnSaveExtensionSettings.Click += btnSaveExtensionSettings_Click;
            // 
            // listPreferFPS
            // 
            listPreferFPS.BackColor = Color.FromArgb(32, 32, 32);
            listPreferFPS.Cursor = Cursors.Hand;
            listPreferFPS.DropDownStyle = ComboBoxStyle.DropDownList;
            listPreferFPS.Font = new Font("Bahnschrift Light", 16F);
            listPreferFPS.ForeColor = Color.LightGray;
            listPreferFPS.FormattingEnabled = true;
            listPreferFPS.Location = new Point(192, 244);
            listPreferFPS.Name = "listPreferFPS";
            listPreferFPS.Size = new Size(300, 33);
            listPreferFPS.TabIndex = 44;
            listPreferFPS.SelectedIndexChanged += listPreferFPS_SelectedIndexChanged;
            // 
            // lblPreferFPS
            // 
            lblPreferFPS.Font = new Font("Bahnschrift", 10F);
            lblPreferFPS.Location = new Point(192, 205);
            lblPreferFPS.Name = "lblPreferFPS";
            lblPreferFPS.Size = new Size(300, 36);
            lblPreferFPS.TabIndex = 43;
            lblPreferFPS.Text = "Preferred framerate";
            lblPreferFPS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusAudioWarning
            // 
            statusAudioWarning.Font = new Font("Bahnschrift Light", 8F);
            statusAudioWarning.ForeColor = Color.IndianRed;
            statusAudioWarning.Location = new Point(840, 205);
            statusAudioWarning.Name = "statusAudioWarning";
            statusAudioWarning.Padding = new Padding(0, 5, 0, 0);
            statusAudioWarning.Size = new Size(183, 72);
            statusAudioWarning.TabIndex = 42;
            statusAudioWarning.Text = "This option will convert the video to audio. Use \"Merge audio into video\" if you want video with sound.";
            statusAudioWarning.TextAlign = ContentAlignment.MiddleLeft;
            statusAudioWarning.Visible = false;
            // 
            // btnDownloadVideo
            // 
            btnDownloadVideo.BackColor = Color.FromArgb(38, 40, 42);
            btnDownloadVideo.Cursor = Cursors.Hand;
            btnDownloadVideo.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnDownloadVideo.FlatStyle = FlatStyle.Flat;
            btnDownloadVideo.Font = new Font("Bahnschrift Light", 12F);
            btnDownloadVideo.ForeColor = Color.DarkGray;
            btnDownloadVideo.Location = new Point(192, 436);
            btnDownloadVideo.Name = "btnDownloadVideo";
            btnDownloadVideo.Size = new Size(642, 47);
            btnDownloadVideo.TabIndex = 41;
            btnDownloadVideo.Text = " 📥  Download";
            btnDownloadVideo.UseVisualStyleBackColor = false;
            btnDownloadVideo.Click += btnDownloadVideo_Click;
            // 
            // listPreferRes
            // 
            listPreferRes.BackColor = Color.FromArgb(32, 32, 32);
            listPreferRes.Cursor = Cursors.Hand;
            listPreferRes.DropDownStyle = ComboBoxStyle.DropDownList;
            listPreferRes.Font = new Font("Bahnschrift Light", 16F);
            listPreferRes.ForeColor = Color.LightGray;
            listPreferRes.FormattingEnabled = true;
            listPreferRes.Location = new Point(192, 141);
            listPreferRes.Name = "listPreferRes";
            listPreferRes.Size = new Size(300, 33);
            listPreferRes.TabIndex = 34;
            listPreferRes.SelectedIndexChanged += listPreferRes_SelectedIndexChanged;
            // 
            // lblPreferRes
            // 
            lblPreferRes.Font = new Font("Bahnschrift", 10F);
            lblPreferRes.Location = new Point(192, 102);
            lblPreferRes.Name = "lblPreferRes";
            lblPreferRes.Size = new Size(300, 36);
            lblPreferRes.TabIndex = 33;
            lblPreferRes.Text = "Video resolution";
            lblPreferRes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listAudioExt
            // 
            listAudioExt.BackColor = Color.FromArgb(32, 32, 32);
            listAudioExt.Cursor = Cursors.Hand;
            listAudioExt.DropDownStyle = ComboBoxStyle.DropDownList;
            listAudioExt.Font = new Font("Bahnschrift Light", 16F);
            listAudioExt.ForeColor = Color.LightGray;
            listAudioExt.FormattingEnabled = true;
            listAudioExt.Location = new Point(534, 244);
            listAudioExt.Name = "listAudioExt";
            listAudioExt.Size = new Size(300, 33);
            listAudioExt.TabIndex = 39;
            listAudioExt.SelectedIndexChanged += listAudioExt_SelectedIndexChanged;
            // 
            // lblAudioExt
            // 
            lblAudioExt.Font = new Font("Bahnschrift", 10F);
            lblAudioExt.Location = new Point(534, 205);
            lblAudioExt.Name = "lblAudioExt";
            lblAudioExt.Size = new Size(300, 36);
            lblAudioExt.TabIndex = 38;
            lblAudioExt.Text = "Downloaded audio extension";
            lblAudioExt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listVideoExt
            // 
            listVideoExt.BackColor = Color.FromArgb(32, 32, 32);
            listVideoExt.Cursor = Cursors.Hand;
            listVideoExt.DropDownStyle = ComboBoxStyle.DropDownList;
            listVideoExt.Font = new Font("Bahnschrift Light", 16F);
            listVideoExt.ForeColor = Color.LightGray;
            listVideoExt.FormattingEnabled = true;
            listVideoExt.Location = new Point(534, 141);
            listVideoExt.Name = "listVideoExt";
            listVideoExt.Size = new Size(300, 33);
            listVideoExt.TabIndex = 37;
            // 
            // divider1
            // 
            divider1.Location = new Point(498, 102);
            divider1.Name = "divider1";
            divider1.Size = new Size(30, 175);
            divider1.TabIndex = 35;
            divider1.Paint += divider1_Paint;
            // 
            // lblForceExtVideo
            // 
            lblForceExtVideo.Font = new Font("Bahnschrift", 10F);
            lblForceExtVideo.Location = new Point(534, 102);
            lblForceExtVideo.Name = "lblForceExtVideo";
            lblForceExtVideo.Size = new Size(300, 36);
            lblForceExtVideo.TabIndex = 36;
            lblForceExtVideo.Text = "Downloaded file extension";
            lblForceExtVideo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleFetched
            // 
            titleFetched.Font = new Font("Bahnschrift Light", 12F);
            titleFetched.ForeColor = Color.LightGray;
            titleFetched.Location = new Point(192, 10);
            titleFetched.Name = "titleFetched";
            titleFetched.Size = new Size(642, 60);
            titleFetched.TabIndex = 17;
            titleFetched.Text = "Fetched:";
            titleFetched.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFirstTime
            // 
            panelFirstTime.Controls.Add(linkffmpeg);
            panelFirstTime.Controls.Add(statusytdlp);
            panelFirstTime.Controls.Add(btnBrowseYTDLP);
            panelFirstTime.Controls.Add(btnAcknowledgeFirstTime);
            panelFirstTime.Controls.Add(linkytdlp);
            panelFirstTime.Controls.Add(linkvlc);
            panelFirstTime.Controls.Add(lblFirstTime);
            panelFirstTime.Location = new Point(12, 38);
            panelFirstTime.Name = "panelFirstTime";
            panelFirstTime.Size = new Size(1026, 583);
            panelFirstTime.TabIndex = 3;
            // 
            // linkffmpeg
            // 
            linkffmpeg.AutoSize = true;
            linkffmpeg.Cursor = Cursors.Hand;
            linkffmpeg.Font = new Font("Bahnschrift Light", 8F);
            linkffmpeg.ForeColor = Color.Gray;
            linkffmpeg.Location = new Point(3, 521);
            linkffmpeg.Name = "linkffmpeg";
            linkffmpeg.Size = new Size(456, 13);
            linkffmpeg.TabIndex = 18;
            linkffmpeg.Text = "Download page for FFmpeg, required to convert videos; click here to open in your browser";
            linkffmpeg.Click += linkffmpeg_Click;
            linkffmpeg.MouseEnter += linkffmpeg_MouseEnter;
            linkffmpeg.MouseLeave += linkffmpeg_MouseLeave;
            // 
            // statusytdlp
            // 
            statusytdlp.Cursor = Cursors.Hand;
            statusytdlp.Font = new Font("Bahnschrift Light", 8F);
            statusytdlp.ForeColor = Color.DodgerBlue;
            statusytdlp.Location = new Point(516, 491);
            statusytdlp.Name = "statusytdlp";
            statusytdlp.Size = new Size(300, 13);
            statusytdlp.TabIndex = 17;
            statusytdlp.Text = "✔️ yt-dlp.exe detected";
            statusytdlp.TextAlign = ContentAlignment.TopCenter;
            statusytdlp.Visible = false;
            // 
            // btnBrowseYTDLP
            // 
            btnBrowseYTDLP.BackColor = Color.FromArgb(38, 40, 42);
            btnBrowseYTDLP.Cursor = Cursors.Hand;
            btnBrowseYTDLP.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnBrowseYTDLP.FlatStyle = FlatStyle.Flat;
            btnBrowseYTDLP.Font = new Font("Bahnschrift Light", 14F);
            btnBrowseYTDLP.ForeColor = Color.DarkGray;
            btnBrowseYTDLP.Location = new Point(516, 436);
            btnBrowseYTDLP.Name = "btnBrowseYTDLP";
            btnBrowseYTDLP.Size = new Size(300, 50);
            btnBrowseYTDLP.TabIndex = 16;
            btnBrowseYTDLP.Text = "↗️  Browse for yt-dlp's folder";
            btnBrowseYTDLP.UseVisualStyleBackColor = false;
            btnBrowseYTDLP.Visible = false;
            btnBrowseYTDLP.Click += btnBrowseYTDLP_Click;
            // 
            // btnAcknowledgeFirstTime
            // 
            btnAcknowledgeFirstTime.BackColor = Color.FromArgb(38, 40, 42);
            btnAcknowledgeFirstTime.Cursor = Cursors.Hand;
            btnAcknowledgeFirstTime.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnAcknowledgeFirstTime.FlatStyle = FlatStyle.Flat;
            btnAcknowledgeFirstTime.Font = new Font("Bahnschrift Light", 14F);
            btnAcknowledgeFirstTime.ForeColor = Color.DarkGray;
            btnAcknowledgeFirstTime.Location = new Point(210, 436);
            btnAcknowledgeFirstTime.Name = "btnAcknowledgeFirstTime";
            btnAcknowledgeFirstTime.Size = new Size(300, 50);
            btnAcknowledgeFirstTime.TabIndex = 15;
            btnAcknowledgeFirstTime.Text = "✔️  Acknowledge";
            btnAcknowledgeFirstTime.UseVisualStyleBackColor = false;
            btnAcknowledgeFirstTime.Click += btnAcknowledgeFirstTime_Click;
            // 
            // linkytdlp
            // 
            linkytdlp.AutoSize = true;
            linkytdlp.Cursor = Cursors.Hand;
            linkytdlp.Font = new Font("Bahnschrift Light", 8F);
            linkytdlp.ForeColor = Color.Gray;
            linkytdlp.Location = new Point(3, 545);
            linkytdlp.Name = "linkytdlp";
            linkytdlp.Size = new Size(312, 13);
            linkytdlp.TabIndex = 6;
            linkytdlp.Text = "Installation wiki for yt-dlp, click here to open in your browser";
            linkytdlp.Click += linkytdlp_Click;
            linkytdlp.MouseEnter += linkytdlp_MouseEnter;
            linkytdlp.MouseLeave += linkytdlp_MouseLeave;
            // 
            // linkvlc
            // 
            linkvlc.AutoSize = true;
            linkvlc.Cursor = Cursors.Hand;
            linkvlc.Font = new Font("Bahnschrift Light", 8F);
            linkvlc.ForeColor = Color.Gray;
            linkvlc.Location = new Point(3, 567);
            linkvlc.Name = "linkvlc";
            linkvlc.Size = new Size(365, 13);
            linkvlc.TabIndex = 5;
            linkvlc.Text = "Download page for VLC Media Player, click here to open in your browser";
            linkvlc.Click += linkvlc_Click;
            linkvlc.MouseEnter += linkvlc_MouseEnter;
            linkvlc.MouseLeave += linkvlc_MouseLeave;
            // 
            // lblFirstTime
            // 
            lblFirstTime.Font = new Font("Bahnschrift Light", 12F);
            lblFirstTime.Location = new Point(3, 10);
            lblFirstTime.Name = "lblFirstTime";
            lblFirstTime.Size = new Size(1020, 311);
            lblFirstTime.TabIndex = 3;
            lblFirstTime.Text = resources.GetString("lblFirstTime.Text");
            lblFirstTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDownloading
            // 
            panelDownloading.Controls.Add(panelInfo);
            panelDownloading.Controls.Add(dataOutputBorder);
            panelDownloading.Controls.Add(statusDownloading);
            panelDownloading.Location = new Point(12, 38);
            panelDownloading.Name = "panelDownloading";
            panelDownloading.Size = new Size(1026, 583);
            panelDownloading.TabIndex = 4;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(btnCancelDownload);
            panelInfo.Controls.Add(infoExportFolder);
            panelInfo.Controls.Add(infoFileName);
            panelInfo.Controls.Add(infoTimePassed);
            panelInfo.Location = new Point(621, 73);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(402, 221);
            panelInfo.TabIndex = 22;
            // 
            // btnCancelDownload
            // 
            btnCancelDownload.BackColor = Color.FromArgb(38, 40, 42);
            btnCancelDownload.Cursor = Cursors.Hand;
            btnCancelDownload.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnCancelDownload.FlatStyle = FlatStyle.Flat;
            btnCancelDownload.Font = new Font("Bahnschrift Light", 10F);
            btnCancelDownload.ForeColor = Color.DarkGray;
            btnCancelDownload.Location = new Point(219, 0);
            btnCancelDownload.Name = "btnCancelDownload";
            btnCancelDownload.Size = new Size(180, 47);
            btnCancelDownload.TabIndex = 55;
            btnCancelDownload.Text = "❌  Cancel download";
            btnCancelDownload.UseVisualStyleBackColor = false;
            btnCancelDownload.Click += btnCancelDownload_Click;
            // 
            // infoExportFolder
            // 
            infoExportFolder.Font = new Font("Bahnschrift", 12F);
            infoExportFolder.Location = new Point(3, 129);
            infoExportFolder.Name = "infoExportFolder";
            infoExportFolder.Size = new Size(205, 60);
            infoExportFolder.TabIndex = 6;
            infoExportFolder.Text = "Export folder\r\n> Placeholder";
            // 
            // infoFileName
            // 
            infoFileName.Font = new Font("Bahnschrift", 12F);
            infoFileName.Location = new Point(3, 66);
            infoFileName.Name = "infoFileName";
            infoFileName.Size = new Size(205, 60);
            infoFileName.TabIndex = 5;
            infoFileName.Text = "File name\r\n> Placeholder.webm";
            // 
            // infoTimePassed
            // 
            infoTimePassed.Font = new Font("Bahnschrift", 12F);
            infoTimePassed.Location = new Point(3, 3);
            infoTimePassed.Name = "infoTimePassed";
            infoTimePassed.Size = new Size(205, 60);
            infoTimePassed.TabIndex = 4;
            infoTimePassed.Text = "Time passed\r\n00:00";
            // 
            // dataOutputBorder
            // 
            dataOutputBorder.BackColor = Color.FromArgb(24, 26, 28);
            dataOutputBorder.Controls.Add(dataOutput);
            dataOutputBorder.Location = new Point(10, 73);
            dataOutputBorder.Name = "dataOutputBorder";
            dataOutputBorder.Size = new Size(605, 507);
            dataOutputBorder.TabIndex = 20;
            // 
            // dataOutput
            // 
            dataOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataOutput.BackColor = Color.FromArgb(24, 26, 28);
            dataOutput.BorderStyle = BorderStyle.None;
            dataOutput.ForeColor = Color.LightGray;
            dataOutput.Location = new Point(10, 10);
            dataOutput.Name = "dataOutput";
            dataOutput.Size = new Size(586, 487);
            dataOutput.TabIndex = 19;
            dataOutput.Text = "Placeholder";
            // 
            // statusDownloading
            // 
            statusDownloading.Font = new Font("Bahnschrift Light", 12F);
            statusDownloading.ForeColor = Color.LightGray;
            statusDownloading.Location = new Point(192, 10);
            statusDownloading.Name = "statusDownloading";
            statusDownloading.Size = new Size(642, 60);
            statusDownloading.TabIndex = 18;
            statusDownloading.Text = "Downloading content...";
            statusDownloading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1050, 633);
            Controls.Add(panelVideoSettings);
            Controls.Add(panelDownloading);
            Controls.Add(panelFirstTime);
            Controls.Add(hubPanel);
            Controls.Add(settingsPanel);
            Font = new Font("Bahnschrift Light", 11F);
            ForeColor = Color.LightGray;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Downloader";
            FormClosing += mainForm_FormClosing;
            Load += mainForm_Load;
            hubPanel.ResumeLayout(false);
            hubPanel.PerformLayout();
            pathbox.ResumeLayout(false);
            pathbox.PerformLayout();
            urlbox.ResumeLayout(false);
            urlbox.PerformLayout();
            settingsPanel.ResumeLayout(false);
            listSettings.ResumeLayout(false);
            listSettings.PerformLayout();
            panelVideoSettings.ResumeLayout(false);
            panelFirstTime.ResumeLayout(false);
            panelFirstTime.PerformLayout();
            panelDownloading.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            dataOutputBorder.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel hubPanel;
        private Panel urlbox;
        private TextBox destinationurl;
        private Label lblURL;
        private Panel pathbox;
        private TextBox destinationpath;
        private Label textwarning;
        private Label label2;
        private Button btnSaveURL;
        private Button btnBrowsePath;
        private Panel settingsPanel;
        private Panel listSettings;
        private Button btnViewOptions;
        private Label titleSettings;
        private CheckBox chkToggleSave;
        private CheckBox chkToggleOpen;
        private Label titleDefaultVideoExt;
        private ComboBox listDefaultAudioExt;
        private ComboBox listDefaultVideoExt;
        private Label titleDefaultAudioExt;
        private CheckBox chkToggleFirstTimeMessage;
        private Button btnViewMain;
        private Panel panelVideoSettings;
        private Panel panelFirstTime;
        private Label lblFirstTime;
        private Label linkvlc;
        private Label linkytdlp;
        private Button btnAcknowledgeFirstTime;
        private Label titleStatus;
        private Label titleFetched;
        private CheckBox chkShowInfo;
        private CheckBox chkForceFileExtension;
        private Button btnClearSettings;
        private Label lblSettingsSaved;
        private Button btnSaveExtensionSettings;
        private ComboBox listPreferFPS;
        private Label lblPreferFPS;
        private Label statusAudioWarning;
        private Button btnDownloadVideo;
        private ComboBox listPreferRes;
        private Label lblPreferRes;
        private ComboBox listAudioExt;
        private Label lblAudioExt;
        private ComboBox listVideoExt;
        private Panel divider1;
        private Label lblForceExtVideo;
        private Panel divider4;
        private Panel panelDownloading;
        private Label statusDownloading;
        private RichTextBox dataOutput;
        private Panel dataOutputBorder;
        private Label infoExportFolder;
        private Panel panelInfo;
        private Label infoFileName;
        private Label infoTimePassed;
        private Button btnBrowseYTDLP;
        private Label statusytdlp;
        private Label titleSavedPath;
        private TextBox textytdlp;
        private ToolTip pathTooltip;
        private Label textPlaceholderLink;
        private Label linkffmpeg;
        private Button btnReturnToMainPage;
        private Button btnCancelDownload;
    }
}
