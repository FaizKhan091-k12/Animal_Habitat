using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSourceBG;
    [SerializeField] private AudioSource  audioSourceClip;
    [SerializeField] AudioClip dialogueClipOne;
    [SerializeField] AudioClip dialogueClipTwo;


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
}
