using System.Collections;

using UnityEngine;

public class SOUNDS : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSrc => GetComponent<AudioSource>();
    //public void PlayDelayed( float delay );
    public void PlaySound(AudioClip clip, float volume = 0.15f)
    {
        audioSrc.PlayOneShot(clip, volume);
    }
}
