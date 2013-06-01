// -----------------------------------------------------------------------
// <copyright file="FFT.cs" company="None.">
//  By Philip R. Braica (HoshiKata@aol.com, VeryMadSci@gmail.com)
//
//  Distributed under the The Code Project Open License (CPOL)
//  http://www.codeproject.com/info/cpol10.aspx
// </copyright>
// -----------------------------------------------------------------------

namespace SpeechRecognition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Simple fast FFT, lots of the usual overloads.
    /// 
    /// There are a bunch of "Forward" and "Inverse" calls, all of then
    /// support seperate buffers. There is also the popular "interlaced" 
    /// style where real and imaginary data is interlaced in the same buffer.
    /// That isn't supported in this version.
    /// 
    /// The algorithm is Cooley-Tukey, classic and so textbook I can't
    /// really call any of it "mine" it just is the way it is done.
    /// </summary>
    public class FFT
    {
        #region Public: Forward, Inverse, doubles.
        /// <summary>
        /// Compute the FFT forward in place for real data.
        /// </summary>
        /// <param name="realIn">Reals</param>
        public static void Forward(double[] reals)
        {
            doFFT(reals, true);
        }

        /// <summary>
        /// Compute the FFT forward for real data.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="realOut">Reals Out.</param>
        public static void Forward(double[] realIn, double[] realOut)
        {
            doFFTReals(realIn, realOut, true);
        }

        /// <summary>
        /// Compute forward FFT for real in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Forward(double[] realIn, double[] realOut, double[] imagOut)
        {
            doFFTReals(realIn, realOut, imagOut, true);
        }

        /// <summary>
        /// Compute forward FFT for complex in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="imagIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Forward(double[] realIn, double [] imagIn, double[] realOut, double[] imagOut)
        {
            doFFT(realIn, imagIn, realOut, imagOut, true);
        }

        /// <summary>
        /// Compute the FFT inverse in place for real data.
        /// </summary>
        /// <param name="reals">Reals in and out.</param>
        public static void Inverse(double[] reals)
        {
            doFFT(reals, false);
        }

        /// <summary>
        /// Compute the FFT inverse for real data.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="realOut">Reals Out.</param>
        public static void Inverse(double[] realIn, double[] realOut)
        {
            doFFTReals(realIn, realOut, false);
        }

        /// <summary>
        /// Compute inverse FFT for real in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Inverse(double[] realIn, double[] realOut, double[] imagOut)
        {
            doFFTReals(realIn, realOut, imagOut, true);
        }

        /// <summary>
        /// Compute inverse FFT for complex in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Inverse(double[] realIn, double[] imagIn, double[] realOut, double[] imagOut)
        {
            doFFT(realIn, imagIn, realOut, imagOut, false);
        }
        #endregion

        #region Public: Forward, Inverse, floats.
        /// <summary>
        /// Compute the FFT forward in place for real data.
        /// </summary>
        /// <param name="realIn">Reals</param>
        public static void Forward(float[] reals)
        {
            doFFT(reals, true);
        }

        /// <summary>
        /// Compute the FFT forward for real data.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="magOut">Reals Out.</param>
        public static void Forward(float[] realIn, float[] magOut)
        {
            doFFTReals(realIn, magOut, true);
        }

        /// <summary>
        /// Compute forward FFT for real in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="imagIn"></param>
        /// <param name="realOut"></param>
        public static void Forward(float[] realIn, float[] imagIn, float[] realOut)
        {
            doFFTReals(realIn, imagIn, realOut, true);
        }

        /// <summary>
        /// Compute forward FFT for complex in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Forward(float[] realIn, float[] imagIn, float[] realOut, float[] imagOut)
        {
            doFFT(realIn, imagIn, realOut, imagOut, true);
        }

        /// <summary>
        /// Compute the FFT inverse in place for real data.
        /// </summary>
        /// <param name="reals">Reals in and out.</param>
        public static void Inverse(float[] reals)
        {
            doFFT(reals, false);
        }

        /// <summary>
        /// Compute the FFT inverse for real data.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="realOut">Reals Out.</param>
        public static void Inverse(float[] realIn, float[] realOut)
        {
            doFFTReals(realIn, realOut, false);
        }

        /// <summary>
        /// Compute inverse FFT for real in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Inverse(float[] realIn, float[] realOut, float[] imagOut)
        {
            doFFTReals(realIn, realOut, imagOut, true);
        }

        /// <summary>
        /// Compute inverse FFT for complex in, complex out.
        /// </summary>
        /// <param name="realIn"></param>
        /// <param name="realOut"></param>
        /// <param name="imagOut"></param>
        public static void Inverse(float[] realIn, float[] imagIn, float[] realOut, float[] imagOut)
        {
            doFFT(realIn, imagIn, realOut, imagOut, false);
        }
        #endregion

        #region Protected static: Sine and cosine tables.
        /// <summary>
        /// Table is sin(pi/2), sin(pi/4), sin(pi/8) ...
        /// </summary>
        protected static double[] m_sinDouble = null;

        /// <summary>
        /// Same as m_sinDouble but as floats.
        /// </summary>
        protected static float[] m_sinFloat = null;

        /// <summary>
        /// Table is sin(pi/2), sin(pi/4), sin(pi/8) ...
        /// </summary>
        protected static double[] m_cosDouble = null;

        /// <summary>
        /// Same as m_sinDouble but as floats.
        /// </summary>
        protected static float[] m_cosFloat = null;

        /// <summary>
        /// Prevent race condition.
        /// </summary>
        protected static object m_tableLock = new object();
      
        /// <summary>
        /// Make the tables.
        /// </summary>
        /// <param name="size"></param>
        protected static void MakeTables()
        {

            if (m_sinDouble != null) return;
            lock (m_tableLock)
            {
                if (m_sinDouble != null) return;
                int size = 20;
                double [] nsd = new double[size];
                float [] nsf = new float[size];
                double[] ncd = new double[size];
                float[] ncf = new float[size];
                double pi = System.Math.PI;

                for (int i = 0; i < size; i++)
                {
                    nsd[i] = System.Math.Sin(pi);
                    nsf[i] = (float)(nsd[i]);
                    ncd[i] = System.Math.Cos(pi);
                    ncf[i] = (float)(ncd[i]);
                    pi = pi / 2;
                }
                m_sinFloat = nsf;
                m_sinDouble = nsd;
                m_cosFloat = ncf;
                m_cosDouble = ncd;
            }
        }
        #endregion

        #region Protected: Compute the FFT, doubles.
        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                double[] realIn, bool forward)
        {
            double[] realOut = new double[realIn.Length];
            double[] imagIn = new double[realIn.Length];
            double[] imagOut = new double[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                imagIn[i] = 0;
            }
            doFFT(realIn, imagIn, realOut, imagOut, forward);
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = System.Math.Sqrt((realOut[i] * realOut[i]) + (imagOut[i] * imagOut[i]));
            }
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFTReals(
                double[] realIn, double[] realOut, bool forward)
        {
            double[] imagIn = new double[realIn.Length];
            double[] imagOut = new double[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                imagIn[i] = 0;            
            }
            doFFT(realIn, imagIn, realOut, imagOut, forward);
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = System.Math.Sqrt((realOut[i] * realOut[i]) + (imagOut[i] * imagOut[i]));
            }
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFTReals(
                double[] realIn, double[] realOut, double [] imagOut, bool forward)
        {
            double[] imagIn = new double[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                imagIn[i] = 0;
            }
            doFFT(realIn, imagIn, realOut, imagOut, forward);
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                double[] realIn, double[] imagIn, bool forward)
        {
            double[] realOut = new double[realIn.Length];
            double[] imagOut = new double[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = realIn[i];
                imagOut[i] = imagIn[i];
            }
            doFFT(realOut, imagOut, realIn, imagIn, forward);
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                double[] realIn, double[] imagIn,
                double[] realOut, double[] imagOut, bool forward)
        {
            MakeTables();
            int n = realIn.Length;
            int i;

            // Calculate the number of bits required
            int bits = 0;
            for (i = 1; i < n; i <<= 1)
            {
                bits++;
            }

            // Copy bitreversed.
            for (i = 0; i < n; i++)
            {
                int p = bitrev(i, bits);
                realOut[p] = realIn[i];
                imagOut[p] = imagIn[i];
            }
            performFFT(realOut, imagOut, forward);
        }
        
        /// <summary>
        /// Do a bit reversal.
        /// </summary>
        /// <param name="value">Value to reverse.</param>
        /// <param name="bits">The bits.</param>
        /// <returns>The reversal.</returns>
        protected static int bitrev(int value, int bits)
        {
            // Reverse bits
            int rev = 0;
            for (int b = 0; b < bits; ++b)
            {
                rev <<= 1;
                rev |= value & 1;
                value >>= 1;
            }

            // Return reversed-bit value
            return rev;
        }

        /// <summary>
        /// Radix 2 in place.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="i"></param>
        /// <param name="forward"></param>
        protected static void performFFT(double[] r, double[] i, bool forward)
        {
            int len = r.Length;

            // Perform Cooley-Tukey fft
            double sign = forward ? 1 : -1;
            int index = 0;
            for (int p = 1; p < len; p <<= 1)
            {
                int p2 = p << 1;
                
                // Calculate sine and cosine for angle advancing
                double sine = sign * m_sinDouble[index];
                double cosine = m_cosDouble[index++];

                // Seed the angle for the butterfly loops
                double wr = 1.0;
                double wi = 0.0;

                // Perform butterfly loops, just like most text books.
                int j;
                for (j = 0; j < p; ++j)
                {
                    int k;
                    for (k = j; k < len; k += p2)
                    {
                        int k2 = k + p;

                        // Perform butterfly
                        double tr = (wr * r[k2]) - (wi * i[k2]);
                        double ti = (wr * i[k2]) + (wi * r[k2]);
                        r[k2] = r[k] - tr;
                        i[k2] = i[k] - ti;
                        r[k] += tr;
                        i[k] += ti;
                    }

                    // Advance angle
                    double nwr = (wr * cosine) - (wi * sine);
                    double nwi = (wi * cosine) + (wr * sine);
                    wr = nwr;
                    wi = nwi;
                }
            }
        }

        #endregion

        #region Protected: Compute the FFT, float.
        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                float[] realIn, bool forward)
        {
            float[] realOut = new float[realIn.Length];
            float[] imagIn = new float[realIn.Length];
            float[] imagOut = new float[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                imagIn[i] = 0;
            }
            doFFT(realIn, imagIn, realOut, imagOut, forward);
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = (float)System.Math.Sqrt((realOut[i] * realOut[i]) + (imagOut[i] * imagOut[i]));
            }
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="magOut">Real out.</param>
        protected static void doFFTReals(
                float[] realIn, float[] magOut, bool forward)
        {
            float[] imagIn = new float[realIn.Length];
            float[] imagOut = new float[realIn.Length];
            float[] realOut = new float[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                imagIn[i] = 0;
            }
            doFFT(realIn, imagIn, realOut, imagOut, forward);
            for (int i = 0; i < magOut.Length; i++)
            {
                magOut[i] = (float)System.Math.Sqrt((realOut[i] * realOut[i]) + (imagOut[i] * imagOut[i]));
            }
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFTReals(
                float[] realIn, float[] imagIn, float[] realOut, bool forward)
        {
            float[] imagOut = new float[realIn.Length];
            doFFT(realIn, imagIn, realOut, imagOut, forward);
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = (float)System.Math.Sqrt((realOut[i] * realOut[i]) + (imagOut[i] * imagOut[i]));
            }
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                float[] realIn, float[] imagIn, bool forward)
        {
            float[] realOut = new float[realIn.Length];
            float[] imagOut = new float[realIn.Length];
            for (int i = 0; i < realIn.Length; i++)
            {
                realOut[i] = realIn[i];
                imagOut[i] = imagIn[i];
            }
            doFFT(realOut, imagOut, realIn, imagIn, forward);
        }

        /// <summary>
        /// Compute the FFT.
        /// </summary>
        /// <param name="realIn">Reals in.</param>
        /// <param name="imagIn">Imaginary in.</param>
        /// <param name="realOut">Real out.</param>
        /// <param name="imagOut">Imaginary out.</param>
        protected static void doFFT(
                float[] realIn, float[] imagIn,
                float[] realOut, float[] imagOut, bool forward)
        {
            MakeTables();

            int n = realIn.Length;
            int i;

            // Calculate the number of bits required
            int bits = 0;
            for (i = 1; i < n; i <<= 1)
            {
                bits++;
            }

            n = 1 << (bits-1);
            // Copy bitreversed.
            for (i = 0; i < n; i++)
            {
                int p = bitrev(i, bits);
                realOut[p] = realIn[i];
                imagOut[p] = imagIn[i];
            }
            performFFT(realOut, imagOut, forward);
        }

        /// <summary>
        /// Radix 2 in place.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="i"></param>
        /// <param name="forward"></param>
        protected static void performFFT(float[] r, float[] i, bool forward)
        {
            int len = r.Length;

            // Perform Cooley-Tukey fft
            float sign = forward ? 1 : -1;
            int index = 0;
            for (int p = 1; p < len; p <<= 1)
            {
                int p2 = p << 1;

                // Calculate sine and cosine for angle advancing
                float sine = sign * m_sinFloat[index];
                float cosine = m_cosFloat[index++];

                // Seed the angle for the butterfly loops
                float wr = 1.0f;
                float wi = 0.0f;

                // Perform butterfly loops, just like most text books.
                int j;
                for (j = 0; j < p; j++)
                {
                    int k;
                    for (k = j; k < len; k += p2)
                    {
                        int k2 = k + p;

                        // Perform butterfly
                        float tr = (wr * r[k2]) - (wi * i[k2]);
                        float ti = (wr * i[k2]) + (wi * r[k2]);
                        r[k2] = r[k] - tr;
                        i[k2] = i[k] - ti;
                        r[k] += tr;
                        i[k] += ti;
                    }

                    // Advance angle
                    float nwr = (wr * cosine) - (wi * sine);
                    float nwi = (wi * cosine) + (wr * sine);
                    wr = nwr;
                    wi = nwi;
                }
            }
        }

        #endregion

    }
}
