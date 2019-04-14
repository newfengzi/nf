using System;
namespace QQWinFarm
{
    /// <summary> 
    /// yzm 的摘要说明。 
    /// </summary> 
    public class Verify
    {
        public Verify(System.Drawing.Bitmap pic)
        {
            this.bp = pic;
        }
        /// <summary> 
        /// 将一个int值存入到4个字节的字节数组(从高地址开始转换，最高地址的值以无符号整型参与"与运算") 
        /// </summary> 
        /// <param name="thevalue">要处理的int值</param> 
        /// <param name="thebuff">存放信息的字符数组</param> 
        public static void getbytesfromint(int thevalue, byte[] thebuff)
        {
            long v1 = 0; long v2 = 0; long v3 = 0; long v4 = 0;
            uint b1 = (uint)4278190080; uint b2 = (uint)16711680; uint b3 = (uint)65280; uint b4 = (uint)255;
            v1 = thevalue & b1;
            v2 = thevalue & b2;
            v3 = thevalue & b3;
            v4 = thevalue & b4;
            thebuff[0] = (byte)(v1 >> 24);
            thebuff[1] = (byte)(v2 >> 16);
            thebuff[2] = (byte)(v3 >> 8);
            thebuff[3] = (byte)v4;
        }
        /// <summary> 
        /// 将一个ushort值存入到2个字节的字节数组(从高地址开始转换，最高地址的值以无符号整型参与"与运算") 
        /// </summary> 
        /// <param name="thevalue">要处理的ushort值</param> 
        /// <param name="thebuff">存放信息的字符数组</param> 
        public static void getbytesfromushort(ushort thevalue, byte[] thebuff)
        {
            ushort v1 = 0; ushort v2 = 0;
            ushort b1 = (ushort)65280; ushort b2 = (ushort)255;
            v1 = (ushort)(thevalue & b1);
            v2 = (ushort)(thevalue & b2);
            thebuff[0] = (byte)(v1 >> 8);
            thebuff[1] = (byte)(v2);
        }
        /// <summary> 
        /// 将4个字节的字节数组转换成一个int值 
        /// </summary> 
        /// <param name="thebuff">字符数组</param> 
        /// <returns></returns> 
        public static int getintfrombyte(byte[] thebuff)
        {
            int jieguo = 0;
            long mid = 0;
            long m1 = 0; long m2 = 0; long m3 = 0; long m4 = 0;
            m1 = (thebuff[0] << 24);
            m2 = (thebuff[1] << 16);
            m3 = (thebuff[2] << 8);
            m4 = thebuff[3];
            mid = m1 + m2 + m3 + m4;
            jieguo = (int)mid;
            return jieguo;
        }
        /// <summary> 
        /// 将2个字节的字节数组转换成一个ushort值 
        /// </summary> 
        /// <param name="thebuff">字符数组</param> 
        /// <returns></returns> 
        public static ushort getushortfrombyte(byte[] thebuff)
        {
            int jieguo1 = 0;
            jieguo1 = (thebuff[0] << 8) + thebuff[1];
            ushort jieguo = (ushort)jieguo1;
            return jieguo;
        }
        /// <summary> 
        /// 将内存中的数据写入硬盘（保存特征库） 
        /// </summary> 
        /// <param name="thefile">保存的位置</param> 
        public static void writetofile(string thefile)
        {
            System.IO.FileStream fs = new System.IO.FileStream(thefile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
            byte[] buff0 = new byte[4];
            getbytesfromint(datanum, buff0);
            fs.Write(buff0, 0, 4);
            for (int ii = 0; ii < datanum; ii++)
            {
                for (int jj = 0; jj < 20; jj++)
                {
                    byte[] buff = new byte[2];
                    getbytesfromushort(datap[ii, jj], buff);
                    fs.Write(buff, 0, 2);
                }
                fs.WriteByte(dataxy[ii, 0]);
                fs.WriteByte(dataxy[ii, 1]);
                fs.WriteByte(datachar[ii]);
            }
            fs.Close();
        }
        /// <summary> 
        /// 从文件中读取信息，并保存在内存中相应的位置 
        /// </summary> 
        /// <param name="thefile">特征库文件</param> 
        public static void readfromfile(string thefile)
        {
            int allnum = 0;
            byte[] buff = new byte[4];
            System.IO.FileStream fs = new System.IO.FileStream(thefile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            fs.Read(buff, 0, 4);
            allnum = getintfrombyte(buff);
            byte[] buff0 = new byte[2];
            for (int ii = 0; ii < allnum; ii++)
            {
                for (int jj = 0; jj < 20; jj++)
                {
                    fs.Read(buff0, 0, 2);
                    datap[ii, jj] = getushortfrombyte(buff0);
                }
                fs.Read(buff0, 0, 1);
                dataxy[ii, 0] = buff0[0];
                fs.Read(buff0, 0, 1);
                dataxy[ii, 1] = buff0[0];
                fs.Read(buff0, 0, 1);
                datachar[ii] = buff0[0];
            }
            datanum = allnum;
            fs.Close();
        }
        /// <summary> 
        /// 验证码图片 
        /// </summary> 
        public System.Drawing.Bitmap bp = new System.Drawing.Bitmap(49, 20);
        /// <summary> 
        /// 特征库的长度 
        /// </summary> 
        public static int datanum = 0;
        /// <summary> 
        /// 特征库数据 
        /// </summary> 
        public static ushort[,] datap = new ushort[100000, 20];
        /// <summary> 
        /// 长度与高度 
        /// </summary> 
        public static byte[,] dataxy = new byte[100000, 2];
        /// <summary> 
        /// 对应的字符 
        /// </summary> 
        public static byte[] datachar = new byte[100000];
        /// <summary> 
        /// 等待处理的数据 
        /// </summary> 
        public ushort[] datapic = new ushort[20];
        /// <summary> 
        /// 有效长度 
        /// </summary> 
        public byte xlpic = 0;
        /// <summary> 
        /// 有效宽度 
        /// </summary> 
        public byte ylpic = 0;
        /// <summary> 
        /// 检索特征库中存在的记录 
        /// </summary> 
        public string getchar()
        {
            //如果查找不到，就返回空串 
            string jieguo = "";
            for (int ii = 0; ii < datanum; ii++)
            {
                //统计一共有多少行的像素有差异，如果在4行以内就认为是存在该记录 
                //这种方法比较原始，但比较适合多线程时的运行，因为程序只进行简单的逻辑比较 
                //如果能够收集更多的特征库，识别率可以达到80％以上 
                //（此时可能需要将特征库的容量提高到15W个或以上） 
                //当然也可以改进品配算法（如使用关键点品配），以用较少的特征库达到较高的识别率，但 
                //那样有比较大的机会造成识别错误并且多线程时占用较多CPU时间。 
                int notsamenum = 0;
                if (dataxy[ii, 0] != xlpic || dataxy[ii, 1] != ylpic)
                {
                    continue;
                }
                for (int jj = 0; jj < 20; jj++)
                {
                    if (datap[ii, jj] != datapic[jj])
                    {
                        notsamenum++;
                    }
                }
                if (notsamenum < 4)
                {
                    char cj = (char)datachar[ii];
                    return cj.ToString();
                }
            }
            return jieguo;
        }
        /// <summary> 
        /// 检查特征库中是否已经存在相关记录 
        /// </summary> 
        bool ischardatain()
        {
            bool jieguo = false;
            for (int ii = 0; ii < datanum; ii++)
            {
                //统计一共有多少行的像素有差异，如果在4行以内就认为是存在该记录 
                //这种方法比较原始，但比较适合多线程时的运行，因为程序只进行简单的逻辑比较 
                //如果能够收集更多的特征库，识别率可以达到80％以上 
                //（此时可能需要将特征库的容量提高到15W个或以上） 
                //当然也可以改进品配算法（如使用关键点品配），以用较少的特征库达到较高的识别率，但 
                //那样有比较大的机会造成识别错误并且多线程时占用较多CPU时间。 
                int notsamenum = 0;
                if (System.Math.Abs(dataxy[ii, 0] - xlpic) > 1 || System.Math.Abs(dataxy[ii, 1] - ylpic) > 1)
                {
                    continue;
                }
                for (int jj = 0; jj < 20; jj++)
                {
                    if (datap[ii, jj] != datapic[jj])
                    {
                        notsamenum++;
                    }
                }
                if (notsamenum < 4)
                {
                    string asdasd = ((char)datachar[ii]).ToString();

                    return true;
                }
            }
            return jieguo;
        }
        /// <summary> 
        /// 添加到特征库中，并暂时将对应的字符置为空格以待人工识别 
        /// </summary> 
        void adddatawithnullchar()
        {
            if (this.ischardatain())
            {
                return;
            }
            for (int ii = 0; ii < 20; ii++)
            {
                datap[datanum, ii] = this.datapic[ii];
            }
            //暂时将对应的字符置为空格以待人工识别 
            datachar[datanum] = 32;
            dataxy[datanum, 0] = this.xlpic;
            dataxy[datanum, 1] = this.ylpic;
            datanum++;
        }
        /// <summary> 
        /// 检查验证码图片是否能分成4个部分，如果可以就检查4个字符在特征库中是否已经存在，如果不存在， 
        /// 就添加到特征库中，并暂时将对应的字符置为空格以待人工识别 
        /// </summary> 
        public void writetodata()
        {
            bool[,] picpixel = new bool[bp.Width, bp.Height];
            for (int ii = 0; ii < bp.Width; ii++)
            {
                for (int jj = 0; jj < bp.Height; jj++)
                {
                    System.Drawing.Color asd = System.Drawing.Color.FromArgb(200,200,200);
                    System.Drawing.Color asd1 = System.Drawing.Color.FromArgb(211, 60,7);
                    // bp.GetPixel(ii, jj);
                    float asd2, asd3;
                    asd2 = asd.GetBrightness();
                    asd3 = asd1.GetBrightness();
                    //float asd1 = asd.GetBrightness();
                    float asd4 = bp.GetPixel(ii, jj).GetBrightness();
                    if (asd4 < asd2)//bp.GetPixel(ii, jj).GetBrightness() < System.Drawing.Color.FromArgb(207, 255, 255).GetBrightness())
                    {
                        bp.SetPixel(ii, jj, System.Drawing.Color.FromArgb(0, 0, 0));
                        //if(asd4<asd2)
                        picpixel[ii, jj] = true;
                    }
                    else
                    {
                        bp.SetPixel(ii, jj, System.Drawing.Color.FromArgb(255, 255, 255));
                        picpixel[ii, jj] = false;
                    }
                }
            }
            return;
            
            int[] index = new int[8];
            int indexnum = 0;
            bool black = false;
            for (int ii = 0; ii < bp.Width; ii++)
            {
                bool haveblack = false;
                for (int jj = 0; jj < bp.Height; jj++)
                {
                    if (picpixel[ii, jj])
                    {
                        haveblack = true;
                        break;
                    }
                }
                if (haveblack && black == false)
                {
                    index[indexnum] = ii;
                    indexnum++;
                    black = true;
                }
                if (!haveblack && black)
                {
                    index[indexnum] = ii;
                    indexnum++;
                    black = false;
                }
            }
            if (indexnum < 7)
            {
                return;
            }
            if (indexnum == 7)
            {
                index[7] = 49;
            }
            //**** 
            for (int ii = 0; ii < 4; ii++)
            {
                int x1 = index[ii * 2];
                int x2 = index[ii * 2 + 1];
                int y1 = 0, y2 = 19;
                bool mb = false;
                for (int jj = 0; jj < 20; jj++)
                {
                    for (int kk = x1; kk < x2; kk++)
                    {
                        if (picpixel[kk, jj])
                        {
                            mb = true;
                            break;
                        }
                    }
                    if (mb)
                    {
                        y1 = jj;
                        break;
                    }
                }
                mb = false;
                for (int jj = 19; jj >= 0; jj--)
                {
                    for (int kk = x1; kk < x2; kk++)
                    {
                        if (picpixel[kk, jj])
                        {
                            mb = true;
                            break;
                        }
                    }
                    if (mb)
                    {
                        y2 = jj;
                        break;
                    }
                }
                //**以上是获取有效区域的范围 
                for (int jj = 0; jj < 20; jj++)
                {
                    this.datapic[jj] = 0;
                    this.datapic[jj] = 0;
                }
                this.xlpic = (byte)(x2 - x1);
                //如果字符宽度超过16个像素就不予处理 
                if (xlpic > 16)
                {
                    continue;
                }
                this.ylpic = (byte)(y2 - y1 + 1);
                int ys = -1;
                ushort[] addin = new ushort[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768 };
                for (int jj = y1; jj <= y2; jj++)
                {
                    ys++;
                    int xs = -1;
                    for (int kk = x1; kk < x2; kk++)
                    {
                        xs++;
                        if (picpixel[kk, jj])
                        {
                            this.datapic[ys] = (ushort)(this.datapic[ys] + addin[xs]);
                        }
                    }
                }
                this.adddatawithnullchar();
            }
            //**** 
        }
        /// <summary> 
        /// 识别图片 
        /// </summary> 
        /// <returns>返回识别结果(如果返回的字符串长度小于4就说明识别失败)</returns> 
        public string ocrpic()
        {
            string jieguo = "";
            bool[,] picpixel = new bool[49, 20];
            for (int ii = 0; ii < 49; ii++)
            {
                for (int jj = 0; jj < 20; jj++)
                {
                    if (bp.GetPixel(ii, jj).GetBrightness() < 0.999)
                    {
                        picpixel[ii, jj] = true;
                    }
                }
            }
            int[] index = new int[8];
            int indexnum = 0;
            bool black = false;
            for (int ii = 0; ii < 49; ii++)
            {
                bool haveblack = false;
                for (int jj = 0; jj < 20; jj++)
                {
                    if (picpixel[ii, jj])
                    {
                        haveblack = true;
                        break;
                    }
                }
                if (haveblack && black == false)
                {
                    index[indexnum] = ii;
                    indexnum++;
                    black = true;
                }
                if (!haveblack && black)
                {
                    index[indexnum] = ii;
                    indexnum++;
                    black = false;
                }
            }
            if (indexnum < 7)
            {
                return jieguo;
            }
            if (indexnum == 7)
            {
                index[7] = 49;
            }
            //**** 
            for (int ii = 0; ii < 4; ii++)
            {
                int x1 = index[ii * 2];
                int x2 = index[ii * 2 + 1];
                int y1 = 0, y2 = 19;
                bool mb = false;
                for (int jj = 0; jj < 20; jj++)
                {
                    for (int kk = x1; kk < x2; kk++)
                    {
                        if (picpixel[kk, jj])
                        {
                            mb = true;
                            break;
                        }
                    }
                    if (mb)
                    {
                        y1 = jj;
                        break;
                    }
                }
                mb = false;
                for (int jj = 19; jj >= 0; jj--)
                {
                    for (int kk = x1; kk < x2; kk++)
                    {
                        if (picpixel[kk, jj])
                        {
                            mb = true;
                            break;
                        }
                    }
                    if (mb)
                    {
                        y2 = jj;
                        break;
                    }
                }
                //**以上是获取有效区域的范围 
                for (int jj = 0; jj < 20; jj++)
                {
                    this.datapic[jj] = 0;
                    this.datapic[jj] = 0;
                }
                this.xlpic = (byte)(x2 - x1);
                //如果字符宽度超过16个像素就不予处理 
                if (xlpic > 16)
                {
                    continue;
                }
                this.ylpic = (byte)(y2 - y1 + 1);
                int ys = -1;
                ushort[] addin = new ushort[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768 };
                for (int jj = y1; jj <= y2; jj++)
                {
                    ys++;
                    int xs = -1;
                    for (int kk = x1; kk < x2; kk++)
                    {
                        xs++;
                        if (picpixel[kk, jj])
                        {
                            this.datapic[ys] = (ushort)(this.datapic[ys] + addin[xs]);
                        }
                    }
                }
                jieguo = jieguo + this.getchar();
            }
            return jieguo;
        }
    }
}