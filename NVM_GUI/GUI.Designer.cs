namespace NVM_GUI
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            versionComboBox = new ComboBox();
            label1 = new Label();
            updateVersionButton = new Button();
            noVersionSelectedLabel = new Label();
            nvmLinkLabel = new LinkLabel();
            label2 = new Label();
            groupBox1 = new GroupBox();
            installVersionLabel = new Label();
            InstallButton = new Button();
            versionTextBox = new TextBox();
            helpPictureBox = new PictureBox();
            helpTooltip = new ToolTip(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)helpPictureBox).BeginInit();
            SuspendLayout();
            // 
            // versionComboBox
            // 
            versionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            versionComboBox.FormattingEnabled = true;
            versionComboBox.Location = new Point(28, 60);
            versionComboBox.Name = "versionComboBox";
            versionComboBox.Size = new Size(121, 23);
            versionComboBox.TabIndex = 0;
            versionComboBox.SelectedIndexChanged += VersionComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 42);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Versions available";
            // 
            // updateVersionButton
            // 
            updateVersionButton.Location = new Point(155, 60);
            updateVersionButton.Name = "updateVersionButton";
            updateVersionButton.Size = new Size(75, 23);
            updateVersionButton.TabIndex = 2;
            updateVersionButton.Text = "Update";
            updateVersionButton.UseVisualStyleBackColor = true;
            updateVersionButton.Click += UpdateVersionBtn_Click;
            // 
            // noVersionSelectedLabel
            // 
            noVersionSelectedLabel.AutoSize = true;
            noVersionSelectedLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noVersionSelectedLabel.ForeColor = Color.Red;
            noVersionSelectedLabel.Location = new Point(27, 86);
            noVersionSelectedLabel.Name = "noVersionSelectedLabel";
            noVersionSelectedLabel.Size = new Size(122, 13);
            noVersionSelectedLabel.TabIndex = 3;
            noVersionSelectedLabel.Text = "❌ No version selected";
            // 
            // nvmLinkLabel
            // 
            nvmLinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nvmLinkLabel.AutoSize = true;
            nvmLinkLabel.Location = new Point(170, 259);
            nvmLinkLabel.Name = "nvmLinkLabel";
            nvmLinkLabel.Size = new Size(83, 15);
            nvmLinkLabel.TabIndex = 4;
            nvmLinkLabel.TabStop = true;
            nvmLinkLabel.Text = "nvm-windows";
            nvmLinkLabel.LinkClicked += NvmLinkLabel_LinkClicked;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 259);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 5;
            label2.Text = "Make sure you have installed";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(installVersionLabel);
            groupBox1.Controls.Add(InstallButton);
            groupBox1.Controls.Add(versionTextBox);
            groupBox1.Location = new Point(27, 136);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Install version";
            // 
            // installVersionLabel
            // 
            installVersionLabel.AutoSize = true;
            installVersionLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            installVersionLabel.ForeColor = Color.Red;
            installVersionLabel.Location = new Point(17, 72);
            installVersionLabel.Name = "installVersionLabel";
            installVersionLabel.Size = new Size(0, 13);
            installVersionLabel.TabIndex = 4;
            // 
            // InstallButton
            // 
            InstallButton.Enabled = false;
            InstallButton.Location = new Point(186, 46);
            InstallButton.Name = "InstallButton";
            InstallButton.Size = new Size(75, 23);
            InstallButton.TabIndex = 1;
            InstallButton.Text = "Install";
            InstallButton.UseVisualStyleBackColor = true;
            InstallButton.Click += InstallButton_Click;
            // 
            // versionTextBox
            // 
            versionTextBox.Location = new Point(17, 46);
            versionTextBox.Name = "versionTextBox";
            versionTextBox.Size = new Size(163, 23);
            versionTextBox.TabIndex = 0;
            versionTextBox.TextChanged += VersionTextBox_TextChanged;
            // 
            // helpPictureBox
            // 
            helpPictureBox.BackgroundImage = Properties.Resources._40797_help_blue_icon;
            helpPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            helpPictureBox.Location = new Point(274, 22);
            helpPictureBox.Name = "helpPictureBox";
            helpPictureBox.Size = new Size(99, 88);
            helpPictureBox.TabIndex = 7;
            helpPictureBox.TabStop = false;
            helpTooltip.SetToolTip(helpPictureBox, "If you have already installed NVM and it is not recognized, restarting \r\nyour PC to reload the environment variables may fix the issue.");
            helpPictureBox.Visible = false;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 283);
            Controls.Add(helpPictureBox);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(nvmLinkLabel);
            Controls.Add(noVersionSelectedLabel);
            Controls.Add(updateVersionButton);
            Controls.Add(label1);
            Controls.Add(versionComboBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NVM_GUI";
            Load += GUI_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)helpPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox versionComboBox;
        private Label label1;
        private Button updateVersionButton;
        private Label noVersionSelectedLabel;
        private LinkLabel nvmLinkLabel;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox versionTextBox;
        private Button InstallButton;
        private Label installVersionLabel;
        private PictureBox helpPictureBox;
        private ToolTip helpTooltip;
    }
}
