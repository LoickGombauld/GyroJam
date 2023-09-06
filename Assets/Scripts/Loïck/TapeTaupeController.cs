using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TapeTaupeController : MinigameController<TapeTaupeData>
{
    private Taupe[] SpotA;
    private Taupe[] SpotB;
    public IEnumerator TaupeLoop()
    {

        while (CurrentData.TimeDuration > 0)
        {
            Taupe[] currentTaupe = new Taupe[3];
            switch (Random.Range(0, 1))
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        if (SpotA[i].transform.gameObject.activeSelf!)
                        {
                            SpotA[i].Type = (TaupeType)Random.Range(0, 2);
                            SpotA[i].transform.gameObject.SetActive(true);
                            currentTaupe[i] = SpotA[i];
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        if (SpotB[i].transform.gameObject.activeSelf!)
                        {
                            SpotA[i].Type = (TaupeType)Random.Range(0, 2);
                            SpotB[i].transform.gameObject.SetActive(true);
                            currentTaupe[i] = SpotB[i];
                        }
                    }
                    break;
            }
            yield return new WaitForSeconds(CurrentData.TaupeDelay);
            foreach (var Taupe in currentTaupe)
            {
                Taupe.Type = TaupeType.None;
                Taupe.transform.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

}
