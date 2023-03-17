using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace project2
{
    internal class Clock
    {
        private int time;
        private int alarmTime;
        public delegate void TickLogHandler();
        public delegate void AlarmLogHandler();
        public event TickLogHandler TickLog;
        public event AlarmLogHandler AlarmLog;
        
        public Clock()
        {
            time = 0;
        }

        public void Start()
        {
            for(int i = 0; i < 10; i++)
            {
                Tick();
                Thread.Sleep(1000);
            }
        }
        
        public void Tick()
        {
            time++;
            if (time == alarmTime)
            {
                if(AlarmLog != null)  AlarmLog();
            }
            else
            {
                if(TickLog != null) TickLog();
            }
        }
        
        public void SetAlarm(int time)
        {
            alarmTime = time;
        }

        
        public class SubscribEvent
        {
            public void PrintTick()
            {
                System.Console.WriteLine("Tick");
            }
            
            public void PrintAlarm()
            {
                System.Console.WriteLine("Alarm");
            }
        }
        
        public class Program
        {
            public static void Main(string[] args)
            {
                Clock clock = new Clock();
                SubscribEvent subscribEvent = new SubscribEvent();
                clock.SetAlarm(5);
                clock.TickLog += new Clock.TickLogHandler(subscribEvent.PrintTick);
                clock.AlarmLog += new Clock.AlarmLogHandler(subscribEvent.PrintAlarm);
                clock.Start();
            }
        }
    }
}