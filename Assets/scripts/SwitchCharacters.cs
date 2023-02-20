using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] Transform[] waypoints;


    private void Update()
    {
        Player = CharactersManager.instance.GetPlayer(Characters.CharatersType.player).gameObject;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("switching to ship");
            CharactersManager.instance.GetGameObject(Characters.CharatersType.ship);
            
        }
        if (other.CompareTag("Player2"))
        {
            CharactersManager.instance.GetGameObject(Characters.CharatersType.player);
            
                Debug.Log("switching to player");

            Player.transform.position = waypoints[0].transform.position;
            Player.transform.rotation = waypoints[0].transform.rotation;

        }
        
    }
}
