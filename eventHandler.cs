using System;

delegate void Handler(); // 1 ประกาศ delegate

class Incrementer // publisher
{
    public event Handler CountADozen; // 2  ประกาศ event
    // event CountADozen อยู่โดดเดี่ยวไม่ได้ จะต้องใส่ชื่อของ delegate ด้วย กลายเป็น
    // event Handler CountADozen แต่ยังมองไม่เห็นจากภายนอก ต้องประกาศเป็น public
    // public event Handler CountADozen

    const int length = 100;
    public void DoCount()  // สร้างสถานการณ์ เพื่อที่จะ firing event
    {
        for (int i = 1; i < length; i++)
        {
            if (i % 12 == 0 && CountADozen != null)
            {
                CountADozen(); // firing event เมื่อหารด้วย 12 ลงตัว
            }
        }
    }
}

class Dozens  // subscriber
{
    public int DozenCount { get; private set; }  // property 

    public Dozens(Incrementer incrementer) // ลงทะเบียนเหตุการณ์
    {
        DozenCount = 0;
        incrementer.CountADozen += this.IncrementerDozenCount;
        // ผู้ส่ง.เหตุการณ์ เชื่อมกับ ผู้รับ.เมธอด  
    }

    private void IncrementerDozenCount()  // event handler
    {
        DozenCount++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Incrementer incrementer = new Incrementer();  // สร้าง publisher
        Dozens dozenCounter = new Dozens(incrementer); // สร้าง subscriber โดยระบุ publisher เป็น parameter 
        incrementer.DoCount(); // จำลองสถานการณ์ที่ firing event
        Console.WriteLine("number of dozen = {0}", dozenCounter.DozenCount); // รายงานสรุป
    }
}
