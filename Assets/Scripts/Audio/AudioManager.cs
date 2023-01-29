using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    public enum Sound 
    {
        None = 0,
        PlayerMove = 1,
        PlayerRun = 2,
        PlayerDamaged = 3,
        PlayerOnePercent = 4,
        PlayerDied = 5,

        GameRestart = 10,
        MainMenu = 11,
        Background = 12,
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    public static void Initialize()
    { 
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }

    /// <summary>
    /// To be called from any part in the game where sound is needed. Example: SoundManager.PlaySound(SoundManager.Sound.PlayerMove, false);
    /// </summary>
    public static void PlaySound(Sound sound, bool isLoop = false)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            if (isLoop)
                audioSource.loop = true;
            else
                audioSource.loop = false;

            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    public static void PlaySound(Sound sound, Vector3 position, bool isLoop = false)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            if (isLoop)
                audioSource.loop = true;
            else
                audioSource.loop = false;

            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimeMax = .05f;
                    if (lastTimePlayed + playerMoveTimeMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return true;
                    
            default:
                return true;
        }
    }

    private static AudioClip GetAudioClip(Sound sound) 
    {
        foreach (SoundAudioClip clip in GameAssets.Instance.soundAudioClips)
        {
            if (clip.sound == sound)
                return clip.audioclip;
        }

        Debug.Log($"Error: Sound {sound} was not found...");
        return null;
    }
}
