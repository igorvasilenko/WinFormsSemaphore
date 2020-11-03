using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSemaphore.Models
{
    public class ThreadWrapper :  NotifyPropertyChanged
    {
        public event EventHandler ChangeDisplayName;
        public event EventHandler StateRunning;
       

        Semaphore semaphore;
        Thread thread; //ThreadState
        bool stop;
       
        string displayName;
        string threadName;
        int secondsCount;
        public string ThreadNameRun
        {
            get => displayName;
            private set
            {
                displayName = value;
                OnPropertyChanged();
            }
        }
        public string ThreadName
        {
            get => threadName;
            private set
            {
                threadName = value;
                OnPropertyChanged();
            }
        }
        public int SecondsCount
        {
            get => secondsCount;
            private set
            {
                secondsCount = value;
                ThreadNameRun = $"{ThreadName} {SecondsCount} сек.";
                OnPropertyChanged();
            }
        }
        public ThreadWrapper(string name, Semaphore semaphore)
        {
            thread = new Thread(Run) { Name = name };
            ThreadName = name;
            ThreadNameRun = $"{ThreadName} {SecondsCount} сек.";
            thread.IsBackground = true;
            this.semaphore = semaphore;
        }

        protected void OnChangeDisplayName()
        {
            var temp = ChangeDisplayName;
            if (temp!=null)
            {
                temp.Invoke(this, null);
            }
        }
        protected void OnStateRunning()
        {
            var temp = StateRunning;
            if (temp != null)
            {
                temp.Invoke(this, null);
            }
        }

        public void Run()
        {
            semaphore.WaitOne();
            OnStateRunning();
            while (!stop)
            {
                Thread.Sleep(1000);
                SecondsCount++;
                OnChangeDisplayName();
            }
        }
        public void Start()
        {
            thread.Start();
        }
        public void Stop(bool isRelease)
        {
            stop = true;
            if (isRelease)
                semaphore.Release();
        }
       
        public void Kill()
        {
            thread.Abort();
        }
    }
}
