using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

using ClassicTetris.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace ClassicTetris.Audio
{
    public class AudioManager
    {
        private static AudioManager Instance = null;

		private static readonly Dictionary<SFX, SoundEffect> soundEffects = new Dictionary<SFX, SoundEffect>();
		private static readonly Dictionary<Music, Song> songs = new Dictionary<Music, Song>();

		public static AudioManager GetInstance()
		{
			if (Instance == null)
				Instance = new AudioManager();
			return Instance;
		}

		private AudioManager()
        {

        }

		public void Load(ContentManager content)
        {
            soundEffects[SFX.HitWall] = content.Load<SoundEffect>("hitwall");
            songs[Music.Theme1] = content.Load<Song>("theme1");
        }
        
		public void Play(SFX sfx)
        {
			soundEffects[sfx].Play();
        }

		public void Play(Music music)
        {
			MediaPlayer.Play(songs[music]);
        }
    }
}
