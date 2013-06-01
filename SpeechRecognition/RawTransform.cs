using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeechRecognition
{
    class RawTransform
    {
        //private const int FRAME = 512;
        //private const int SHIFT = 100;

        public static void Transform(ref double[] signal)
        {
            //for (int i = 1; i < signal.Length; i++)
            //{
            //    signal[i] -= 0.95 * signal[i - 1];
            //}

            //int countOfShifts = signal.Length / SHIFT;

            double[] realOut = new double[signal.Length], imageOut = new double[signal.Length];
            FFT.Forward(signal, realOut, imageOut);
            signal = new double[signal.Length / 2];

            for (int i = 0; i < signal.Length; i++)
            {
                signal[i] = (realOut[i] * realOut[i] + imageOut[i] * imageOut[i]) / signal.Length;
                //signal[i] = (realOut[i] * realOut[i]) / signal.Length;
            }
        }

        private const int MIN_FREQ = 300;
        private const int MAX_FREQ = 8000;
        private const int MIN_SAMPLE = 0;
        private const int MAX_SAMPLE = 20000;
        public const int COUNT_OF_FILTERS = 26;
        public const int NEEDED_COEFS = 13;

        private static int[] freqs;
        private static int SpectrumWidth;

        public static double[] getMFCC(double[] EnergySpectrum)
        {
            SpectrumWidth = EnergySpectrum.Length;
            double min = FreqToMel(MIN_FREQ);
            double max = FreqToMel(MAX_FREQ);
            double current = min;

            double width = (max - min) / (COUNT_OF_FILTERS + 1);

            freqs = new int[COUNT_OF_FILTERS + 2];

            for (int i = 0; i < freqs.Length; i++, current += width)
            {
                freqs[i] = FreqToSample(MelToFreq(current));
            }


            double[] MFCC = new double[COUNT_OF_FILTERS];


            for (int i = 0; i < MFCC.Length; i++)
            {
                double c = 0;
                for (int j = 0; j < EnergySpectrum.Length; j++)
                {
                    c += EnergySpectrum[j] * filtr(i + 1, j);
                }

                MFCC[i] = Math.Log(c);
            }

            double[] newMFCC = DCT(MFCC);
            //FFT.Inverse(MFCC, newMFCC);

            return newMFCC;
        }

        public static double[] getNeedMFCC(double[] Mfcc)
        {
            double[] mfcc = new double[NEEDED_COEFS];
            for (int i = 0; i < mfcc.Length; i++)
            {
                mfcc[i] = Mfcc[i + 1];
            }
            return mfcc;
        }

        private static double filtr(int NumOfC, double n)
        {
            if (n < freqs[NumOfC - 1]) return 0;
            if (n >= freqs[NumOfC - 1] && n <= freqs[NumOfC]) return (n - freqs[NumOfC - 1]) / (freqs[NumOfC] - freqs[NumOfC - 1]);
            if (n >= freqs[NumOfC] && n <= freqs[NumOfC + 1]) return (freqs[NumOfC + 1] - n) / (freqs[NumOfC + 1] - freqs[NumOfC]);
            if (n > freqs[NumOfC + 1]) return 0;
            else return 0;
        }

        private static double[] DCT(double[] realIn)
        {
            double[] mfcc = new double[realIn.Length];
            for (int i = 0; i < mfcc.Length; i++)
            {
                double c = 0;
                for (int j = 0; j < realIn.Length; j++)
                {
                    c += realIn[j] * Math.Cos((Math.PI * (2 * j + 1) * i) / (2 * realIn.Length));
                }
                mfcc[i] = c;
            }

            return mfcc;
        }

        private static double FreqToMel(double freq)
        {
            return 1125 * Math.Log(1d + freq / 700);
        }

        private static double HammingWin(int n, int N)
        {
            return 0.54 - 0.46 * Math.Cos((2 * Math.PI * (double)n) / (double)(N - 1));
        }

        private static double MelToFreq(double mel)
        {
            return 700 * (Math.Exp(mel / 1125) - 1d);
        }

        private static double SampleToFreq(double c)
        {
            return (c / SpectrumWidth) * WaveInput.SAMPLE_FREQ;
        }

        private static int FreqToSample(double f)
        {
            return (int)(((double)SpectrumWidth / (double)WaveInput.SAMPLE_FREQ) * f);
        }
    }
}
