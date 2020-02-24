using System.Collections;
using UnityEngine;
public class MusicManager : MonoBehaviour
{
    public AudioClip[] tracks;

    private static MusicManager instance;
    private static AudioClip[] staticTracks;
	private static AudioSource player;
	
	void Start ()
    {
		player = GetComponent<AudioSource>();
        instance = GetComponent<MusicManager>();
        staticTracks = tracks;

        //TODO Set start music volume from player prefs.
    }
	
	public static void PlayMusic (int track, bool loop)
    {
		AudioClip thisLevelMusic = staticTracks[track];
		if (thisLevelMusic)
        {
			player.clip = thisLevelMusic;

            if (loop)
            {
                player.loop = true;
            } 
            else
            {
                player.loop = false;
            }
            player.Play();
		}
	}

    public static void CallFadeMusicIn ()
    {
        instance.StartCoroutine(FadeMusicIn());
    }

    private static IEnumerator FadeMusicIn ()
    {
        //float targetVolume = PlayerPrefsManager.GetMasterMusicVolume();
        //float fadeTime = .5f;

        //while (player.volume < targetVolume)
        //{
        //    player.volume += (targetVolume / fadeTime) * Time.deltaTime;
            yield return null;
        //}
    }

    public static void CallFadeMusicOut()
    {
        instance.StartCoroutine(FadeMusicOut());
    }

    private static IEnumerator FadeMusicOut()
    {
        float initialVolume = player.volume;
        float fadeTime = .75f;

        while (player.volume > 0)
        {
            player.volume -= (initialVolume / fadeTime) * Time.deltaTime;
            yield return null;
        }
    }

    //public static void FadeMusicIn ()
    //{
    //    float currentVolume = PlayerPrefsManager.GetMasterMusicVolume();
    //    float fadeTime = .5f;
    //    bool fadeIn = true;

    //    if (fadeIn)
    //    {
    //        player.volume += (currentVolume / fadeTime) * Time.deltaTime;
    //    }

    //    if (player.volume >= currentVolume)
    //    {
    //        player.volume = currentVolume;
    //        fadeIn = false;
    //    }
    //}

    //public static void FadeMusicOut()
    //{
    //    float currentVolume = PlayerPrefsManager.GetMasterMusicVolume();
    //    float fadeOutTime = .75f;
    //    bool fadeOut = true;

    //    if (fadeOut)
    //    {
    //        player.volume -= (currentVolume / fadeOutTime) * Time.deltaTime;
    //    }

    //    if (player.volume <= 0)
    //    {
    //        fadeOut = false;
    //    }
    //}
	
	public static void ChangeVolume (float volume)
    {
		player.volume = volume;
	}
}