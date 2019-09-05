using System;
using System.Collections.Generic;
using System.Timers;

namespace Mod_ReplaceMenuMusic
{
   public static class RMMTimer
    {
        static Timer _timer;
       
        public static void Start()
        {
            // Set up the timer for 3 seconds.
            var timer = new Timer(1000);
            // To add the elapsed event handler:
            // ... Type "_timer.Elapsed += " and press tab twice.
            timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            timer.Enabled = true;
            _timer = timer;

        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Control.current_song_pointer += 1;
            //uConsole.Log("song time: "+Control.current_song_pointer); 
            if(Control.current_song_pointer >= Control.current_song_length)
            {
                TimerStop();
                Methods.SwitchToNextSong();
            }
        }

        public static void TimerStop()
        {
            _timer.Stop();
            Control.current_song_pointer = 0;
        }


       
    }
}