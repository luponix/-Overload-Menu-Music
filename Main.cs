using Overload;
using Harmony;
using UnityEngine;




namespace Mod_ReplaceMenuMusic
{
    

    // we need to prevent the challenge/mission/credit music from playing
    // create a bool
    // set it to false if entering a level
    // prevent unity to play songs while in the main menu
  

    [HarmonyPatch(typeof(GameplayManager), "LoadLevel")]
    public class OnLevelLoad
    {
        public static void Postfix()
        {
           
            if (Control.mod_active)
            {
                //GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
                //RMMMusicHandler.StopPlayingMusic();
                RMMTimer.TimerStop();
                Control.is_Music_Playing2 = false;

            }
        }
    }


    [HarmonyPatch(typeof(Player), "ExitMultiplayerToMainMenu")]
    public class MpToMenu
    {
        public static void Postfix()
        {
           
            if (Control.mod_active)
            {
                // GameManager.m_audio = __instance.GetComponent<UnityAudio>();
                //GameManager.m_audio.PlayMusic(Control.OverloadAudioNames[Control.current_song_int], 0.35f, 0, false, false);
                RMMMethods.SwitchToNextSong();


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
                //add a button to say wether it should randomly select or not
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
                                             
                        RMMMethods.StartPlayingMenuMusic();
                        Control.is_Music_Playing = true;
                    }
                    
                    if (UIManager.PushedSelect(-1))
                    {
                        if (UIManager.m_menu_selection == 25)
                        {
                           RMMMethods.SwitchToNextSong();
                           
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
                    uConsole.Log("[RMM] denied default menu music call");
                    if(!Control.is_Music_Playing2)
                    {
                        uConsole.Log("[RMM] -> started playing ");
                        RMMMethods.StartPlayingMenuMusic();
                        Control.is_Music_Playing2 = true;
                    }
                    return false;
                }
                return true;
            }
            return true;
        }
    }

   
    

}
