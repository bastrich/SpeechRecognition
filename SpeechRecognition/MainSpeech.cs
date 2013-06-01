using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.IO;

namespace SpeechRecognition
{
    public class MainSpeech
    {


        public MainSpeech()
        {
            Commands = new ArrayList(0); //инициализация списка команд
            ReadFile(); //чтение спсика команд из файла, если файл существует

        }

        ~MainSpeech()
        {
            RecFile();
        }
        

        private void RecFile() //запись списка команд в файл
        {
            fw = new BinaryWriter(File.Create("data.dat"));

            for (int i = 0; i < Commands.Count; i++)
            {
                fw.Write(((Command)Commands[i]).Name);
                fw.Write(((Command)Commands[i]).Coefs.Count);
                for (int j = 0; j < ((Command)Commands[i]).Coefs.Count; j++)
                {
                    fw.Write((double)((Command)Commands[i]).Coefs[j]);
                }
            }

            fw.Close();
            fw.Dispose();
        }

        private void ReadFile() //чтение списка команд из файла
        {
            try
            {
                FileStream f = File.OpenRead("data.dat");
                fr = new BinaryReader(f);

                while (f.Length != f.Position)
                {
                    Command Com = new Command();
                    Com.Name = fr.ReadString();
                    Com.Coefs = new ArrayList(fr.ReadInt32());

                    for (int i = 0; i < Com.Coefs.Capacity; i++)
                    {
                        Com.Coefs.Add(fr.ReadDouble());
                    }

                    Commands.Add(Com);
                }

                f.Close();
                f.Dispose();
                fr.Close();
                fr.Dispose();
            }
            catch (Exception)
            {
             
            }
        }

        public double Compare(ArrayList result,out string name)
        {
            double min = getDistance(result, ((Command)Commands[0]).Coefs);
            name = ((Command)Commands[0]).Name;

            for (int i = 0; i < Commands.Count; i++)
            {
                double tmp = getDistance(result, ((Command)Commands[i]).Coefs);
                if (tmp < min)
                {
                    name = ((Command)Commands[i]).Name;
                    min = tmp;
                }
            }

            return min;           
        }

        public static double getDistance(ArrayList v1, ArrayList v2)
        {
            double sum = 0;

            for (int i = 0; i < v1.Count; i++)
            {
                sum += Math.Pow(((double)v1[i] - (double)v2[i]),2);
            }

            return Math.Sqrt(sum);
        }

        public ArrayList Commands { get; set; }


        private BinaryReader fr;
        private BinaryWriter fw;
    }

    public class Command
    {
        public string Name { get; set; }
        public ArrayList Coefs { get; set; }
        public ArrayList FFTCoefs { get; set; }
    }
}
