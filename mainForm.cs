using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace Downloader
{
    public partial class mainForm : Form
    {
        public string currentEnv = Environment.CurrentDirectory;
        public string? cookiesFile = null;

        public bool isExtended = false;
        bool hasListBeenReversed = false;
        bool hasDropdownBeenReversed = false;
        bool hasBeenMerged = false;
        private DateTime startedTime;

        Process? downloadProcess;

        public List<string> parameters = new List<string>();
        public List<string> framerates = new List<string>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            destinationurl.Clear();
            destinationpath.Clear();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.destinationPath))
            {
                string fullPath = Properties.Settings.Default.destinationPath;
                bool destinationExists = Directory.Exists(fullPath);
                if (destinationExists)
                {
                    destinationpath.Text = fullPath;
                }
            }

            prepareSettingDropdowns();

            chkToggleOpen.Checked = Properties.Settings.Default.openFolderOnClose;
            chkToggleSave.Checked = Properties.Settings.Default.askWhereToSave;
            chkToggleFirstTimeMessage.Checked = Properties.Settings.Default.isFirstTime;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultVideoExt))
            {
                string item = Properties.Settings.Default.defaultVideoExt;
                if (listDefaultVideoExt.Items.Contains(item))
                {
                    int index = listDefaultVideoExt.Items.IndexOf(item);
                    if (index != -1)
                    {
                        listDefaultVideoExt.SelectedIndex = index;
                    }
                }
            }
            else
            {
                if (listDefaultVideoExt.Items.Count > -1)
                {
                    try
                    {
                        listDefaultVideoExt.SelectedIndex = 0;
                        string? item = listDefaultVideoExt.SelectedItem?.ToString();
                        Properties.Settings.Default.defaultVideoExt = item;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }

            if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultAudioExt))
            {
                string item = Properties.Settings.Default.defaultAudioExt;
                if (listDefaultAudioExt.Items.Contains(item))
                {
                    int index = listDefaultAudioExt.Items.IndexOf(item);
                    if (index != -1)
                    {
                        listDefaultAudioExt.SelectedIndex = index;
                    }
                }
            }
            else
            {
                if (listDefaultAudioExt.Items.Count > -1)
                {
                    try
                    {
                        listDefaultAudioExt.SelectedIndex = 0;
                        string? item = listDefaultAudioExt.SelectedItem?.ToString();
                        Properties.Settings.Default.defaultAudioExt = item;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }

            hubPanel.BringToFront();

            if (Properties.Settings.Default.isFirstTime)
            {
                panelFirstTime.BringToFront();

                if (string.IsNullOrEmpty(Properties.Settings.Default.ytdlpFolder))
                {
                    btnBrowseYTDLP.Visible = true;
                    btnAcknowledgeFirstTime.Enabled = false;
                }
                else
                {
                    insertYtDlp();
                }
            }
            else if (string.IsNullOrEmpty(Properties.Settings.Default.ytdlpFolder))
            {
                panelFirstTime.BringToFront();
                btnBrowseYTDLP.Visible = true;
                btnAcknowledgeFirstTime.Enabled = false;

                MessageBox.Show("We could not detect yt-dlp in your system. Please browse for the folder containing it and acknowledge.",
                    this.Text, MessageBoxButtons.OK);
            }
            else
            {
                insertYtDlp();
            }

            lblURL.Select();
        }

        // backend events

        private void insertYtDlp()
        {
            string ytdlp = Properties.Settings.Default.ytdlpFolder;
            bool doesytdlpExist = Directory.Exists(ytdlp);
            if (doesytdlpExist)
            {
                pathTooltip.SetToolTip(textytdlp, Path.Join(ytdlp, "yt-dlp.exe"));
                textytdlp.Text = Path.Join(ytdlp, "yt-dlp.exe");
            }
        }

        private async Task<string?> FetchVideoInfo(string videoUrl)
        {
            string? fullPath = Properties.Settings.Default.ytdlpFolder;
            string? ytdlp = "";

            bool doesDirExist = Directory.Exists(fullPath);
            if (doesDirExist)
            {
                string joinedPath = Path.Join(fullPath, "yt-dlp.exe");
                if (File.Exists(joinedPath))
                {
                    ytdlp = joinedPath;
                }

                if (!string.IsNullOrEmpty(ytdlp))
                {
                    var processStartInfo = new ProcessStartInfo
                    {
                        FileName = ytdlp,
                        Arguments = $"--dump-json \"{videoUrl}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = new Process { StartInfo = processStartInfo };

                    try
                    {
                        process.Start();
                        string output = await process.StandardOutput.ReadToEndAsync();
                        process.WaitForExit();
                        if (process.ExitCode == 0)
                        {
                            return output;
                        }
                        else
                        {
                            string errorOutput = await process.StandardError.ReadToEndAsync();

                            process.Kill();
                            process.Dispose();

                            titleStatus.Visible = true;
                            titleStatus.Text = "Fetching failed, see log file";
                            titleFetched.Text = null;

                            throw new Exception($"yt-dlp exited with code {process.ExitCode}: {errorOutput}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error: {ex.Message}");
                        return null;
                    }
                }
            }

            return null;
        }

        private async void fetchInfo(string url)
        {
            prepareDropdowns();
            hasDropdownBeenReversed = false;

            string? result = await FetchVideoInfo(url);
            if (result != null)
            {
                var prettyprint = JsonConvert.DeserializeObject(result);
                string full = JsonConvert.SerializeObject(prettyprint, Formatting.Indented);
                JObject videoInfo = JObject.Parse(full);

                if (videoInfo != null)
                {
                    // panel visual work
                    panelVideoSettings.BringToFront();

                    if (videoInfo != null)
                    {
                        // fetch video title
                        string videoTitle = videoInfo["title"]!.ToString();
                        if (videoTitle != null)
                        {
                            titleFetched.Text = "Fetched: " + videoTitle;
                            titleFetched.Tag = videoTitle;
                            textPlaceholderLink.Text = destinationurl.Text;
                            btnSaveURL.Enabled = true;
                        }

                        // iterate through the formats/available resolutions
                        var formatsArray = videoInfo["formats"] as JArray;
                        if (formatsArray != null)
                        {
                            foreach (var format in formatsArray)
                            {
                                var resolution = format["resolution"];
                                var _format = format["format"];
                                var _height = format["height"];
                                var framerate = format["fps"];

                                if (_height != null && _format != null && framerate != null)
                                {
                                    string convertedheight = _height.ToString();
                                    string convertedformat = _format.ToString();
                                    string convertedfps = framerate.ToString();

                                    if (int.TryParse(convertedfps, out int _fps))
                                    {
                                        insertFramerate(convertedheight, _fps);
                                    }

                                    if (convertedheight == "144" || convertedformat.Contains("144p"))
                                    {
                                        if (listPreferRes.Items.Contains("144p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "144p");
                                        continue;
                                    }
                                    else if (convertedheight == "240" || convertedformat.Contains("240p"))
                                    {
                                        if (listPreferRes.Items.Contains("240p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "240p");
                                        continue;
                                    }
                                    else if (convertedheight == "360" || convertedformat.Contains("360p"))
                                    {
                                        if (listPreferRes.Items.Contains("360p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "360p");
                                        continue;
                                    }
                                    else if (convertedheight == "480" || convertedformat.Contains("480p"))
                                    {
                                        if (listPreferRes.Items.Contains("480p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "480p");
                                        continue;
                                    }
                                    else if (convertedheight == "720" || convertedformat.Contains("720p"))
                                    {
                                        if (listPreferRes.Items.Contains("720p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "720p");
                                        continue;
                                    }
                                    else if (convertedheight == "1080" || convertedformat.Contains("1080p"))
                                    {
                                        if (listPreferRes.Items.Contains("1080p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "1080p");
                                        continue;
                                    }
                                    else if (convertedheight == "1440" || convertedformat.Contains("1440p"))
                                    {
                                        if (listPreferRes.Items.Contains("1440p"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "1440p");
                                        continue;
                                    }
                                    else if (convertedheight == "2160" || convertedformat.Contains("2160p60"))
                                    {
                                        if (listPreferRes.Items.Contains("4K"))
                                            continue;
                                        insertAvailableItem(listPreferRes, "4K");
                                        continue;
                                    }
                                }
                            }
                        }
                    }

                    if (listPreferRes.Items.Count <= -1)
                    {
                        listPreferRes.Items.Add("Default");
                    }
                    else
                    {
                        // reverse video res dropdown, high > low
                        reverseResDropdown();
                    }

                    automateResSelection();
                    hasListBeenReversed = false;
                }
            }
        }

        private void prepareSettingDropdowns()
        {
            listDefaultVideoExt.Items.Add("avi");
            listDefaultVideoExt.Items.Add("flv");
            listDefaultVideoExt.Items.Add("mkv");
            listDefaultVideoExt.Items.Add("mov");
            listDefaultVideoExt.Items.Add("mp4");
            listDefaultVideoExt.Items.Add("webm");

            listDefaultAudioExt.Items.Add("merge audio into video");
            listDefaultAudioExt.Items.Add("best");
            listDefaultAudioExt.Items.Add("aac");
            listDefaultAudioExt.Items.Add("alac");
            listDefaultAudioExt.Items.Add("flac");
            listDefaultAudioExt.Items.Add("m4a");
            listDefaultAudioExt.Items.Add("mp3");
            listDefaultAudioExt.Items.Add("opus");
            listDefaultAudioExt.Items.Add("vorbis");
            listDefaultAudioExt.Items.Add("wav");
        }

        private void prepareDropdowns()
        {
            listPreferRes.Items.Clear();
            listPreferFPS.Items.Clear();
            listVideoExt.Items.Clear();
            listAudioExt.Items.Clear();

            listVideoExt.Items.Add("avi");
            listVideoExt.Items.Add("flv");
            listVideoExt.Items.Add("mkv");
            listVideoExt.Items.Add("mov");
            listVideoExt.Items.Add("mp4");
            listVideoExt.Items.Add("webm");

            listAudioExt.Items.Add("merge audio into video");
            listAudioExt.Items.Add("best");
            listAudioExt.Items.Add("aac");
            listAudioExt.Items.Add("alac");
            listAudioExt.Items.Add("flac");
            listAudioExt.Items.Add("m4a");
            listAudioExt.Items.Add("mp3");
            listAudioExt.Items.Add("opus");
            listAudioExt.Items.Add("vorbis");
            listAudioExt.Items.Add("wav");
        }

        private void beginDownloadProcess(string parameters, string videotitle, string url)
        {
            string? destination = destinationpath.Text;
            string? exportFolder = Path.GetFileName(destination);
            string? filename = titleFetched.Tag?.ToString();
            string? extension = listVideoExt.SelectedItem?.ToString();
            extension = "." + extension;
            filename = filename?.Replace(" ", "_");

            dataOutput.Clear();
            dataOutput.Text = $"Waiting for download to start, please wait a few seconds" + Environment.NewLine;
            infoFileName.Text = "File name" + Environment.NewLine + "> " + filename + extension;
            infoExportFolder.Text = "Export path" + Environment.NewLine + "> " + exportFolder + Environment.NewLine + "(" + destination + ")";

            attemptDownloadVideo(parameters, url, videotitle);
        }

        private async void attemptDownloadVideo(string script, string videotitle, string url)
        {
            panelDownloading.BringToFront();

            startedTime = DateTime.Now;
            System.Windows.Forms.Timer dt = new System.Windows.Forms.Timer();

            dt.Interval = 1000;
            dt.Tick += new EventHandler(OnTimerTick);
            dt.Start();

            await Task.Run(() =>
            {
                using (downloadProcess = new Process())
                {
                    downloadProcess.StartInfo.WorkingDirectory = Properties.Settings.Default.ytdlpFolder.ToString();
                    downloadProcess.StartInfo.FileName = "cmd.exe";
                    downloadProcess.StartInfo.Arguments = "/C " + script + " " + url;
                    downloadProcess.StartInfo.RedirectStandardOutput = true;
                    downloadProcess.StartInfo.RedirectStandardError = true;
                    downloadProcess.StartInfo.UseShellExecute = false;
                    downloadProcess.StartInfo.CreateNoWindow = true;
                    downloadProcess.Start();

                    StringBuilder output = new StringBuilder();
                    while (!downloadProcess.StandardOutput.EndOfStream)
                    {
                        string? line = downloadProcess.StandardOutput.ReadLine();
                        output.AppendLine(line);

                        if (line != null)
                        {
                            if (chkShowInfo.Checked)
                            {
                                if (!hasBeenMerged)
                                {
                                    if (InvokeRequired)
                                    {
                                        Invoke(new Action(() =>
                                        {
                                            dataOutput.Clear();
                                            dataOutput.AppendText(line.ToString() + Environment.NewLine);
                                        }));
                                    }
                                    else
                                    {
                                        dataOutput.Clear();
                                        dataOutput.AppendText(line.ToString() + Environment.NewLine);
                                    }
                                }
                            }
                            else
                            {
                                if (line!.Contains("%"))
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        dataOutput.Clear();
                                    });

                                    if (InvokeRequired)
                                    {
                                        Invoke(new Action(() =>
                                        {
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                dataOutput.AppendText
                                                ($"Downloading video " +
                                                $"{Environment.NewLine}{Environment.NewLine}" +
                                                $"Download progress:{Environment.NewLine}" +
                                                $"{line}");
                                            });
                                        }));
                                    }
                                    else
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            dataOutput.AppendText
                                            ($"Downloading video " +
                                            $"{Environment.NewLine}{Environment.NewLine}" +
                                            $"Download progress:{Environment.NewLine}" +
                                            $"{line}");
                                        });
                                    }
                                }
                                else if (line!.Contains("100% of") || line!.Contains("[Merger]"))
                                {
                                    hasBeenMerged = true;
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        statusDownloading.Text = "Success!";
                                    });
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        dataOutput.Clear();
                                        dataOutput.Text = "Download successful" + Environment.NewLine + Environment.NewLine + "Redirecting you back to the previous page, please wait...";
                                    });
                                }
                                else if (line!.Contains("ERROR") && line!.Contains("403"))
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        dataOutput.Clear();
                                        downloadProcess.Dispose();
                                        downloadProcess.Kill();

                                        dt.Stop();
                                        dt.Enabled = false;
                                        dt.Dispose();

                                        infoTimePassed.Text = "Time passed" + Environment.NewLine + "00:00";
                                        infoFileName.Text = "File name" + Environment.NewLine + "> Placeholder.webm";
                                        infoExportFolder.Text = "Export folder" + Environment.NewLine + "> Placeholder";

                                        panelVideoSettings.BringToFront();
                                        hasBeenMerged = false;

                                        MessageBox.Show("403 Forbidden encountered: the IP address you use has been blocked." + Environment.NewLine + Environment.NewLine +
                                                        "If using VPN, please switch to another server, then restart the app and try again.", Text, MessageBoxButtons.OK);
                                    });
                                }
                                else
                                {
                                    if (!hasBeenMerged)
                                    {
                                        if (InvokeRequired)
                                        {
                                            Invoke(new Action(() =>
                                            {
                                                dataOutput.AppendText(line.ToString() + Environment.NewLine);
                                            }));
                                        }
                                        else
                                        {
                                            dataOutput.AppendText(line.ToString() + Environment.NewLine);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    downloadProcess.WaitForExitAsync();
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            if (Properties.Settings.Default.openFolderOnClose)
                            {
                                string destination = Properties.Settings.Default.destinationPath;
                                if (!string.IsNullOrEmpty(destination))
                                {
                                    ProcessStartInfo startInfo = new ProcessStartInfo
                                    {
                                        FileName = "explorer.exe",
                                        Arguments = destination,
                                        UseShellExecute = true
                                    };

                                    Process.Start(startInfo);
                                }
                            }
                        }));
                    }
                    else
                    {
                        if (Properties.Settings.Default.openFolderOnClose)
                        {
                            string destination = Properties.Settings.Default.destinationPath;
                            if (!string.IsNullOrEmpty(destination))
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = "explorer.exe",
                                    Arguments = destination,
                                    UseShellExecute = true
                                };

                                Process.Start(startInfo);
                            }
                        }
                    }
                }
            });

            await Task.Delay(1500);
            this.Invoke((MethodInvoker)delegate
            {
                terminateDownload();
                dataOutput.Clear();

                dt.Stop();
                dt.Enabled = false;
                dt.Dispose();

                infoTimePassed.Text = "Time passed" + Environment.NewLine + "00:00";
                infoFileName.Text = "File name" + Environment.NewLine + "> Placeholder.webm";
                infoExportFolder.Text = "Export folder" + Environment.NewLine + "> Placeholder";

                panelVideoSettings.BringToFront();
                hasBeenMerged = false;
            });
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startedTime;
            string formattedTime = string.Format("{0:D2}:{1:D2}", elapsedTime.Minutes, elapsedTime.Seconds);
            infoTimePassed.Text = "Time passed" + Environment.NewLine + formattedTime;
        }

        private void insertAvailableItem(ComboBox cb, string item)
        {
            cb.Items.Add(item);
        }

        private void insertFramerate(string res, int fps)
        {
            string framerate = fps.ToString();
            // if (!framerates.ContainsKey(res))
            framerates.Add(res + "-" + framerate);
        }

        private void populateFramerateDropdown(string displaytext)
        {
            // populating framerate dropdown menu with framerate values
            listPreferFPS.Items.Clear();

            foreach (string item in framerates)
            {
                if (item.Contains("2160") && displaytext == "4K")
                {
                    int dashIndex = item.IndexOf('-');
                    string result = dashIndex >= 0 ? item.Substring(dashIndex + 1) : item;
                    if (!listPreferFPS.Items.Contains(result))
                        listPreferFPS.Items.Add(result);
                }
                else if (item.Contains(displaytext))
                {
                    int dashIndex = item.IndexOf('-');
                    string result = dashIndex >= 0 ? item.Substring(dashIndex + 1) : item;
                    if (!listPreferFPS.Items.Contains(result))
                        listPreferFPS.Items.Add(result);
                }
            }
        }

        private void automateDropdownSelections()
        {
            // auto-selecting indexes in dropdowns for efficiency
            if (listPreferFPS.Items.Count > -1)
            {
                if (listPreferFPS.SelectedIndex <= -1)
                {
                    try
                    {
                        listPreferFPS.SelectedIndex = 0;
                    }
                    catch (Exception e)
                    {
                        listPreferFPS.Items.Add("Default");

                        try
                        {
                            listPreferFPS.SelectedIndex = 0;
                        }
                        catch (Exception e2)
                        {
                            Debug.WriteLine(e.ToString() + e2);
                        }
                    }
                }
            }

            if (listVideoExt.Items.Count > -1)
            {
                if (listVideoExt.SelectedIndex <= -1)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultVideoExt))
                        {
                            int index = listVideoExt.Items.IndexOf(Properties.Settings.Default.defaultVideoExt);
                            if (index > -1)
                            {
                                listVideoExt.SelectedIndex = index;
                            }
                        }
                        else
                        {
                            listVideoExt.SelectedIndex = 0;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }

            if (listAudioExt.Items.Count > -1)
            {
                if (listAudioExt.SelectedIndex <= -1)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultAudioExt))
                        {
                            int index = listAudioExt.Items.IndexOf(Properties.Settings.Default.defaultAudioExt);
                            if (index > -1)
                            {
                                listAudioExt.SelectedIndex = index;
                            }
                        }
                        else
                        {
                            listAudioExt.SelectedIndex = 0;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }

            btnDownloadVideo.Enabled = true;
        }

        private void reverseResDropdown()
        {
            List<string> sortedlist = new List<string>();

            if (!hasDropdownBeenReversed)
            {
                foreach (string item in listPreferRes.Items)
                {
                    sortedlist.Add(item);
                }

                List<string> newList = sortedlist.Distinct().ToList();
                newList.Reverse();
                listPreferRes.Items.Clear();

                foreach (string item in newList)
                {
                    listPreferRes.Items.Add(item);
                }

                sortedlist.Clear();
                newList.Clear();
                hasDropdownBeenReversed = true;
            }
        }

        private void reverseList(List<string> list)
        {
            if (!hasListBeenReversed)
            {
                string[] tf = new string[] { };
                foreach (string item in list)
                {
                    Array.Resize(ref tf, tf.Length + 1);
                    tf[tf.Length - 1] = item;
                }

                List<string> sortedlist = list.Distinct().ToList();
                sortedlist.Reverse();

                list.Clear();
                foreach (string item in sortedlist)
                {
                    list.Add(item);
                }
                hasListBeenReversed = true;
            }
        }

        private void initDropdownSettings(string displaytext)
        {
            if (!string.IsNullOrEmpty(displaytext))
            {
                /// <summary>
                /// 1. removing 'p' from original text for reference
                /// 2. reverse internal framerate list, high > low
                /// 3. adding framerates to framerate dropdown
                /// 4. auto-select dropdowns for efficiency
                /// </summary>

                string trimmedtext = displaytext.Replace("p", "");

                reverseList(framerates);
                populateFramerateDropdown(trimmedtext);
                automateDropdownSelections();
            }
        }

        private void automateResSelection()
        {
            if (listPreferRes.Items.Count > -1)
            {
                if (listPreferRes.SelectedIndex < 0)
                {
                    try
                    {
                        listPreferRes.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        listPreferRes.Items.Add("Default");

                        try
                        {
                            listPreferRes.SelectedIndex = 0;
                        }
                        catch (Exception ex2)
                        {
                            Debug.WriteLine(ex.ToString() + ex2);
                        }
                    }
                }
            }
        }

        public static bool isValidYouTubeURL(string url)
        {
            string pattern = @"^(https?://)?(www\.)?(youtube\.com|youtu\.be)/(watch\?v=[\w-]{11}|[\w-]{11})";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }

        private void terminateDownload()
        {
            if (downloadProcess != null && !downloadProcess.HasExited)
            {
                try
                {
                    downloadProcess.Kill();
                    downloadProcess.WaitForExit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error terminating process: " + ex.Message.ToString());
                }
                finally
                {
                    downloadProcess.Dispose();
                    downloadProcess = null;
                }
            }
        }

        // backend events

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fde = new FolderBrowserDialog();
            fde.UseDescriptionForTitle = true;
            fde.Description = "Navigate to your desired destination folder";

            if (fde.ShowDialog() == DialogResult.OK)
            {
                string fullPath = (string)fde.SelectedPath;
                bool directoryExists = Directory.Exists(fullPath);
                if (directoryExists)
                {
                    destinationpath.Text = fullPath;
                    Properties.Settings.Default.destinationPath = fullPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnViewOptions_Click(object sender, EventArgs e)
        {
            settingsPanel.BringToFront();
        }

        private void btnViewMain_Click(object sender, EventArgs e)
        {
            hubPanel.BringToFront();
        }

        private void chkToggleSave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.askWhereToSave = chkToggleSave.Checked;
        }

        private void chkToggleOpen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.openFolderOnClose = chkToggleOpen.Checked;
        }

        private void chkToggleFirstTimeMessage_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isFirstTime = chkToggleFirstTimeMessage.Checked;
        }

        private void btnAcknowledgeFirstTime_Click(object sender, EventArgs e)
        {
            hubPanel.BringToFront();
            statusytdlp.Visible = false;
            chkToggleFirstTimeMessage.Checked = false;
            Properties.Settings.Default.isFirstTime = false;
            Properties.Settings.Default.Save();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btnSaveURL_Click(object sender, EventArgs e)
        {
            if (chkToggleOpen.Checked)
            {
                FolderBrowserDialog fde = new FolderBrowserDialog();
                fde.Description = "Save file to...";
                fde.UseDescriptionForTitle = true;

                if (fde.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = (string)fde.SelectedPath;
                    bool directoryExists = Directory.Exists(fullPath);
                    if (directoryExists)
                    {
                        string url = destinationurl.Text;
                        titleStatus.Text = "Fetching, please wait...";
                        titleStatus.Visible = true;
                        titleFetched.Text = null;
                        btnSaveURL.Enabled = false;

                        fetchInfo(url);
                    }
                }
            }
            else
            {
                string destination = destinationpath.Text;
                bool destinationExists = Directory.Exists(destination);
                if (destinationExists)
                {
                    string url = destinationurl.Text;
                    titleStatus.Text = "Fetching, please wait...";
                    titleStatus.Visible = true;
                    titleFetched.Text = null;
                    btnSaveURL.Enabled = false;

                    fetchInfo(url);
                }
            }
        }

        private void chkForceFileExtension_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForceFileExtension.Checked)
            {
                chkForceFileExtension.Text = "◼️  Convert file (takes way longer)";
            }
            else
            {
                string? extension = listVideoExt.SelectedItem?.ToString();
                extension = "." + extension;

                chkForceFileExtension.Text = "◻️  Remux file (may cause issues)";
            }
        }

        private void chkShowInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowInfo.Checked)
            {
                chkShowInfo.Text = "◼️  Show all download info";
            }
            else
            {
                chkShowInfo.Text = "◻️  Only show important download info";
            }
        }

        private void divider1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int middleX = divider1.Width / 2;
            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                g.DrawLine(pen, middleX, 0, middleX, divider1.Height);
            }
        }

        private void divider4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                int y = divider4.Height / 2;
                g.DrawLine(pen, 0, y, divider4.Width, y);
            }
        }

        private void listPreferRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPreferRes.SelectedIndex >= -1)
            {
                if (listPreferRes.SelectedItem != null)
                {
                    // initialize dropdown trigger code
                    string? displaytext = listPreferRes.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(displaytext))
                        initDropdownSettings(displaytext);
                }
            }
        }

        private void listPreferFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listAudioExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAudioExt.SelectedIndex >= -1)
            {
                if (listAudioExt.SelectedItem != null)
                {
                    string? displaytext = listAudioExt.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(displaytext))
                    {
                        if (displaytext.ToLower() == "merge audio into video")
                        {
                            statusAudioWarning.Visible = false;
                            listVideoExt.Enabled = true;
                        }
                        else
                        {
                            statusAudioWarning.Visible = true;
                            listVideoExt.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btnSaveExtensionSettings_Click(object sender, EventArgs e)
        {
            if (listAudioExt.SelectedIndex > -1)
            {
                if (listAudioExt.SelectedItem != null)
                {
                    string? displaytext = listAudioExt.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(displaytext))
                    {
                        Properties.Settings.Default.defaultAudioExt = displaytext;
                    }
                }
            }

            if (listVideoExt.SelectedIndex > -1)
            {
                if (listVideoExt.SelectedItem != null)
                {
                    string? displaytext = listVideoExt.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(displaytext))
                    {
                        Properties.Settings.Default.defaultVideoExt = displaytext;
                    }
                }
            }

            Properties.Settings.Default.Save();
            lblSettingsSaved.Visible = true;

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 2000;
            t.Enabled = true;

            t.Tick += (sender, e) =>
            {
                lblSettingsSaved.Visible = false;
                t.Enabled = false;
                t.Dispose();
            };
        }

        private void btnClearSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.defaultAudioExt = null;
            Properties.Settings.Default.defaultVideoExt = null;
            Properties.Settings.Default.Save();
        }

        private void btnDownloadVideo_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 1. add parameters with relevant data and values
            /// 2. compile parameters into one string
            /// 3. attempt to download from the provided link
            /// </summary>

            string destination = destinationpath.Text;
            bool destinationExists = Directory.Exists(destination);
            if (destinationExists)
            {
                string? ytdlpFolder = Properties.Settings.Default.ytdlpFolder;
                string? ytdlpCompiled = Path.Join(ytdlpFolder, "yt-dlp.exe");
                string url = destinationurl.Text;
                string? extension = listVideoExt.SelectedItem?.ToString();
                extension = "." + extension;

                parameters.Clear();
                parameters.Add("yt-dlp.exe");
                parameters.Add("--restrict-filenames");
                parameters.Add("--audio-quality 0");
                // parameters.Add("--cookies-from-browser brave --cookies " + cookiesFile);

                if (listAudioExt.SelectedIndex > -1)
                {
                    if (listAudioExt.SelectedItem != null)
                    {
                        string? displaytext = listAudioExt.SelectedItem?.ToString();

                        if (!string.IsNullOrEmpty(displaytext))
                        {
                            if (displaytext.ToLower() != "merge audio into video")
                                parameters.Add("--extract-audio --audio-format " + displaytext);
                        }
                    }
                }

                if (listVideoExt.SelectedIndex > -1)
                {
                    if (listVideoExt.SelectedItem != null)
                    {
                        string? video_displaytext = listVideoExt.SelectedItem?.ToString();
                        string? audio_displaytext = listAudioExt.SelectedItem?.ToString();

                        if (!string.IsNullOrEmpty(video_displaytext) && !string.IsNullOrEmpty(audio_displaytext))
                        {
                            if (audio_displaytext.ToLower() == "merge audio into video")
                                parameters.Add("--merge-output-format " + video_displaytext + " --remux-video " + video_displaytext);
                        }
                    }
                }

                if (chkForceFileExtension.Checked)
                {
                    parameters.Add("--recode-video " + extension.Replace(".", ""));
                }
                else
                {
                    if (parameters.Contains("--recode-video " + extension))
                    {
                        parameters.Remove("--recode-video " + extension);
                    }
                }

                if (listPreferRes.SelectedIndex > -1)
                {
                    if (listPreferRes.SelectedItem != null)
                    {
                        if (listPreferFPS.SelectedIndex > -1)
                        {
                            if (listPreferFPS.SelectedItem != null)
                            {
                                bool audioEnabled = false;
                                string? res_displaytext = listPreferRes.SelectedItem?.ToString();
                                string? fps_displaytext = listPreferFPS.SelectedItem?.ToString();
                                fps_displaytext = fps_displaytext?.ToLower();
                                res_displaytext = res_displaytext?.Replace("p", "");
                                res_displaytext = res_displaytext?.ToLower();

                                foreach (string item in parameters)
                                {
                                    if (item.Contains("--extract-audio --audio-format"))
                                    {
                                        audioEnabled = true;
                                        break;
                                    }
                                }

                                if (!audioEnabled)
                                {
                                    if (res_displaytext != "4k")
                                    {
                                        if (fps_displaytext == "default" && res_displaytext == "default")
                                        {
                                            parameters.Add("-f \"bvba/b\"");
                                        }
                                        else
                                        {
                                            parameters.Add(
                                                "-f \"(bv*[fps>=" + fps_displaytext + "][height<=" + res_displaytext + "]+bestaudio) / (bv+ba/b)\"");
                                        }
                                    }
                                    else
                                    {
                                        if (fps_displaytext == "default")
                                        {
                                            parameters.Add("-f \"(bv*[height<=2160]+bestaudio) / (bv+ba/b)\"");
                                        }
                                        else
                                        {
                                            parameters.Add("-f \"(bv*[fps>=" + fps_displaytext + "][height<=2160]+bestaudio) / (bv+ba/b)\"");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                parameters.Add("-o \"" + destination + "\\%(title)s.%(ext)s\"");
                parameters.Add(url);

                string fullParameter = string.Join(" ", parameters);
                string? videotitle = titleFetched.Text.Replace("Fetched video: ", "");
                Debug.WriteLine(fullParameter);
                beginDownloadProcess(fullParameter, url, videotitle);
            }
        }

        private void listDefaultVideoExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDefaultVideoExt.SelectedIndex >= 0)
            {
                int index = listDefaultVideoExt.SelectedIndex;
                string? selectedItem = listDefaultVideoExt.Items[index]?.ToString();

                if (selectedItem != null)
                {
                    Properties.Settings.Default.defaultVideoExt = selectedItem.ToLower();
                }
            }
        }

        private void listDefaultAudioExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDefaultAudioExt.SelectedIndex >= 0)
            {
                int index = listDefaultAudioExt.SelectedIndex;
                string? selectedItem = listDefaultAudioExt.Items[index]?.ToString();

                if (selectedItem != null)
                {
                    Properties.Settings.Default.defaultAudioExt = selectedItem.ToLower();
                }
            }
        }

        private void destinationpath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                btnBrowsePath.PerformClick();
            }
        }

        private void destinationpath_MouseDown(object sender, MouseEventArgs e)
        {
            lblURL.Select();
        }

        private void destinationurl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                btnSaveURL.PerformClick();
            }
        }

        private void btnBrowseYTDLP_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fde = new FolderBrowserDialog();
            fde.UseDescriptionForTitle = true;
            fde.Description = "Navigate to the folder containing yt-dlp.exe";

            if (fde.ShowDialog() == DialogResult.OK)
            {
                string fullPath = (string)fde.SelectedPath;
                bool directoryExists = Directory.Exists(fullPath);
                if (directoryExists)
                {
                    string ytdlp = Path.Join(fullPath, "yt-dlp.exe");
                    Properties.Settings.Default.ytdlpFolder = fullPath;
                    Properties.Settings.Default.Save();

                    statusytdlp.Visible = true;
                    btnAcknowledgeFirstTime.Enabled = true;
                    pathTooltip.SetToolTip(textytdlp, ytdlp);
                    textytdlp.Text = ytdlp;
                }
            }
        }

        private void btnReturnToMainPage_Click(object sender, EventArgs e)
        {
            hubPanel.BringToFront();
            destinationurl.Clear();

            hasListBeenReversed = false;
            hasDropdownBeenReversed = false;
            hasBeenMerged = false;

            lblURL.Select();
        }

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            terminateDownload();
        }

        private void textytdlp_MouseDown(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fde = new FolderBrowserDialog();
            fde.UseDescriptionForTitle = true;
            fde.Description = "Navigate to the folder containing yt-dlp.exe";

            if (fde.ShowDialog() == DialogResult.OK)
            {
                string fullPath = (string)fde.SelectedPath;
                bool directoryExists = Directory.Exists(fullPath);
                if (directoryExists)
                {
                    string ytdlp = Path.Join(fullPath, "yt-dlp.exe");
                    Properties.Settings.Default.ytdlpFolder = fullPath;
                    Properties.Settings.Default.Save();

                    statusytdlp.Visible = true;
                    btnAcknowledgeFirstTime.Enabled = true;
                    pathTooltip.SetToolTip(textytdlp, ytdlp);
                    textytdlp.Text = ytdlp;
                }
            }

            lblURL.Select();
        }

        private void urlbox_MouseDown(object sender, MouseEventArgs e)
        {
            destinationurl.Focus();
        }

        private void textPlaceholderLink_Click(object sender, EventArgs e)
        {
            string URL = textPlaceholderLink.Text;
            bool isURLValid = isValidYouTubeURL(URL);
            if (isURLValid)
            {
                Process.Start(new ProcessStartInfo(URL) { UseShellExecute = true });
            }
        }

        private void textPlaceholderLink_MouseEnter(object sender, EventArgs e)
        {
            textPlaceholderLink.ForeColor = Color.CadetBlue;
        }

        private void textPlaceholderLink_MouseLeave(object sender, EventArgs e)
        {
            textPlaceholderLink.ForeColor = Color.DodgerBlue;
        }

        private void linkytdlp_MouseEnter(object sender, EventArgs e)
        {
            linkytdlp.ForeColor = Color.LightGray;
        }

        private void linkytdlp_MouseLeave(object sender, EventArgs e)
        {
            linkytdlp.ForeColor = Color.Gray;
        }

        private void linkvlc_MouseEnter(object sender, EventArgs e)
        {
            linkvlc.ForeColor = Color.LightGray;
        }

        private void linkvlc_MouseLeave(object sender, EventArgs e)
        {
            linkvlc.ForeColor = Color.Gray;
        }

        private void linkffmpeg_MouseEnter(object sender, EventArgs e)
        {
            linkffmpeg.ForeColor = Color.LightGray;
        }

        private void linkffmpeg_MouseLeave(object sender, EventArgs e)
        {
            linkffmpeg.ForeColor = Color.Gray;
        }

        private void linkytdlp_Click(object sender, EventArgs e)
        {
            string URL = "https://github.com/yt-dlp/yt-dlp/releases";
            Process.Start(new ProcessStartInfo(URL) { UseShellExecute = true });
        }

        private void linkvlc_Click(object sender, EventArgs e)
        {
            string URL = "https://www.videolan.org/";
            Process.Start(new ProcessStartInfo(URL) { UseShellExecute = true });
        }

        private void linkffmpeg_Click(object sender, EventArgs e)
        {
            string URL = "https://www.ffmpeg.org/download.html";
            Process.Start(new ProcessStartInfo(URL) { UseShellExecute = true });
        }
    }
}
