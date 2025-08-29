using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeButton : MonoBehaviour
{
    public GameObject[] EncountUIBase;
    public GameObject[] EncounterUI = new GameObject[11];

    public int CurrentEncounter; //인카운트 노드 구분용

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() // 
    {
        switch (CurrentEncounter)
        {
            case 0:
                EncounterUI[0].SetActive(true);
                break;

            case 1:
                EncounterUI[1].SetActive(true);
                break;

            case 2:
                EncounterUI[2].SetActive(true);
                break;

            case 3:
                EncounterUI[3].SetActive(true);
                break;

            case 4:
                EncounterUI[4].SetActive(true);
                break;

            case 5:
                EncounterUI[5].SetActive(true);
                break;

            case 6:
                EncounterUI[6].SetActive(true);
                break;

            case 7:
                EncounterUI[7].SetActive(true);
                break;

            case 8:
                EncounterUI[8].SetActive(true);
                break;

            case 9:
                EncounterUI[9].SetActive(true);
                break;

            case 10:
                EncounterUI[10].SetActive(true);
                break;

            default:
                EncounterUI[0].SetActive(true);
                break;
        }
    }


}
