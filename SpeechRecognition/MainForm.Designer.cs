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
            this.ListCommands = new System.Windows.Forms.ListBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.tbxLogs = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListCommands
            // 
            this.ListCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListCommands.FormattingEnabled = true;
            this.ListCommands.Location = new System.Drawing.Point(970, 0);
            this.ListCommands.Name = "ListCommands";
            this.ListCommands.Size = new System.Drawing.Size(208, 628);
            this.ListCommands.TabIndex = 0;
            this.ListCommands.SelectedIndexChanged += new System.EventHandler(this.ListCommands_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(968, 639);
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
            this.BtnDelete.Location = new System.Drawing.Point(1103, 639);
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
            this.BtnStop.Location = new System.Drawing.Point(35, 215);
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
            this.BtnStart.Location = new System.Drawing.Point(35, 50);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(110, 116);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // tbxLogs
            // 
            this.tbxLogs.Location = new System.Drawing.Point(193, 327);
            this.tbxLogs.Multiline = true;
            this.tbxLogs.Name = "tbxLogs";
            this.tbxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLogs.Size = new System.Drawing.Size(745, 323);
            this.tbxLogs.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(196, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 260);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Коэффициенты MFCC";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(674, 222);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 100);
            this.button1.TabIndex = 8;
            this.button1.Text = "Обзор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 674);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbxLogs);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.ListCommands);
            this.Name = "MainForm";
            this.Text = "-";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button button1;
    }
}

