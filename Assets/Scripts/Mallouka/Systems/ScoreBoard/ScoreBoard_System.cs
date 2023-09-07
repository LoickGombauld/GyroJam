using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard_System : MonoBehaviour
{



    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int playerScore;
    }

    [Header("General Variables")]
    [SerializeField] private List<PlayerScore> _highestScoresList = new List<PlayerScore>();
    [SerializeField] private List<PlayerScore> _scoreList = new List<PlayerScore>();
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject scoreBarrPrefab;

    [Header("Debug Variables")]
    public bool ActualizeUIBool;

    private void Update()
    {
        if (ActualizeUIBool)
        {
            ActualizeListUI();
            ActualizeUIBool = false;
        }
    }


    public void ClearListUI()
    {
        List<GameObject> listUI = new List<GameObject>();


        for (int i =0; i < contentTransform.childCount; i++)
        {
            listUI[i] = contentTransform.GetChild(i).gameObject;
        }

        foreach(GameObject child in listUI)
        {
            Destroy(child);
        }
    }


    public void ActualizeListUI()
    {
        GetHighestScores();
        ClearListUI();

        foreach (PlayerScore score in _highestScoresList)
        {
            TMP_Text sBarrText = Instantiate<GameObject>(scoreBarrPrefab, contentTransform).GetComponentInChildren<TMP_Text>();

            sBarrText.SetText(score.playerName + " - " + score.playerScore + " " + "Points");

        }
    }




    public void GetHighestScores()
    {

        for(int i = 0; i < _scoreList.Count; i++)
        {

            for(int y = 0; y < 8; y++)
            {

                if(_scoreList[i].playerScore > _highestScoresList[y].playerScore)
                {
                    _highestScoresList[y] = _scoreList[i];
                    break;
                }
            }

        }

    }
}
