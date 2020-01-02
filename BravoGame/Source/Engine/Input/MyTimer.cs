using System;
using System.Xml.Linq;

namespace BravoGame
{
    public class MyTimer
    {
        public bool GoodToGo;
        protected TimeSpan timer = new TimeSpan();
        
        public MyTimer(int miliSeconds)
        {
            GoodToGo = false;
            MiliSec = miliSeconds;
        }

        public MyTimer(int miliSeconds, bool startloaded)
        {
            GoodToGo = startloaded;
            MiliSec = miliSeconds;
        }

        public int MiliSec { get; set; }

        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer()
        {
            timer += Globals.GameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float speed)
        {
            timer += TimeSpan.FromTicks((long)(Globals.GameTime.ElapsedGameTime.Ticks * speed));
        }

        public virtual void AddToTimer(int msec)
        {
            timer += TimeSpan.FromMilliseconds(msec);
        }

        public bool Test()
        {
            if(timer.TotalMilliseconds >= MiliSec || GoodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, MiliSec / 60000, MiliSec / 1000, MiliSec % 1000));
            if(timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            GoodToGo = false;
        }

        public void Reset(int newtimer)
        {
            timer = TimeSpan.Zero;
            MiliSec = newtimer;
            GoodToGo = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            GoodToGo = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml= new XElement("Timer",
                                    new XElement("mSec", MiliSec),
                                    new XElement("timer", Timer));

            return xml;
        }

        public void SetTimer(TimeSpan time)
        {
            timer = time;
        }

        public virtual void SetTimer(int msec)
        {
            timer = TimeSpan.FromMilliseconds(msec);
        }
    }
}
