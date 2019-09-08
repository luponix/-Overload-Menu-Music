
using System.Timers;
using UnityEngine;

namespace Mod_ReplaceMenuMusic
{
   public static class RMMTimer
    {
        
        static Timer _timer;
       
        // succesfully mined with Logs

        public static void Start()
        {
            uConsole.Log("[RMM] Timer .Start(2)");
            Debug.Log("[RMM] Timer .Start(2)");
            // Set up the timer for 3 seconds.
            var timer = new Timer(2000);
            // To add the elapsed event handler:
            // ... Type "_timer.Elapsed += " and press tab twice.
            timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            timer.Enabled = true;
            _timer = timer;
            uConsole.Log("[RMM] Timer .Start(DONE)");
            Debug.Log("[RMM] Timer .Start(DONE)");

        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           
            Debug.Log("[RMM] Timer .OnEvent(2)");
            Control.current_song_pointer += 2;
            //uConsole.Log("song time: "+Control.current_song_pointer); 
            if(Control.current_song_pointer > Control.current_song_length)
            {
                TimerStop();
                uConsole.Log("[RMM] Timer .OnEvent(3)");
                Debug.Log("[RMM] Timer .OnEvent(3)");
                RMMMethods.SwitchToNextSong();
                uConsole.Log("[RMM] Timer .OnEvent(DONE)");
                Debug.Log("[RMM] Timer .OnEvent(DONE)");
            }
        }

        public static void TimerStop()
        {
            uConsole.Log("[RMM] Timer .TimerStop(1)");
            Debug.Log("[RMM] Timer .TimerStop(1)");
            _timer.Stop();

            Control.current_song_pointer = 0;
            uConsole.Log("[RMM] Timer .TimerStop(DONE)");
            Debug.Log("[RMM] Timer .TimerStop(DONE)");
        }


       
    }
}