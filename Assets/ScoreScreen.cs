using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]GameObject Winner;

    void Start()
    {
        if (GameController.idOfWinner != -1)
        {
            Winner.GetComponent<TextMeshProUGUI>().SetText("Player " + GameController.idOfWinner);
        }
        else
        {
            Winner.GetComponent<TextMeshProUGUI>().SetText("The Boss Won");
        }


    }




}
