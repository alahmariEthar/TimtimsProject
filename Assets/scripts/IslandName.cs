using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandName : MonoBehaviour
{
    [SerializeField] private CanvasGroup Island;
    //[SerializeField] private bool FadeOut = false;


private void Update()
{

            Island.alpha -= Time.deltaTime; 
}
}

