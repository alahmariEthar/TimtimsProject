using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    [SerializeField] GameObject [] Charecters;
    [SerializeField] GameObject [] SwitchCamera;

    [SerializeField]GameObject CurrentCharecter;
    void Start()
    {
        foreach(GameObject charecters in Charecters)
        {
            charecters.SetActive(false);
        }
        SwitchCamera[0].SetActive(true);
        SwitchCamera[1].SetActive(false);
        Charecters[0].SetActive(true);
        CurrentCharecter = Charecters[0];
    }

    //void transposition()
    //{
    //    switch (CurrentCharecter){
    //        case1:
    //    CurrentCharecter = 2;
    //    break;
    //}
    //    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("switching");
            CurrentCharecter = Charecters[1];
            Charecters[0].SetActive(false);
            Charecters[1].SetActive(true);
            if (Charecters[1] == true)
            {
                SwitchCamera[0].SetActive(false);
                SwitchCamera[1].SetActive(true);
            }
            //SwitchCamera.SwitchTarget(GetComponent<CameraRotation>().Targets[1]);
            //GetComponent<CameraRotation>().i = 1;
            //Debug.Log("switching Cam");
            //SwitchCamera.SwitchTarget(Charecters[1]);
            //Debug.Log("switching Cam1");

        }
    }



}
