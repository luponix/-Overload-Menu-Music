using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overload;
using UnityEngine;
using Random = System.Random;


namespace Mod_ReplaceMenuMusic
{
    class Methods
    {
       
       
        public static void StartPlayingMenuMusic()
        {
            Control.current_song_int = RandomNumber(0, Control.OverloadAudioNames.Length - 1);  

            GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
            GameManager.m_audio.SetNextTrack(Control.OverloadAudioNames[NextSongNumber()]);
            Control.next_song = Control.OverloadAudioNames[NextSongNumber()];
            uConsole.Log("[MENU-SONG] Now playing: " + Control.OverloadAudioNames[Control.current_song_int]);

            AudioClip sc = (AudioClip)Resources.Load("Music/overload_" + Control.OverloadAudioNames[Control.current_song_int]);
            Control.current_song_length = (int)sc.length;
            uConsole.Log("Control.current_song_length : " + Control.current_song_length);

         
            
            RMMTimer.Start();
           
        }

        public static void SwitchToNextSong()
        {
           

            Control.current_song_int = NextSongNumber();         
            GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
            GameManager.m_audio.SetNextTrack(Control.OverloadAudioNames[NextSongNumber()]);
            Control.next_song = Control.OverloadAudioNames[NextSongNumber()];
            uConsole.Log("[MENU-SONG] Now playing: " + Control.OverloadAudioNames[Control.current_song_int]);

            AudioClip sc = (AudioClip)Resources.Load("Music/overload_" + Control.OverloadAudioNames[Control.current_song_int]);
            Control.current_song_length = (int)sc.length;
            uConsole.Log("Control.current_song_length : " + Control.current_song_length);

            RMMTimer.TimerStop();
            RMMTimer.Start();

            


            //TimeSpan t = (DateTime.UtcNow - new DateTime(2018, 1, 1));
            //song_started_at = (int)t.TotalSeconds;



        }
        /*
        public static void CompareTime()
        {
            //this needs to be done
            if(rest_length > 0)
            {
                TimeSpan t = (DateTime.UtcNow - new DateTime(2018, 1, 1));
                rest_length = current_song_length-(song_started_at - (int)t.TotalSeconds);
                uConsole.Log(rest_length.ToString());
            }
            else
            {
                SwitchToNextSong();
            }
            
        }
        */
       

        public static int NextSongNumber()
        {
            if (Control.current_song_int + 1 < Control.OverloadAudioNames.Length)
            {
                return Control.current_song_int + 1;
            }
            else
            {
                return 0;
            }

        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


    }
}
