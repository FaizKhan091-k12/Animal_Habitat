using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MainMenuBehaviour : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private TypewriterTMP typewriterTMP;

    [Header("Extras")] [SerializeField] private Transform sunrays;
    [SerializeField] float sunRaysRotationSpeed;

    [Header("Main Menu")] [SerializeField] private Transform[] tittleBoardElements;

    [SerializeField] private Transform playBtn;
    [SerializeField] Animation tittleBoardAnim;

    [Header("Level 1 Properties")] [SerializeField]
    private Transform level1;

    [SerializeField] private GameObject particles;
    [SerializeField] Transform instructions;
    [SerializeField] private Transform monkey_Mascot;
    [SerializeField] private Transform dialogue_Panel;
    
    [Header("Fish Level")]
    [SerializeField] private Transform fishLevels;

    private void Start()
    {
        playBtn.localScale = Vector3.zero;
        level1.localScale = Vector3.zero;
        monkey_Mascot.localScale = Vector3.zero;
        dialogue_Panel.localScale = Vector3.zero;
        foreach (Transform element in tittleBoardElements)
        {
            element.localScale = Vector3.zero;
        }

        // tittleBoardAnim.enabled = false;
        StartCoroutine(InitializeTittleBoard());
    }

    private void Update()
    {
        sunrays.Rotate(0, 0, sunRaysRotationSpeed * Time.deltaTime);
    }

    IEnumerator InitializeTittleBoard()
    {
        foreach (Transform element in tittleBoardElements)
        {
            element.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.25f);
        }

        PlayBtnScale();
    }

    public void PlayBtnScale()
    {
        playBtn.localScale = Vector3.zero;
        playBtn.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        tittleBoardAnim.Play();
    }

    public void Level1BtnInitiate()
    {
        level1.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(Mascot), .2f);
        particles.SetActive(false);
    }

    void Mascot()
    {
        monkey_Mascot.DOScale(new Vector3(0.85f, 0.85f, 0.85f), .5f).SetEase(Ease.OutBack);
        Invoke(nameof(DialoguesPanelActivate), .2f);
    }

    void DialoguesPanelActivate()
    {
        dialogue_Panel.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(DialogueOne), .2f);
    }

    void DialogueOne()
    {
        typewriterTMP.TypeText("Oh no! The animals are lost and looking for their homes.",12f,()=> PlayDialogueTwo());
        AudioManager.instance.PlayDialogueOne();
    }

    void PlayDialogueTwo()
    {
        Invoke(nameof(DialogueTwo), 1f);
    }
    void DialogueTwo()
    {
        typewriterTMP.TypeText("They need your help to find the right place.Let’s help them one by one!", 14f,
            () => InstructionsPanelActivate());
        AudioManager.instance.PlayDialogueTwo();
    }

    void InstructionsPanelActivate()
    {
        instructions.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
    }
}
