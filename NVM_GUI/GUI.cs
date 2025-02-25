using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NVM_GUI
{
    public partial class GUI : Form
    {
        [GeneratedRegex(@"^(\d{1,2})\.(\d{1,2})\.(\d{1,2})$")]
        private static partial Regex ValidVersion();

        [GeneratedRegex(@"\s*\(.*\)")]
        private static partial Regex VersionCleanerRegex();

        static readonly string NvmUrl = "https://github.com/coreybutler/nvm-windows";
        static string ? nvmVersion;

        public GUI()
        {
            InitializeComponent();
        }

        private bool IsVersionIntalled
        {
            get
            {
                List<string> versions = [.. versionComboBox.Items.Cast<string>().Select(item => item.Replace("*", "").Trim())];

                return versions.Contains(versionTextBox.Text);
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {   
            this.SetVersion();

            if (string.IsNullOrEmpty(nvmVersion)) 
            {
                return;
            }

            this.GetNMVList();
            this.ValidateVersionComboBox();
        }

        private void UpdateVersionBtn_Click(object sender, EventArgs e)
        {
            string version = versionComboBox.Text;

            if (!ValidVersion().IsMatch(version))
            {
                MessageBox.Show("Invalid version selected.");

                return;
            }

            string output = Program.RunCommand($"nvm use {version}");

            if (string.IsNullOrEmpty(output))
            {
                return;
            }

            Program.ShowCustomMessage(output);

            this.GetNMVList();
        }

        private void VersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateVersionComboBox();
        }

        private void NvmLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = NvmUrl,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (!ValidVersion().IsMatch(versionTextBox.Text))
            {
                return;
            }

            InstallButton.Enabled = false;

            string command = IsVersionIntalled ? "nvm uninstall" : "nvm install";

            string output = Program.RunCommand($"{command} {versionTextBox.Text.Trim()}");

            if (string.IsNullOrEmpty(output)) { 
                return;
            }

            Program.ShowCustomMessage(output);
            this.GetNMVList();

            versionTextBox.Clear();
            InstallButton.Text = "Install";
            installVersionLabel.Text = "";
            InstallButton.Enabled = true;
        }

        private void VersionTextBox_TextChanged(object sender, EventArgs e)
        {
            InstallButton.Text = "Install";

            // verify if the version is valid
            if (ValidVersion().IsMatch(versionTextBox.Text))
            {
                installVersionLabel.Text = "✅ Valid version";
                installVersionLabel.ForeColor = Color.Green;
                InstallButton.Enabled = true;

                // verify if the version is already installed
                if (IsVersionIntalled)
                {
                    installVersionLabel.Text = "❌ Version already installed";
                    installVersionLabel.ForeColor = Color.Red;
                    InstallButton.Text = "Uninstall";
                }
            }
            else
            {
                installVersionLabel.Text = "❌ Incorrect format (Ex: 16.14.0)";
                installVersionLabel.ForeColor = Color.Red;
                InstallButton.Enabled = false;
            }
        }

        /**
         * Get the list of Node.js versions
         */
        private void GetNMVList()
        {
            string output = Program.RunCommand("nvm list");

            if (string.IsNullOrEmpty(output) || output.Contains("recognized"))
            {
                return;
            }

            List<string> versions = [.. output.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                                 .Select(line => line.Trim())
                                 .Select(v => VersionCleanerRegex().Replace(v, ""))];


            this.SetVersions(versions);
        }

        /**
         * Set the versions in the ComboBox
         * @param versions List of versions
         */
        private void SetVersions(List<string> versions)
        {
            if (versions.Count == 0)
            {
                MessageBox.Show("No Node.js versions found.");
                return;
            }

            string? selectedVersion = versions.FirstOrDefault(v => v.Contains('*'));

            versionComboBox.Items.Clear();
            versionComboBox.Items.AddRange([.. versions]);

            // If there is a selected version, set it as the selected item
            if (selectedVersion != null)
            {
                versionComboBox.SelectedItem = selectedVersion;
            }
        }

        /**
         * Validate the version ComboBox
         */
        private void ValidateVersionComboBox()
        {
            if (versionComboBox.SelectedIndex == -1)
            {
                noVersionSelectedLabel.Show();
                updateVersionButton.Enabled = false;
            }
            else if (versionComboBox.Text.Contains('*'))
            {
                updateVersionButton.Enabled = false;
                noVersionSelectedLabel.Hide();
            }
            else
            {
                noVersionSelectedLabel.Hide();
                updateVersionButton.Enabled = true;
            }
        }

        private void SetVersion()
        {
            string output = Program.RunCommand("nvm --version", false);

            if (string.IsNullOrEmpty(output))
            {
               InstallButton.Enabled = false;
               updateVersionButton.Enabled = false;

               this.Text = $"{this.Text} - NVM Version: Not installed";

               helpPictureBox.Visible = true;

                return;

            }

            nvmVersion = output.Trim();

            this.Text = $"{this.Text} - NVM Version: {nvmVersion}";
        }
    }
}
