

namespace Mod_ReplaceMenuMusic
{
    class Control
    {
        public static bool mod_active = true;
        public static bool is_Music_Playing = false;
        public static bool is_Music_Playing2 = true;
        public static string next_song = "";
        public static int current_song_int = 0;
        public static bool should_swap = false;
        public static bool flag = false;
        public static int current_song_length = 0;       
        public static int current_song_pointer = 0;
        public static bool timer_active = false;
        public static bool song_selection_always_random = true;
        //public static UnityAudio m_audio; // try using your own m_audio object


        public static string[] OverloadAudioName1s =
        {
            "EXIT_01",
            "EXIT_02"
        };


        public static string[] OverloadAudioNames =
        {
            "SECRET_01",
            "EXIT_01",
            "BRIEFING_02",
            "TITAN_06",
            "UNUSED_01",
            "TITAN_07",
            "TITAN_10",
            "TITAN_08",
            "BRIEFING_03",
            "ALIEN_BOSS",
            "TRAINING",
            "BRIEFING_01A",
            "ALIEN_13",
            "OUTER_04",
            "INNER_12",
            "INNER_11",
            "OUTER_05",
            "ENDING_B",
            "TITAN_BOSS",
            "ALIEN_15",
            "EXIT_02",
            "BRIEFING_01B",
            "ALIEN_14",
            "INNER_12_SHIP",
            "CREDITS",
            "BRIEFING_04",
            "OUTER_03",
            "ALIEN_16",
            "OUTER_01",
            "ENDING_A",
            "TITAN_09",
            "OUTER_02",
            "OUTER_BOSS"
        };
        



    }
}
