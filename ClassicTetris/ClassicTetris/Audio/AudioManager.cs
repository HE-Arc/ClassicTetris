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
			soundEffects[SFX.BlockRotate] = content.Load<SoundEffect>("Audio/SFX/block-rotate");
			soundEffects[SFX.ForceHit] = content.Load<SoundEffect>("Audio/SFX/force-hit");
			soundEffects[SFX.GameOver] = content.Load<SoundEffect>("Audio/SFX/gameover");
			soundEffects[SFX.LineDrop] = content.Load<SoundEffect>("Audio/SFX/line-drop");
			soundEffects[SFX.LineRemoval4] = content.Load<SoundEffect>("Audio/SFX/line-removal4");
			soundEffects[SFX.LineRemove] = content.Load<SoundEffect>("Audio/SFX/line-remove");
			soundEffects[SFX.Pause] = content.Load<SoundEffect>("Audio/SFX/pause");
			soundEffects[SFX.Select] = content.Load<SoundEffect>("Audio/SFX/select");
			soundEffects[SFX.SlowHit] = content.Load<SoundEffect>("Audio/SFX/slow-hit");
			soundEffects[SFX.Start] = content.Load<SoundEffect>("Audio/SFX/start");
			soundEffects[SFX.Whoosh] = content.Load<SoundEffect>("Audio/SFX/whoosh");
			songs[Music.Theme1] = content.Load<Song>("Audio/Music/music");
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
