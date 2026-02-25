using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource audioSourceBG;
    [SerializeField] public AudioSource  audioSourceClip;
    [SerializeField] AudioClip dialogueClipOne;
    [SerializeField] AudioClip dialogueClipTwo;
    [SerializeField] private AudioClip whereThisAnimalLive_Clip;
    [SerializeField] private AudioClip wellDone;


    private void Awake()
    {
        instance = this;
    }

    public void PlayDialogueOne()
    {
        audioSourceClip.PlayOneShot(dialogueClipOne);
    }

    public void PlayDialogueTwo()
    {
        audioSourceClip.PlayOneShot(dialogueClipTwo);
    }

    public void PlayWhereThisAnimalLive()
    {
        audioSourceClip.PlayOneShot(whereThisAnimalLive_Clip);
    }

    public void PlayWellDone()
    {
        audioSourceClip.PlayOneShot(wellDone);
    }
}
