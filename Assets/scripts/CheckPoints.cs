using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform NewPostion;

    [SerializeField] private CharactersManager CurrentCharacter;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
          
            CurrentCharacter.spawnPoint.position = NewPostion.position;
            CurrentCharacter.spawnPoint.rotation = NewPostion.rotation;
        }
    }
}
