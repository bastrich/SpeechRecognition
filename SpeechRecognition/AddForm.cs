using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace SpeechRecognition
{
    public partial class AddForm : Form
    {
        int ComCounter= Learning.COUNT;
       
        Learning Learn;

        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            Learn = new Learning();
            LblProg.Text = string.Format("Запишите команду {0} раза", Learning.COUNT);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (ComCounter == 0)
            {
                System.Windows.Forms.MessageBox.Show("Кончайте!");
                return;
            }
            BtnStart.Visible = false;
            BtnStop.Visible = true;
            SoundProcessing.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Learn.RecCommands.Add(SoundProcessing.Stop());

            ComCounter--;
            if (ComCounter == 0)
                LblProg.Text = string.Format("Запишите команду еще {0} раз", ComCounter);
            else
                LblProg.Text = string.Format("Запишите команду еще {0} раза", ComCounter);
            PrbLearning.Value = 100 * (Learning.COUNT - ComCounter) / Learning.COUNT;

            BtnStart.Visible = true;
            BtnStop.Visible = false;

            if (ComCounter == 0) BtnSave.Visible = true;

            Bitmap Bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackgroundImage = Bmp;
            LBPlot.DrawPlot(SoundProcessing.LastFFT /*. GetRange(0,SoundProcessing.LastAmplify.Length/128)*/, Bmp,false);
            //DigitalSignal.DrawPlot(SoundProcessing.LastFFT, Bmp, false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ComCounter != 0)
            {
                return;
            }
            Command Com = new Command();
            Com.Name = BoxName.Text;
            Com.Coefs = Learn.Average();
            ((MainForm)this.Owner).Speech.Commands.Add(Com);
            ((MainForm)this.Owner).ListCommands.Items.Add(Com.Name);

            for (int j = 0; j < Learning.COUNT; j++)
            {
                ((MainForm)this.Owner).tbxLogs.AppendText( "Дистанция между " + j.ToString() + "-тым вектором обучения и средним вектором - " + MainSpeech.getDistance(Com.Coefs, (ArrayList)Learn.RecCommands[j]) +"\r\n");
            }

            ((MainForm)this.Owner).tbxLogs.SelectionStart = ((MainForm)this.Owner).tbxLogs.Text.Length;
            ((MainForm)this.Owner).tbxLogs.ScrollToCaret();

            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Learn.RecCommands.Clear();
            ComCounter = Learning.COUNT;

            LblProg.Text = string.Format("Запишите команду {0} раза", Learning.COUNT);
            PrbLearning.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ComCounter != Learning.COUNT)
            {
                Learn.RecCommands.RemoveAt(Learn.RecCommands.Count - 1);

                if (ComCounter == Learning.COUNT)
                    return;
                ComCounter++;
                LblProg.Text = string.Format("Запишите команду еще {0} раза", ComCounter);
                PrbLearning.Value = 100 * (Learning.COUNT - ComCounter) / Learning.COUNT;
            }
        }

        private void tbAutoName_TextChanged(object sender, EventArgs e)
        {
            if (chbAutoHelp.Checked&(tbAutoName.TextLength>0))
            {
                if (Directory.Exists("teach"))
                {
                    string[] Files = Directory.GetFiles(Directory.GetCurrentDirectory() + "/teach/", tbAutoName.Text + '*');
                    tbAutoFiles.Text = "";
                    for (int i = 0; i < Files.Count(); i++)
                    {
                        FileInfo FI = new FileInfo(Files[i]);
                        tbAutoFiles.AppendText(FI.Name + "\r\n");
                    }
                }

            }
        }

        private void btnAutoAdd_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < Learning.COUNT; j++)
			{
			    Learn.RecCommands.Add(SoundProcessing.AutoTeach(tbAutoFiles.Lines[j]));
			}
            ComCounter = 0;
            BtnSave_Click(sender,e);
        }
    }
}
