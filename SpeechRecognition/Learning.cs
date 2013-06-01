using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace SpeechRecognition
{
    class Learning
    {
        public const int COUNT = 3;
        public const int M = RawTransform.NEEDED_COEFS;
        public Learning() 
        {
            RecCommands = new ArrayList(0);
        }

        public ArrayList Average()
        {
            ArrayList Aver = new ArrayList(M);

            for (int i = 0; i < COUNT; i++)
            {
                RecCommands[i] = Normalize((ArrayList)RecCommands[i]);
            }

            for (int i = 0; i < M; i++)
            {
                Aver.Add(0d);

                for (int j = 0; j < COUNT; j++)
                {
                    Aver[i] = (double)Aver[i] + (double)((ArrayList)RecCommands[j])[i];
                }

                Aver[i] = (double)Aver[i] / COUNT;
               
            }

            return Normalize((ArrayList)Aver); 
        }    

        public static ArrayList Normalize(ArrayList Aver)
        {
            double summ = 0;
            for (int i = 0; i < Aver.Count; i++)
            {
                summ += ((double)Aver[i]*(double)Aver[i]);
            }
            summ = Math.Sqrt(summ);
            ArrayList Temp = new ArrayList(Aver.Count);
            for (int i = 0; i < Aver.Count; i++)
            {
                Temp.Add((double)Aver[i] / summ);
            }
            return Temp;
        } 
        
        public ArrayList RecCommands {get; set;}
    }
}
