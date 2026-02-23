using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MainMenuBehaviour : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private TypewriterTMP typewriterTMP;

    [Header("Sounds Settings")]
    [SerializeField] private bool isMute;

    [SerializeField] private GameObject mute;
    [SerializeField] GameObject unMute;

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

    [SerializeField] private GameObject clouds;
    [SerializeField] private Transform fish;
    [SerializeField] private Transform cluesBoard,question_Board;
    [SerializeField] private Transform water_Btn, desert_Btn, forest_Btn;
    [SerializeField] private Transform fish_Video;

    
    [Header("Camel Level")]
    [SerializeField] private Transform camelLevels;

    [SerializeField] private GameObject camel_clouds;
    [SerializeField] private Transform camel;
    [SerializeField] private Transform camel_cluesBoard,camel_question_Board;
    [SerializeField] private Transform camel_water_Btn, camel_desert_Btn, camel_forest_Btn;
    [SerializeField] private Transform camel_Video;




    private void Start()
    {
        playBtn.localScale = Vector3.zero;
        level1.localScale = Vector3.zero;
        monkey_Mascot.localScale = Vector3.zero;
        dialogue_Panel.localScale = Vector3.zero;
        fishLevels.localScale = Vector3.zero;
        camelLevels.localScale = Vector3.zero;
        camel_clouds.SetActive(false);
        clouds.SetActive(false);
        
        //Fish Level
        
        fish.localScale = Vector3.zero;
        cluesBoard.localScale = Vector3.zero;
        question_Board.localScale = Vector3.zero;
        water_Btn.localScale = Vector3.zero;
        desert_Btn.localScale = Vector3.zero;
        forest_Btn.localScale = Vector3.zero;
        fish_Video.localScale = Vector3.zero;
   
        
        // Camel
        
        camel.localScale = Vector3.zero;
        camel_cluesBoard.localScale = Vector3.zero;
        camel_question_Board.localScale = Vector3.zero;
        camel_water_Btn.localScale = Vector3.zero;
        camel_desert_Btn.localScale = Vector3.zero;
        camel_forest_Btn.localScale = Vector3.zero;
        camel_Video.localScale = Vector3.zero;
      
        
        foreach (Transform element in tittleBoardElements)
        {
            element.localScale = Vector3.zero;
        }

        IsMuted();
        // tittleBoardAnim.enabled = false;
        StartCoroutine(InitializeTittleBoard());
    }

    private void Update()
    {
        sunrays.Rotate(0, 0, sunRaysRotationSpeed * Time.deltaTime);
    }

    public void IsMuted()
    {
        isMute = !isMute;
        if (isMute)
        {
            AudioManager.instance.audioSourceBG.volume = 0f;
            AudioManager.instance.audioSourceClip.volume = 0f;
            mute.transform.localScale = Vector3.zero;
            unMute.transform.localScale = Vector3.zero;
            mute.transform.DOScale(Vector3.one, .01f).SetEase(Ease.OutBack);
            
        }
        else
        {
            AudioManager.instance.audioSourceBG.volume = 1f;
            AudioManager.instance.audioSourceClip.volume = 1f;
            mute.transform.localScale = Vector3.zero;
            unMute.transform.localScale = Vector3.zero;
            unMute.transform.DOScale(Vector3.one, .01f).SetEase(Ease.OutBack);
        }
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

    public void ContinueBtnClicked()
    {
        fishLevels.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(ActivateClouds),.1f);
    }

    void ActivateClouds()
    {
        clouds.SetActive(true);
        Invoke(nameof(FishActivate),.2f);
    }

    #region FishLevel

    void FishActivate()
    {
        fish.DOScale(Vector3.one,.5f).SetEase(Ease.OutBack);
        Invoke(nameof(ClueBoardActivate),.2f);
    }

    void ClueBoardActivate()
    {
        cluesBoard.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        question_Board.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(Water),.25f);
    }

    void Water()
    {
        water_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(Desert),.25f);
    }

    void Desert()
    {
        desert_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(Forest),.25f);
    }

    void Forest()
    {
        forest_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        water_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        desert_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        forest_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        AudioManager.instance.PlayWhereThisAnimalLive();    
    }

    public void FishVideo()
    {
    
        fish_Video.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
    }

    #endregion
    
    #region CamelLevel

    public void CamelActivate()
    {
        camelLevels.DOScale(Vector3.one,.5f).SetEase(Ease.OutBack);
        camel_clouds.SetActive(true);
        Invoke(nameof(CamelClueBoardActivate),.2f);
    }

    void CamelClueBoardActivate()
    {
        camel.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        camel_cluesBoard.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        camel_question_Board.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(CamelWater),.25f);
    }

    void CamelWater()
    {
        camel_water_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(CamelDesert),.25f);
    }

    void CamelDesert()
    {
        camel_desert_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        Invoke(nameof(CamelForest),.25f);
    }

    void CamelForest()
    {
        camel_forest_Btn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        camel_water_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        camel_desert_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        camel_forest_Btn.GetComponent<UIHoverClickEffect>().enableIdlePulse = true;
        AudioManager.instance.PlayWhereThisAnimalLive();    
    }

    public void CamelVideo()
    {

        camel_Video.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
    }

    #endregion
}
