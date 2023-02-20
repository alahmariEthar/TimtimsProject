using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;
    public Text FbsText;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fbs = 1.0f / deltaTime;
        FbsText.text = "FBS : " + Mathf.Ceil(fbs).ToString();

        if(fbs >= 90)
        {
            FbsText.color = Color.green;
        }
        else if (fbs <=89 || fbs >=60)
        {
            FbsText.color = Color.yellow;
        }
        else 
        {
            FbsText.color = Color.red;
        }
    }
}
