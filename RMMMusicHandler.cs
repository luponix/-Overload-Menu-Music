
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Random = System.Random;

namespace Mod_ReplaceMenuMusic
{
    class RMMMusicHandler
    {
        public static bool flag = true;
        public static bool first = true;
        public static string selected_file_path;
        public static string[] filePaths;
        public static string music_folder_path = @"C:\Program Files (x86)\Steam\steamapps\common\Overload\Overload_Menu_Music\";

        /*public static Mp3FileReader mf;
        public static WaveOutEvent wo;

        static Timer _timer;

        public static void PlayTrack()
        {

            while (flag)
            {
                if (first)
                {
                    SelectMusicTrackFromDirectory(true);
                    first = Control.song_selection_always_random;
                    // set a random song
                }
                else
                {
                    SelectMusicTrackFromDirectory(false);
                    // call next song method
                }

                var url = Path.Combine(@"C:\Program Files (x86)\Steam\steamapps\common\Overload\Overload_Menu_Music\", selected_file_path);          //" +   "\"" + selected_file_path + "\"" );
                //play it

                mf = new Mp3FileReader(url);
                wo = new WaveOutEvent();
                {
                    wo.Init(mf);
                    //wo.Volume = 0.35f;
                    wo.Play();
                    //check wether its still running
                    /*while (wo.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                }

                mf.Dispose();
                wo.Dispose();

            }
            uConsole.Log("[RMM] Stopped playing Menu music");

        }

        public static void StopPlayingMusic()
        {
            if (mf != null && wo != null)
            {
                flag = false;
                mf.Dispose();
                wo.Dispose();
            }

        }*/
/*
        public static void SelectMusicTrackFromDirectory(bool random)
        {
           
            if (!Directory.Exists(music_folder_path))
            {
               
                uConsole.Log("[RMM] Menu music folder doesnt exist -> creating directory under C:\\Program Files (x86)\\Steam\\steamapps\\common\\Overload\\Overload_Menu_Music");
                Directory.CreateDirectory(music_folder_path);

            }
            filePaths = Directory.GetFiles(music_folder_path, "*.mp3", SearchOption.TopDirectoryOnly);

            if (random)
            {
                Control.current_song_int = RandomNumber(0, filePaths.Length - 1);
                selected_file_path = filePaths[Control.current_song_int]; //note: filepaths contains the file format already
                uConsole.Log("[RMM] Random first song: "+filePaths[Control.current_song_int]);
                //choose a random number and save it to current_song_int
            }
            else
            {
                NextSongNumber();
                uConsole.Log("[RMM] current track: "+ filePaths[Control.current_song_int]);
                //look at the current_song_int and iterate 
            }
        }

        public static int NextSongNumber()
        {
            
            if (Control.current_song_int + 1 < RMMMusicHandler.filePaths.Length)
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
        */
    }
}
