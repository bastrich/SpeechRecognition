using System;
using System.Drawing;
using System.Collections;


public class LBPlot
{
    /*public delegate double DataHash(object element);
    public delegate string DataLabel(object element);
    struct LBData
    {
        ICollection Data;
        DataHash GetCalc;
        DataLabel GetLabel;
    }
    struct LBData
    {
        ICollection Data;
    }*/
    Graphics dDest;
    Bitmap imgCash;
    Rectangle location;
    ArrayList source;
    double minY, maxY;
    int minX, maxX;
    bool showAll;

    struct PlotLocation{
        public int left, right;
        public double top, bottom;
    }; PlotLocation inView;

	public LBPlot(Graphics Dest, Rectangle Location)
	{
        if (Dest == null) return;
        source = new ArrayList(1);
        dDest = Dest;
        location = Location;
        imgCash = new Bitmap(location.Width, location.Height);
        Dest.DrawImage(imgCash, location.Left, location.Top);
        minX = 0;
        maxX = 0;
        showAll = true;
	}
    /*public void AddData(ICollection Data, DataHash GetCalc, DataLabel GetLabel)
    {
        if (Data == null) return;
        if (GetCalc == null) return;
        if (GetLabel == null) return;
        LBData next = new LBData();
    }*/
    public void AddData(ICollection Data)
    {
        if (Data == null) return;
        source.Add(Data);
        double min;
        double max;
        GetDataRange(source.Count - 1, out min, out max);
        if (min < minY) minY = min;
        if (max > maxY) maxY = max;
        if (Data.Count > maxX) maxX = Data.Count;
        if (showAll)
        {
            inView.top = max;
            inView.bottom = min;
        }
       
    }
    public void ReplaceData(ICollection Data, int position)
    {
        if (Data == null) return;
        if (position >= source.Count) return;
        source.RemoveAt(position);
        source.Insert(position,Data);
        double min;
        double max;
        GetDataRange(source.Count - 1, out min, out max);
        if (min < minY) minY = min;
        if (max > maxY) maxY = max;
        if (Data.Count > maxX) maxX = Data.Count;
        if (showAll)
        {
            inView.top = max;
            inView.bottom = min;
        }
    }
    public void GetDataRange(int index, out double min, out double max)
    {
        IEnumerator Enum = ((ICollection)source[index]).GetEnumerator();
        Enum.MoveNext();
        double Max = (double)Convert.ChangeType(Enum.Current, typeof(double));
        double Min = Max;
        int pos = ((ICollection)source[index]).Count - 1;
        while (pos > 0)
        {
            Enum.MoveNext();
            pos--;
            double current = (double)Convert.ChangeType(Enum.Current, typeof(double));
            if (Min > current) Min = current;
            if (Max < current) Max = current;
        }
        min = Min;
        max = Max;
    }
    public void DrawData(int index = -1)
    {
        if (index == -1)
        {
            Graphics.FromImage(imgCash).Clear(Color.White);
            for (int i = 0; i < Count; i++)
            {
                DrawData(i);
            }
        }
        else
        {
            Graphics graph = Graphics.FromImage(imgCash);
            ICollection Data = (ICollection)source[index];
            IEnumerator Enum = Data.GetEnumerator();
            Enum.MoveNext();
           /* if (showAll)
            {
                inView.left = this.minX;
                inView.right = this.maxX;
                inView.top = this.maxY;
                inView.bottom = this.minY;
            }*/
            if (inView.top - inView.bottom == 0)
            {
                inView.top = this.maxY+1;
                inView.bottom = this.minY-1;
            }
            int minX = inView.left;
            int maxX = inView.right;
            double maxY = inView.top;
            double minY = inView.bottom;
            if (showAll)
            {
                minX = this.minX;
                maxX = this.maxX;
                minY = this.minY;
                maxY = this.maxY;
            }
            else
            {
                minX = inView.left;
                maxX = inView.right;
                maxY = inView.top;
                minY = inView.bottom;
            }
            if (ShowRange)
            {
                double l = inView.left*((double)location.Width) / (maxX - minX - 1);
                double r = inView.right * ((double)location.Width) / (maxX - minX - 1);
                double t = 0.01 * location.Height + 0.98 * location.Height * ((maxY -inView.top) / (maxY - minY));
                double b = 0.01 * location.Height + 0.98 * location.Height * ((maxY - inView.bottom) / (maxY - minY));
                graph.DrawRectangle(Pens.Red, (float)l, (float)t, (float)(r - l), (float)(b-t));
            }
            double x1 = 0;
            double y1 = 0.01*location.Height+0.98*location.Height * ((maxY - (double)Convert.ChangeType(Enum.Current, typeof(double))) / (maxY - minY));
            
            Font fnt = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float der = 1;
            for (int i = minX + 1; (i < maxX)&(i<Data.Count); i++)
            {   
                if (ShowText)
                {
                    if (der!=0)
                    graph.DrawString(Math.Round(((float)Convert.ChangeType(Enum.Current, typeof(float))),3).ToString(), fnt, drawBrush, (float)x1, 0.99f * location.Height -12-12*(i%2)/*(float)y1+der*12*/);
                }
                Enum.MoveNext();
                double y2 = 0.01*location.Height+0.98*location.Height * ((maxY - (double)Convert.ChangeType(Enum.Current, typeof(double))) / (maxY - minY));
                double x2 = x1 + ((double)location.Width) / (maxX - minX - 1);
                if (i>minX)
                graph.DrawLine(Pens.Green, (float)x1, (float)y1, (float)x2, (float)y2);
                
                der = Math.Sign(y1 - y2);
                x1 = x2;
                y1 = y2;
                
            }
            if (!ShowText)
            {
                graph.DrawString(maxY.ToString(), fnt, drawBrush, 1f, 0.01f * location.Height);
                graph.DrawString(minY.ToString(), fnt, drawBrush, 1f, 0.99f * location.Height - 12);
            }
            
           /* double y = 0.01 * location.Height + 0.98 * location.Height * ((maxY) / (maxY - minY));
            graph.DrawLine(Pens.Red, 0f, (float)y, location.Width, (float)y);*/
            dDest.DrawImage(imgCash, location.Left, location.Top);
        }
    }
    public void SelectView(int left, int right)
    {
        showAll = false;
        inView.left = left;
        inView.right = right;
        inView.top = maxY;
        inView.bottom = minY;
    }
    public void SelectView(int left, int right, double top, double bottom)
    {
        showAll = false;
        inView.left = left;
        inView.right = right;
        inView.top = top;
        inView.bottom = bottom;
    }
    public void FreeView()
    {
        showAll = true;
    }
    public void Clear()
    {
        minX = 0;
        maxX = 0;
        showAll = true;
        source.Clear();
    }
    public void Resize(Rectangle Location)
    {
        location = Location;
        imgCash = new Bitmap(location.Width, location.Height);
        dDest.DrawImage(imgCash, location.Left, location.Top);
    }
    public void Restore(Graphics Dest)
    {
        if (Dest == null) return;
        dDest = Dest;
        Dest.DrawImage(imgCash, location.Left, location.Top);
    }
    public int Count { get { return source.Count; } }

    public static void DrawPlot(double[] Data, Bitmap BMP, bool NeedText = true)
    {
        Graphics graph = Graphics.FromImage(BMP);
        double Max = 0;
        double[] ToDraw = new double[Data.Length];
        foreach (double Source in Data)
        {
            if (Math.Abs(Source) > Max) Max = Math.Abs(Source);
        }
        for (int i = 0; i < Data.Length; i++)
        {
            double tmp = (double)Convert.ChangeType(Data[i], typeof(double));
            if (Math.Abs(tmp) > Max) Max = Math.Abs(tmp);
            ToDraw[i] = tmp;
        }
        if (NeedText)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            graph.DrawString(Convert.ToString(Max), drawFont, drawBrush, new PointF(10f, 10f));
        }
        double Y1 = (double)BMP.Height  * (1d - (double)ToDraw[0] / Max);
        double DX = (double)BMP.Width / ToDraw.Length;
        for (int i = 1; i < ToDraw.Length; i++)
        {
            double Y2 = (double)BMP.Height * (1d - (double)ToDraw[i] / Max);
            graph.DrawLine(Pens.Red, (float)((i - 1) * DX), (float)Y1*0.9f, (float)(i * DX), (float)Y2*0.9f);
            Y1 = Y2;
        }
    }
    public bool ShowText { get; set; }
    public bool ShowRange { get; set; }
}

