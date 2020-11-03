using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsSemaphore.Models;

namespace WindowsFormsSemaphore
{
    public partial class FormMain : Form
    {
        object lockObject = new object();
        Semaphore semaphore;
        List<ThreadWrapper> threadWrappersCreated;
        List<ThreadWrapper> threadRunAndWait;
        List<ThreadWrapper> threadWrappersRunning;
        int countThreadWrapper = 0;
        int numInitialThread; 
        public FormMain()
        {
            InitializeComponent();
            numInitialThread = Convert.ToInt32(numInitialCount.Value);
            semaphore = new Semaphore(numInitialThread, 100);
            threadWrappersCreated = new List<ThreadWrapper>();
            lbCreated.DisplayMember = "ThreadName";
            threadWrappersRunning = new List<ThreadWrapper>();
            lbRunning.DisplayMember = "ThreadNameRun";
            threadRunAndWait = new List<ThreadWrapper>();
            lbRunAndWait.DisplayMember = "ThreadNameRun";
        }

        private void btnCreateThread_Click(object sender, EventArgs e)
        {
            countThreadWrapper++;
            ThreadWrapper threadWrapper = new ThreadWrapper($"Thread #{countThreadWrapper}", semaphore);
            lbCreated.Items.Add(threadWrapper);
        }

        private void lbCreated_DoubleClick(object sender, EventArgs e)
        {
            ThreadWrapper wrapper = lbCreated.SelectedItem as ThreadWrapper;
            wrapper.ChangeDisplayName += Wrapper_ChangeDisplayName;
            wrapper.StateRunning += Wrapper_StateRunning;
           
            wrapper.Start();
            lbCreated.Items.Remove(wrapper);
            lbRunAndWait.Items.Add(wrapper);
        }

        
        private void Wrapper_StateRunning(object sender, EventArgs e)
        {
            ThreadWrapper wrapper = sender as ThreadWrapper;
            this?.Invoke(new Action(() =>
            {
                int i = this.lbRunAndWait.Items.IndexOf(wrapper);
                if (i >= 0)
                {
                    lbRunAndWait.Items.Remove(wrapper);
                    lbRunning.Items.Add(wrapper);
                }

            }));
        }

        private void Wrapper_ChangeDisplayName(object sender, EventArgs e)
        {
            ThreadWrapper wrapper = sender as ThreadWrapper;
            this?.Invoke(new Action(() =>
            {
                int i = this.lbRunning.Items.IndexOf(wrapper);
                if (i >= 0)
                    this.lbRunning.Items[i] = wrapper;

            }));
        }

        private void lbRunning_DoubleClick(object sender, EventArgs e)
        {
            ThreadWrapper wrapper = lbRunning.SelectedItem as ThreadWrapper;
            wrapper.Stop(true);
            lbRunning.Items.Remove(wrapper);
        }

        private void numInitialCount_ValueChanged(object sender, EventArgs e)
        {
            var temp = Convert.ToInt32(numInitialCount.Value);
            if (numInitialThread<= temp)
            {
                semaphore.Release(temp- numInitialThread);
            }
            else
            {
                if (lbRunning.Items.Count > temp)
                {

                    ThreadWrapper wrapper = lbRunning.Items[0] as ThreadWrapper;
                    semaphore.WaitOne(0);
                    RemoveRunWrapper(wrapper, false);
                }
            }
            numInitialThread = temp;
        }

        void RemoveRunWrapper(ThreadWrapper wrapper, bool isRelease)
        {
            wrapper.Stop(false);
            lbRunning.Items.Remove(wrapper);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            for (int i = 0; i < lbRunning.Items.Count; i++)
            {
                ThreadWrapper wrapper = lbRunning.Items[i] as ThreadWrapper;
                wrapper.Kill();
            }
        }
    }
}
