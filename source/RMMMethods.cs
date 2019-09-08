using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overload;
using UnityEngine;
using Random = System.Random;


namespace Mod_ReplaceMenuMusic
{
    class RMMMethods
    {

        // since you now are outside the unity object range now you have to listen for the overload audio volume

        public static void StartPlayingMenuMusic()
        {
            Control.current_song_int = RandomNumber(0, Control.OverloadAudioNames.Length - 1);
            NextTrack();
            RMMTimer.Start();

        }

        public static void SwitchToNextSong()
        {
            try
            {
                Control.current_song_int = NextSongNumber();
                NextTrack();
                RMMTimer.TimerStop();
                RMMTimer.Start();
            }
            catch(Exception e)
            {
                uConsole.Log("[RMM] ENCOUNTERED ISSUE IN .SwitchToNextSong");
                Debug.Log("[RMM] ENCOUNTERED ISSUE IN .SwitchToNextSong");
                Debug.Log(e);
                Thread.Sleep(2000);
                SwitchToNextSong();
            }
            //MenuManager.audio.MusicVolume
            //MenuManager.audio
            //GameManager.m_game_state
        }


        private static void NextTrack()
        {
            try
            {
                GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, true, false);
                //GameManager.m_audio.SetNextTrack(Control.OverloadAudioNames[Control.current_song_int]);
                //Control.next_song = Control.OverloadAudioNames[NextSongNumber()];
                uConsole.Log("[MENU-SONG] Now playing: " + Control.OverloadAudioNames[Control.current_song_int]);

                AudioClip sc = (AudioClip)Resources.Load("Music/overload_" + Control.OverloadAudioNames[Control.current_song_int]);
                Control.current_song_length = (int)sc.length;
                uConsole.Log("Control.current_song_length : " + Control.current_song_length);
            }
            catch (Exception e)
            {
                uConsole.Log("[RMM] ENCOUNTERED ISSUE IN .NextTrack");
                Debug.Log("[RMM] ENCOUNTERED ISSUE IN .NextTrack");
                Debug.Log(e);
                Thread.Sleep(2000);
                NextTrack();
            }
        }


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