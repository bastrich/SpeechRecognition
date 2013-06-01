namespace SpeechRecognition
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.BoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.PrbLearning = new System.Windows.Forms.ProgressBar();
            this.LblProg = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAutoAdd = new System.Windows.Forms.Button();
            this.chbAutoHelp = new System.Windows.Forms.CheckBox();
            this.tbAutoFiles = new System.Windows.Forms.TextBox();
            this.tbAutoName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoxName
            // 
            this.BoxName.Location = new System.Drawing.Point(34, 20);
            this.BoxName.Name = "BoxName";
            this.BoxName.Size = new System.Drawing.Size(243, 20);
            this.BoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название Команды";
            // 
            // BtnStart
            // 
            this.BtnStart.BackgroundImage = global::SpeechRecognition.Properties.Resources.vista_play_button_psd_by_experiencearts;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStart.Location = new System.Drawing.Point(34, 46);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(104, 100);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.BackgroundImage = global::SpeechRecognition.Properties.Resources.Stop_Normal_Red_icon;
            this.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStop.Location = new System.Drawing.Point(178, 46);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(99, 100);
            this.BtnStop.TabIndex = 3;
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Visible = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // PrbLearning
            // 
            this.PrbLearning.Location = new System.Drawing.Point(34, 182);
            this.PrbLearning.Name = "PrbLearning";
            this.PrbLearning.Size = new System.Drawing.Size(243, 23);
            this.PrbLearning.TabIndex = 4;
            // 
            // LblProg
            // 
            this.LblProg.AutoSize = true;
            this.LblProg.Location = new System.Drawing.Point(31, 166);
            this.LblProg.Name = "LblProg";
            this.LblProg.Size = new System.Drawing.Size(139, 13);
            this.LblProg.TabIndex = 5;
            this.LblProg.Text = "Запишите команду 3 раза";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(34, 504);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(104, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Сохранить";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(178, 504);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Отмена";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 58);
            this.button1.TabIndex = 8;
            this.button1.Text = "Начать всю запись заново";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 58);
            this.button2.TabIndex = 9;
            this.button2.Text = "Перезаписть последнию запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 209);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 559);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.BoxName);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.BtnStart);
            this.tabPage1.Controls.Add(this.BtnCancel);
            this.tabPage1.Controls.Add(this.BtnStop);
            this.tabPage1.Controls.Add(this.BtnSave);
            this.tabPage1.Controls.Add(this.PrbLearning);
            this.tabPage1.Controls.Add(this.LblProg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(316, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Запись";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAutoAdd);
            this.tabPage2.Controls.Add(this.chbAutoHelp);
            this.tabPage2.Controls.Add(this.tbAutoFiles);
            this.tabPage2.Controls.Add(this.tbAutoName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(316, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Авто";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAutoAdd
            // 
            this.btnAutoAdd.Location = new System.Drawing.Point(35, 178);
            this.btnAutoAdd.Name = "btnAutoAdd";
            this.btnAutoAdd.Size = new System.Drawing.Size(106, 45);
            this.btnAutoAdd.TabIndex = 4;
            this.btnAutoAdd.Text = "Добавить";
            this.btnAutoAdd.UseVisualStyleBackColor = true;
            this.btnAutoAdd.Click += new System.EventHandler(this.btnAutoAdd_Click);
            // 
            // chbAutoHelp
            // 
            this.chbAutoHelp.AutoSize = true;
            this.chbAutoHelp.Checked = true;
            this.chbAutoHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAutoHelp.Location = new System.Drawing.Point(37, 155);
            this.chbAutoHelp.Name = "chbAutoHelp";
            this.chbAutoHelp.Size = new System.Drawing.Size(123, 17);
            this.chbAutoHelp.TabIndex = 3;
            this.chbAutoHelp.Text = "Предлагать файлы";
            this.chbAutoHelp.UseVisualStyleBackColor = true;
            // 
            // tbAutoFiles
            // 
            this.tbAutoFiles.Location = new System.Drawing.Point(35, 46);
            this.tbAutoFiles.Multiline = true;
            this.tbAutoFiles.Name = "tbAutoFiles";
            this.tbAutoFiles.Size = new System.Drawing.Size(242, 104);
            this.tbAutoFiles.TabIndex = 2;
            this.tbAutoFiles.WordWrap = false;
            // 
            // tbAutoName
            // 
            this.tbAutoName.Location = new System.Drawing.Point(34, 20);
            this.tbAutoName.Name = "tbAutoName";
            this.tbAutoName.Size = new System.Drawing.Size(243, 20);
            this.tbAutoName.TabIndex = 1;
            this.tbAutoName.TextChanged += new System.EventHandler(this.tbAutoName_TextChanged);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 562);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(369, 600);
            this.MinimumSize = new System.Drawing.Size(369, 600);
            this.Name = "AddForm";
            this.Text = "Обучение";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.ProgressBar PrbLearning;
        private System.Windows.Forms.Label LblProg;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbAutoName;
        private System.Windows.Forms.TextBox tbAutoFiles;
        private System.Windows.Forms.Button btnAutoAdd;
        private System.Windows.Forms.CheckBox chbAutoHelp;

    }
}