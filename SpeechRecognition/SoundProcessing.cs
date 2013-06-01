using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace SpeechRecognition
{
    static class SoundProcessing
    {
        private static ArrayList Signal; //массив для хранения данных записи
        private static double[] Coefs; //массив для хранения MFCC
        static WaveInput sound; //объект записи звука
        public static double[] LastFFT; //данные для графика Фурье
        public static double[] LastAmplify; //данные отсчета амплитуд для графика

        public static void Start()
        {
            sound = new WaveInput(out Signal);
            sound.StartRecording(null);
        }
        public static ArrayList Stop()
        {
            sound.StopRecording();
            return Calculate();
        }
        public static ArrayList Calculate()
        {
            int secpow = Convert.ToInt32(Math.Ceiling(Math.Log(Signal.Count, 2)));
            Signal.AddRange(ArrayList.Repeat(0d, (int)Math.Pow(2,secpow) - Signal.Count));
            //Signal.AddRange(Signal.GetRange(0,(int)Math.Pow(2, secpow) - Signal.Count));         

            double[] signal = (double[])Signal.ToArray(typeof(System.Double));
            LastAmplify = (double[])signal.Clone(); 
           
            RawTransform.Transform(ref signal);
            //ArrayList fftArray = DigitalSignal.FFTransform(Signal);
            
            LastFFT = (double[])signal.Clone();           
            
            Coefs = RawTransform.getMFCC(signal);

            Coefs = RawTransform.getNeedMFCC(Coefs);
            string s = "";
            for (int i = 0; i < Coefs.Length; i++)
            {
                s += "  " + Coefs[i].ToString();
            }
            Logger.Add("Calculated coeficients: " + s);
            ArrayList coef = new ArrayList(Coefs.Length);
            for (int i = 0; i < Coefs.Length; i++)
            {
                coef.Add(Coefs[i]);
            }
            return coef;
        }
        public static ArrayList AutoTeach(string filename)
        {
            sound = new WaveInput(out Signal);
            sound.TeachFromFiles(filename);
            return Calculate();
        }    
    }
}
