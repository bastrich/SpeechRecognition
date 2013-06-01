namespace SpeechRecognition
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ListCommands = new System.Windows.Forms.ListBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.tbxLogs = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mmTeaching = new System.Windows.Forms.ToolStripMenuItem();
            this.mmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmResearch = new System.Windows.Forms.ToolStripMenuItem();
            this.gbRecognition = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbRecognition.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListCommands
            // 
            this.ListCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListCommands.FormattingEnabled = true;
            this.ListCommands.Location = new System.Drawing.Point(689, 26);
            this.ListCommands.Name = "ListCommands";
            this.ListCommands.Size = new System.Drawing.Size(208, 602);
            this.ListCommands.TabIndex = 0;
            this.ListCommands.SelectedIndexChanged += new System.EventHandler(this.ListCommands_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(687, 639);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Добавить";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Location = new System.Drawing.Point(822, 639);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Удалить";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.BackgroundImage = global::SpeechRecognition.Properties.Resources.Stop_Normal_Red_icon;
            this.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnStop.Location = new System.Drawing.Point(21, 141);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(110, 110);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Visible = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackgroundImage = global::SpeechRecognition.Properties.Resources.vista_play_button_psd_by_experiencearts;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnStart.Location = new System.Drawing.Point(21, 19);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(110, 116);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // tbxLogs
            // 
            this.tbxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLogs.Location = new System.Drawing.Point(173, 301);
            this.tbxLogs.Multiline = true;
            this.tbxLogs.Name = "tbxLogs";
            this.tbxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLogs.Size = new System.Drawing.Size(506, 327);
            this.tbxLogs.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(173, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 268);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Коэффициенты MFCC";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 233);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mmTeaching,
            this.дополнительноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem1.Text = "Главное";
            // 
            // mmExit
            // 
            this.mmExit.Name = "mmExit";
            this.mmExit.Size = new System.Drawing.Size(108, 22);
            this.mmExit.Text = "Выход";
            this.mmExit.Click += new System.EventHandler(this.mmExit_Click);
            // 
            // mmTeaching
            // 
            this.mmTeaching.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmAdd,
            this.mmDelete,
            this.mmClear});
            this.mmTeaching.Name = "mmTeaching";
            this.mmTeaching.Size = new System.Drawing.Size(74, 20);
            this.mmTeaching.Text = "Обучение";
            // 
            // mmAdd
            // 
            this.mmAdd.Name = "mmAdd";
            this.mmAdd.Size = new System.Drawing.Size(177, 22);
            this.mmAdd.Text = "Добавить Команду";
            this.mmAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // mmDelete
            // 
            this.mmDelete.Name = "mmDelete";
            this.mmDelete.Size = new System.Drawing.Size(177, 22);
            this.mmDelete.Text = "Удалить Команду";
            this.mmDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // mmClear
            // 
            this.mmClear.Name = "mmClear";
            this.mmClear.Size = new System.Drawing.Size(177, 22);
            this.mmClear.Text = "Сбросить";
            this.mmClear.Click += new System.EventHandler(this.mmClear_Click);
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmResearch});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.дополнительноToolStripMenuItem.Text = "Дополнительно";
            // 
            // mmResearch
            // 
            this.mmResearch.Name = "mmResearch";
            this.mmResearch.Size = new System.Drawing.Size(153, 22);
            this.mmResearch.Text = "Исследование";
            this.mmResearch.Click += new System.EventHandler(this.mmResearch_Click);
            // 
            // gbRecognition
            // 
            this.gbRecognition.Controls.Add(this.BtnStop);
            this.gbRecognition.Controls.Add(this.BtnStart);
            this.gbRecognition.Location = new System.Drawing.Point(12, 31);
            this.gbRecognition.Name = "gbRecognition";
            this.gbRecognition.Size = new System.Drawing.Size(153, 264);
            this.gbRecognition.TabIndex = 10;
            this.gbRecognition.TabStop = false;
            this.gbRecognition.Text = "Распознавание";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 674);
            this.Controls.Add(this.gbRecognition);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbxLogs);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.ListCommands);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Распознавание речи";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbRecognition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ListCommands;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        public System.Windows.Forms.TextBox tbxLogs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mmExit;
        private System.Windows.Forms.ToolStripMenuItem mmTeaching;
        private System.Windows.Forms.ToolStripMenuItem mmClear;
        private System.Windows.Forms.ToolStripMenuItem mmAdd;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmResearch;
        private System.Windows.Forms.GroupBox gbRecognition;
        private System.Windows.Forms.ToolStripMenuItem mmDelete;
    }
}

