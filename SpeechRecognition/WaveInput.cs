using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NAudio.Wave;
using NAudio.Mixer;
using NAudio;
using System.Collections;

namespace SpeechRecognition
{
    class WaveInput
    {
        WaveIn waveIn;
        WaveFileWriter WFile;
        ArrayList Signal;
        private bool SaveFile;
        public const int SAMPLE_FREQ = 22050;

        public static void PrepareMic()
        {
            WaveIn waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(SAMPLE_FREQ, 16, 1);
            waveIn.StartRecording();
            waveIn.StopRecording();
            waveIn.Dispose();
        }
        public WaveInput(out ArrayList signal, bool savefile = true)
        {
            signal = (Signal = new ArrayList(0));
            SaveFile = savefile;
        }

        public void StartRecording(EventHandler<WaveInEventArgs> OnDataAvailable)
        {            
            waveIn = new WaveIn();
            waveIn.DataAvailable += waveIn_OnDataAvailable;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnDataStopped;
            waveIn.WaveFormat = new WaveFormat(SAMPLE_FREQ, 16, 1);
            waveIn.StartRecording();

            if (SaveFile)
            {
                string fileName = DateTime.Now.TimeOfDay.ToString().Remove(8, 8).Replace(':', '.') + ".wav";
                Directory.CreateDirectory("waves");
                WFile = new WaveFileWriter("waves/" + fileName, waveIn.WaveFormat);
                Logger.Add("Sound File recorded in " + fileName);
            }
            else
            {
                Logger.Add("Sound File isn't recording");
            }
        }

        public void waveIn_OnDataAvailable(object sender, WaveInEventArgs e)
        {
            float tmp;

            //List<byte> buf = new List<byte>(0);

            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                tmp = (short)((e.Buffer[i + 1] << 8) | (e.Buffer[i]));
                Signal.Add((double)tmp/*/(32758d)*/);             
                //buf.Add((byte)(((short)tmp & 255)));
                //buf.Add((byte)(((short)tmp >> 8) & 255));
            }
            if (SaveFile)
                WFile.Write(e.Buffer, 0, e.BytesRecorded);

        }
        public void StopRecording()
        {
            if (waveIn != null)
                waveIn.StopRecording();
        }
        public void OnDataStopped(object sender, StoppedEventArgs e)
        {
            if (waveIn != null)
                waveIn.Dispose();
            if (WFile != null)
                WFile.Close();
        }

        public void TeachFromFiles(string filename)
        {
            if (filename.IndexOf('\\') == -1)
                filename = "teach\\" + filename;
            using (WaveFileReader WRead = new WaveFileReader(filename))
            {

                byte[] tmpBytes = new byte[WRead.SampleCount * 2];
                WRead.Read(tmpBytes, 0, (int)WRead.SampleCount * 2);
                Signal.Capacity = (int)WRead.SampleCount * 2;
                float tmp;
                for (int i = 0; i < tmpBytes.Count(); i += 2)
                {
                    tmp = (short)((tmpBytes[i + 1] << 8) | (tmpBytes[i]));
                    Signal.Add((double)tmp);
                }
            }
        }
    }
}
