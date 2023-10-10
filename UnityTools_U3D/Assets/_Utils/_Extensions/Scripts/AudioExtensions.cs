using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioExtensions
{
    public static bool IsPlayingAndFinishing(this AudioSource audioSource)
    {
        return (audioSource.isPlaying && ((audioSource.time) / audioSource.clip.length > 90f / 100f));
    }
}
