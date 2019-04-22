using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]GameObject Winner;

    void Start()
    {

       Winner.GetComponent<TextMeshProUGUI>().SetText("Player " + GameController.idOfWinner);


    }




}
