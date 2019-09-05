using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Overload;
using Harmony;
using UnityEngine;
using Random = System.Random;



namespace Mod_ReplaceMenuMusic
{
    class Main
    {
    }
  

    [HarmonyPatch(typeof(GameplayManager), "LoadLevel")]
    public class OnLevelLoad
    {
        public static void Postfix()
        {
            if (Control.mod_active)
            {
                //GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
                RMMTimer.TimerStop();

            }
        }
    }


    [HarmonyPatch(typeof(Player), "ExitMultiplayerToMainMenu")]
    public class MpToMenu
    {
        public static void Postfix()
        {
            if(Control.mod_active)
            {
                //GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
                Methods.SwitchToNextSong();
             
            }
        }
    }

    // adds the button
    [HarmonyPatch(typeof(UIElement), "DrawMainMenu")]
    internal class DrawMainMenu
    {
        public static void Postfix(UIElement __instance)
        {
            if (Control.mod_active)
            {
                Vector2 position = __instance.m_position;
                position.y = 235;
                position.x = -500;
                __instance.SelectAndDrawHalfItem("NEXT MUSIC TRACK", position, 25, false);

            }
        }
    }

    // adds the track change button logic
    [HarmonyPatch(typeof(MenuManager), "MainMenuUpdate")]
    internal class MainMenuUpdate
    {
        public static void Postfix()
        {
            if (Control.mod_active)
            {
                if (MenuManager.m_menu_sub_state == MenuSubState.ACTIVE)
                {
                    if (!Control.is_Music_Playing && Platform.IsSaveDataLoaded)
                    {
                       
                        Methods.StartPlayingMenuMusic();
                        
                        Control.is_Music_Playing = true;
                    }

                    if (UIManager.PushedSelect(-1))
                    {
                        if (UIManager.m_menu_selection == 25)
                        {                      
                            Methods.SwitchToNextSong();
                        }
                    }
                }
            }
        }
    }



    [HarmonyPatch(typeof(UnityAudio), "PlayMusic")]
    internal class PreventMenuMusic
    {
        public static bool Prefix(string track)
        {
            if (Control.mod_active)
            {
                if(track.Equals("MENU_01"))
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }

   



    
    [HarmonyPatch(typeof(UnityAudio), "UpdateAudio")]
    internal class CheckTime
    {
        public static void Postfix()
        {
            if (Control.mod_active)
            {
                //we need flags and stuff to ensure that it doesnt try to start a song while playing
              //  Methods.CompareTime();
              //currently very broken
            }
        }
    }
    

}


/*
 * class REEEEE : MonoBehaviour
    {
        AudioClip audio = (AudioClip)Resources.Load("Music/overload_" + Control.OverloadAudioNames[Control.current_song_int]);

        void Start()
        {
            Control.current_song_int = RandomNumber(0, Control.OverloadAudioNames.Length - 1);
            GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
            uConsole.Log("[MENU-SONG] Now playing: " + Control.OverloadAudioNames[Control.current_song_int]);
            Invoke("SwitchToNextTrack", audio.length);
        }

        void SwitchToNextTrack()
        {
            Control.current_song_int = NextSongNumber();
            audio = (AudioClip)Resources.Load("Music/overload_" + Control.OverloadAudioNames[Control.current_song_int]);
            GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
            uConsole.Log("[MENU-SONG] Now playing: " + Control.OverloadAudioNames[Control.current_song_int]);
            Invoke("SwitchToNextTrack", audio.length);
        }

        private static int NextSongNumber()
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



    }*/
