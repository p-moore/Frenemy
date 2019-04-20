using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    public Transform progress;

    public void SetBar(float percent)
    {
        progress.localPosition = new Vector2(percent, 0);
    }

}
