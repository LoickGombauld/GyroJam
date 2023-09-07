using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEditor.Rendering.LookDev;

[Serializable]
public struct MINIGAME
{
    public GameObject _minigameBaseData;
    public Sprite _sprite;
    public string _name;
}
public class MiniGameSelection : MonoBehaviour
{
    [Header("Global data")]
    public float countdownTime = 5.0f;
    public bool selectionDone = true;
    public GameManager gameManager;

    [Header("UI")]
    public Image _spriteLeft;
    public Image _spriteRight;
    public Image selectedSprite;
    public Transform countdownBar;

    [Header("Minigames")]
    public List<MINIGAME> minigameList = new List<MINIGAME>();
    [SerializeField] private List<MINIGAME> minigameRemaining = new List<MINIGAME>();
    [SerializeField] private List<MINIGAME> minigamePlayed = new List<MINIGAME>();

    public MINIGAME minigameCurrent;
    public MINIGAME minigameLeft;
    public MINIGAME minigameRight;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // get all minigames
        minigameRemaining = minigameList;

        PickNewMiniGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonLeft(InputAction.CallbackContext context)
    {
        Debug.Log("yo1");
        if (context.phase != InputActionPhase.Performed)
            return;

        if(selectionDone)
            return;

        selectedSprite.GetComponent<Transform>().DOKill();
        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(1f, 1f, 1f), 0.2f);

        Debug.Log("pick left minigame");
        minigameCurrent = minigameLeft;
        selectedSprite = _spriteLeft;

        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(0.2f, 0.2f, 1.0f), 0.8f).SetLoops(-1, LoopType.Yoyo);
    }
    
    public void OnButtonRight(InputAction.CallbackContext context)
    {
        Debug.Log("yo2");
        if (context.phase != InputActionPhase.Performed)
            return;

        if (selectionDone)
            return;

        selectedSprite.GetComponent<Transform>().DOKill();
        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(1f, 1f, 1f), 0.2f);

        Debug.Log("pick right minigame");
        minigameCurrent = minigameRight;
        selectedSprite = _spriteRight;

        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(0.2f, 0.2f, 1.0f), 0.8f).SetLoops(-1, LoopType.Yoyo);
    }

    public void PickNewMiniGame()
    {
        int nbMinigame = minigameRemaining.Count;
        int indexLeft = UnityEngine.Random.Range(0, nbMinigame - 1);
        int indexRight = UnityEngine.Random.Range(0, nbMinigame - 1);

        minigameLeft = minigameRemaining[indexLeft];
        minigameRight = minigameRemaining[indexRight];

        while (minigamePlayed.Contains(minigameLeft))
        {
            indexLeft = UnityEngine.Random.Range(0, nbMinigame - 1);
            minigameLeft = minigameRemaining[indexLeft];
            Debug.Log("reroll minigame 1");
        }

        
        while (indexRight == indexLeft || minigamePlayed.Contains(minigameRight))
        {
            indexRight = UnityEngine.Random.Range(0, nbMinigame - 1);
            minigameRight = minigameRemaining[indexRight];
            Debug.Log("reroll minigame 2");
        }

        Debug.Log("minigame 1: " + indexLeft + " - minigame 2: " + indexRight);

        //set the default selection to the left minigame
        minigameCurrent = minigameLeft;
        selectedSprite = _spriteLeft;

        ChangeSprites();

        selectionDone = false;

        StartCoroutine(SelectionCountdown(countdownTime));
        countdownBar.localScale= new Vector3(1f, 1f, 1f);
        countdownBar.DOScaleX(0f, countdownTime);
        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(0.2f, 0.2f, 1.0f), 0.8f).SetLoops(-1, LoopType.Yoyo);
    }
    public void ChangeSprites()
    {
        _spriteLeft.sprite = minigameLeft._sprite;
        _spriteRight.sprite = minigameRight._sprite;
    }

    public void SelectionCountdownDone()
    {
        //Here start the selected minigame : minigameCurrent
        selectionDone = true;
        selectedSprite.GetComponent<Transform>().DOKill();
        selectedSprite.GetComponent<Transform>().DOScale(new Vector3(2f, 2f, 2f), 0.5f);
        GameObject miniGame = Instantiate(minigameCurrent._minigameBaseData);
        Debug.Log("start " + minigameCurrent._name);

    }

    IEnumerator SelectionCountdown(float seconds)
    {
        float counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        SelectionCountdownDone();
    }

}
