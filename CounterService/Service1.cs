using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace KopitekCounter
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer _timer;
        public Service1()
        {
            try
            {
                InitializeComponent();
                int timerinterval = 28800000;
                _timer = new System.Timers.Timer();
                _timer.Interval = timerinterval;
                _timer.Elapsed += timer_Elapsed;
                _timer.AutoReset = false;
                DoWork();
            }

            catch(Exception ex)
            {
                var logger = new Logger();
                logger.ErrorLog(ex.ToString());
            }
        }

        private void DoWork()
        {
            try
            {
                var registry = new Registry();
                var counter = new Counter();
                var api = new Api();
                string line;
                var path = registry.GetRecord("Path");
                var customerId = registry.GetRecord("CustomerId");
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                var control = new Control();

                while ((line = file.ReadLine()) != null)
                {
                    if (control.ipcontrol(line))
                    {
                        control.status(line);
                        var counterRecieved = counter.GetCounter(line);
                        if (counterRecieved != null)
                        {
                            counterRecieved.CustomerId = Int32.Parse(customerId);
                            api.PostCounter(counterRecieved);
                        }
                    }

                }
            }

            catch(Exception ex)
            {
                var logger = new Logger();
                logger.ErrorLog(ex.ToString());
            }

            finally
            {
                _timer.Start();
            }
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           DoWork();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }
    }
}
