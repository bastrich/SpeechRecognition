using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpeechRecognition
{
    public partial class DWTTest : Form
    {
        public DWTTest()
        {
            InitializeComponent();
        }
        ArrayList Data;
        LBPlot FilePlot, FPlot, TmpPlot;
        ArrayList DataBase = new ArrayList(1);
        int dataLength;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpD = new OpenFileDialog();
            if (OpD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.Text = OpD.FileName;
                WaveInput WI = new WaveInput(out Data);
                WI.TeachFromFiles(OpD.FileName);
                WI.StopRecording();
                pictureBox1.Image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                FilePlot = new LBPlot(Graphics.FromImage(pictureBox1.Image), pictureBox1.DisplayRectangle);
                FPlot = new LBPlot(Graphics.FromImage(pictureBox2.Image), pictureBox2.DisplayRectangle);
                if (TmpPlot == null)
                {
     
                    TmpPlot = new LBPlot(Graphics.FromImage(pictureBox3.Image), pictureBox3.DisplayRectangle);
                }
                else
                    TmpPlot.Restore(Graphics.FromImage(pictureBox3.Image));
                int l, r;
                FindVocal(Data, 256,out l, out r);
                Data = Data.GetRange(l, r - l);
                PrepareArray(ref Data,512);
                FilePlot.AddData(Data);
                FilePlot.DrawData();
                ProcessData(512);
                TmpPlot.DrawData();
            }
        }
        private void PrepareArray(ref ArrayList Data, int forWindowSize)
        {
            int sc = (Data.Count / forWindowSize + 1) * forWindowSize;
            if (sc - Data.Count < forWindowSize)
                for (int i = sc - Data.Count; i > 0; i--)
                {
                    Data.Add(0.0d);
                }
            /*int size = Data.Count;
            int p = Convert.ToInt32(Math.Ceiling(Math.Log(size, 2)));
            size = Convert.ToInt32(Math.Pow(2, p));
            for (int i = size - Data.Count; i > 0; i--)
            {
                Data.Add(0.0d);
            }*/

        }

        private void FindVocal(ICollection Data, int WindowSize, out int Left, out int Right)
        {
            IEnumerator En = Data.GetEnumerator();
            IEnumerator Last = Data.GetEnumerator();
            En.MoveNext();
            Last.MoveNext();
            double lastE = (double)Convert.ChangeType(En.Current, typeof(double));
            double lastL = (double)Convert.ChangeType(Last.Current, typeof(double));
            double EnergyR = 0;
            double[] temp = new double[Data.Count+1];
            double[] energy = new double[Data.Count + 1];
            double[] some = new double[Data.Count + 1];
            double maxSome = 0;
            int ZCR = 0;
            for (int left = 0; left < WindowSize; left++)
            {
                En.MoveNext();
                double nextE = (double)Convert.ChangeType(En.Current, typeof(double));
                EnergyR += nextE * nextE;
                ZCR += Math.Abs(Math.Sign(nextE) - Math.Sign(lastE));
                lastE = nextE;
                temp[left] = ZCR;
                energy[left] = EnergyR;
                some[left] = ZCR * EnergyR;
                if (some[left] > maxSome) maxSome = some[left];
            }
            for (int left = WindowSize; left < Data.Count-1; left ++)
            {
                En.MoveNext();
                Last.MoveNext();
                double nextE = (double)Convert.ChangeType(En.Current, typeof(double));
                EnergyR += nextE * nextE;
                ZCR += Math.Abs(Math.Sign(nextE) - Math.Sign(lastE));
                lastE = nextE;
                nextE = (double)Convert.ChangeType(Last.Current, typeof(double));
                EnergyR -= nextE * nextE;
                ZCR -= Math.Abs(Math.Sign(nextE) - Math.Sign(lastL));
                lastL = nextE;

                temp[left] = ZCR;
                energy[left] = EnergyR;
                if (ZCR < WindowSize / 14)
                    some[left] = 0;
                else
                    some[left] = Math.Pow(ZCR, 1.5) * EnergyR;
                if (some[left] > maxSome) maxSome = some[left];
            }
            int VocLeft = 0;
            int VocRight = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                if (some[i] > 0.10 * maxSome)
                {
                    VocLeft = i;
                    break;
                }
                some[i] = 0;
            }
            for (int i = Data.Count-1; i >=0; i--)
            {
                if (some[i] > 0.10 * maxSome)
                {
                    VocRight = i;
                    break;
                }
                some[i] = 0;
            }
            Left = VocLeft;
            Right = VocRight;
          //  TmpPlot.SelectView(VocLeft, VocRight);
        }

        private void DWTTest_Resize(object sender, EventArgs e)
        {
            if (FilePlot != null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);

                FilePlot.Resize(pictureBox1.DisplayRectangle);
                FilePlot.Restore(Graphics.FromImage(pictureBox1.Image));
                
                FPlot.Resize(pictureBox2.DisplayRectangle);
                FPlot.Restore(Graphics.FromImage(pictureBox2.Image));

                TmpPlot.Resize(pictureBox3.DisplayRectangle);
                TmpPlot.Restore(Graphics.FromImage(pictureBox3.Image));
                
                FilePlot.DrawData();
                FPlot.DrawData();
                TmpPlot.DrawData();
            }
        }
        private void ProcessData(int WindowSize)
        {
            ArrayList Mf = new ArrayList();
            for (int left = 0; left + WindowSize < Data.Count; left+=WindowSize/2)
			{
			    double[] temp = new double[WindowSize];
                temp = (double[])Data.GetRange(left,WindowSize).ToArray(typeof(double));
                RawTransform.Transform(ref temp);
                FPlot.AddData(temp);
                temp = RawTransform.getMFCC(temp);
                
                //TmpPlot.AddData(temp);
                Mf.AddRange(temp);
			}
            if ((dataLength == 0) | (Mf.Count < dataLength))
            {
                dataLength = Mf.Count;
                TmpPlot.SelectView(0, dataLength);
            }
            DataBase.Add(Mf);

            TmpPlot.AddData(Mf);
            FPlot.DrawData();
            TmpPlot.DrawData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            FilePlot = new LBPlot(Graphics.FromImage(pictureBox1.Image), pictureBox1.DisplayRectangle);
            FPlot = new LBPlot(Graphics.FromImage(pictureBox2.Image), pictureBox2.DisplayRectangle);
            TmpPlot = new LBPlot(Graphics.FromImage(pictureBox3.Image), pictureBox3.DisplayRectangle);
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            
            double qde = 0;
            ArrayList temp = new ArrayList(dataLength);
            for (int i = 0; i < dataLength; i++)
            {
                double summ = 0;
                for (int j = 0; j < DataBase.Count; j++)
                {
                    summ += (double)((ArrayList)DataBase[j])[i];
                }
                summ /= DataBase.Count;
                for (int j = 0; j < DataBase.Count; j++)
                {
                    qde += Math.Pow((double)((ArrayList)DataBase[j])[i]-summ,2);
                }
                temp.Add(summ);
            }
            qde = Math.Sqrt(qde) / DataBase.Count / dataLength;
            TmpPlot.Clear();
            TmpPlot.AddData(temp);
            pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            TmpPlot.Restore(Graphics.FromImage(pictureBox3.Image));
            TmpPlot.DrawData();
            label1.Text += " - " + qde.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataBase.Clear();
            TmpPlot.Clear();
        }
    }
}
