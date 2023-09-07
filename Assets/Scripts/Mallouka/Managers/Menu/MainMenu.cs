using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Variables")]
    [SerializeField] private GameObject UI_Canvas;
    [SerializeField] private bool playerActive;
    [SerializeField] private float inactiveTimer;
    [SerializeField] private GameObject currentPanel;

    [Header("Panels")]
    [SerializeField] private GameObject selectionPanel;
    [SerializeField] private GameObject scoreBoardPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Settings Variables")]
    [SerializeField] private Slider volumeSlider;



    // Start is called before the first frame update
    void Start()
    {
        currentPanel = selectionPanel;
        InitializedVolumeScaleSlider();
    }

    // Update is called once per frame
    void Update()
    {




        if(Input.GetKeyDown(KeyCode.H))
        {
            playerActive = true;
        }

        /*
        if(playerActive)
        {
            inactiveTimer += Time.deltaTime;
            SwitchMode();
        }
        else
        {
            SwitchMode();
        }

        if(inactiveTimer > 20.0f)
        {
            inactiveTimer = 0.0f;
            playerActive = false;
        }
        */
    }


    public void ToggleScoreBoard()
    {
        currentPanel.SetActive(false);

        currentPanel = scoreBoardPanel;

        currentPanel.SetActive(true);
    }


    public void ToggleMainMenu()
    {
        currentPanel.SetActive(false);

        currentPanel = selectionPanel;

        currentPanel.SetActive(true);
    }


    public void ToggleCredits()
    {
        currentPanel.SetActive(false);

        currentPanel = creditsPanel;

        currentPanel.SetActive(true);
    }


    public void ToggleSettings()
    {
        
        currentPanel.SetActive(false);

        currentPanel = settingsPanel;

        currentPanel.SetActive(true);
        

        /*
        SetInvisible(currentPanel);


        currentPanel = settingsPanel;


        SetVisible(currentPanel);
        */
    }





    public void SetInvisible(GameObject panel)
    {

        CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();
        panelCanvasGroup.alpha = 0.0f;
        panelCanvasGroup.blocksRaycasts = false;
        panelCanvasGroup.interactable = false;
    }

    public void SetVisible(GameObject panel)
    {
        CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();
        panelCanvasGroup.alpha = 1.0f;
        panelCanvasGroup.blocksRaycasts = true;
        panelCanvasGroup.interactable = true;
    }


    public void SaveVolumeScaleSettings()
    {
        PlayerPrefs.SetFloat("volumeScale", volumeSlider.value);
        PlayerPrefs.Save();

        AudioManager.instance.volumeScale = volumeSlider.value;
    }

    public void InitializedVolumeScaleSlider()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeScale");
    }


    public void SwitchMode()
    {
        if (playerActive)
        {
            selectionPanel.SetActive(true);
        }
        else
        {
            selectionPanel.SetActive(false);
        }
    }
}
