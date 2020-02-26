using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; set; }
	private AudioSource player;
    public List<TrackInformation> overWorldTracks;
    public List<TrackInformation> normalCombatTracks;
    public List<TrackInformation> bossCombatTracks;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
    
    void Start ()
    {
		player = GetComponent<AudioSource>();
    }
	
	public void PlayMusic (AudioClip clip, bool loop)
    {
        player.clip = clip;

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

    //public void CallFadeMusicIn ()
    //{
    //    Instance.StartCoroutine(FadeMusicIn());
    //}

    private IEnumerator FadeMusicIn ()
    {
        float targetVolume = PlayerPrefsManager.Instance.GetMasterMusicVolume();
        float fadeTime = .5f;

        while (player.volume < targetVolume)
        {
            player.volume += (targetVolume / fadeTime) * Time.deltaTime;
            yield return null;
        }
    }

    //public void CallFadeMusicOut()
    //{
    //    Instance.StartCoroutine(FadeMusicOut());
    //}

    private IEnumerator FadeMusicOut()
    {
        float initialVolume = player.volume;
        float fadeTime = .75f;

        while (player.volume > 0)
        {
            player.volume -= (initialVolume / fadeTime) * Time.deltaTime;
            yield return null;
        }
    }
	
	public void ChangeVolume (float volume)
    {
		player.volume = volume;
	}

    public void StartCombatMusic(CombatController.CombatScenario scenario, MasterControl.Location location)
    {
        PlayMusic(DetermineCombatTrack(scenario, location), true);
        StartCoroutine(FadeMusicIn());
    }

    private AudioClip DetermineCombatTrack(CombatController.CombatScenario scenario, MasterControl.Location location)
    {
        TrackInformation track = new TrackInformation();

        if (scenario == CombatController.CombatScenario.Normal)
        {
            track = normalCombatTracks.Find(info => info.location == location);
        }
        else if (scenario == CombatController.CombatScenario.Boss)
        {
            track = bossCombatTracks.Find(info => info.location == location);
        }
        
        return track.clip;
    }
}

[Serializable]
public struct TrackInformation
{
    public MasterControl.Location location;
    public AudioClip clip;
}