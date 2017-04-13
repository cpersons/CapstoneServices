using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TylerEfLibrary
{
    public class ScheduledEvents
    {
        private static Timer emailReminderTimer;
        public static void setUpmailReminders()
        {
            sendUpdates();
            emailReminderTimer = new System.Timers.Timer(86400000);
            emailReminderTimer.Elapsed += emailTimedEvent;
            emailReminderTimer.Enabled = true;

        }

       
        private static void emailTimedEvent(object source, ElapsedEventArgs e)
        {
            sendUpdates();
            emailReminderTimer = new System.Timers.Timer(86400000);
            emailReminderTimer.Enabled = true;
        }

        private static void sendUpdates() {
            //Send email reminders for reminders due today

        }
    }

 }
       
