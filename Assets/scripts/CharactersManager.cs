using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    [Header("Character Generator")]
    public static CharactersManager instance;
    public Characters[] characters; //sort the characters in game
    public GameObject CurrentCharacter;

    [Header("Camera Target")]
    [SerializeField] CameraRotation target;

    public Transform spawnPoint;
    int i;
    
    public void Awake()
    {
        instance = this;

        Characters[] TheCharacters = GetComponentsInChildren<Characters>(true);

        characters = new Characters[(int)Characters.CharatersType.NumType];

        for ( i = 0; i < TheCharacters.Length; i++)
        {
            int lnSlot = (int)TheCharacters[i].charater;
            characters[lnSlot] = TheCharacters[i];
            characters[lnSlot].gameObject.SetActive(false);
        }
       
    }

    private void Start()
    {
        characters[1].gameObject.SetActive(true);
        CurrentCharacter = characters[1].gameObject;
        characters[3].gameObject.SetActive(true);
    }

    private void Update()
    {
        target._Target = CurrentCharacter.transform;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }

    }

    public Characters GetGameObject(Characters.CharatersType Type)
    {
        if (characters[(int)Type] == characters[1])
        {
            characters[1].gameObject.SetActive(true);
            CurrentCharacter = characters[1].gameObject;
            characters[2].gameObject.SetActive(false);
            characters[3].gameObject.SetActive(true);
        }
        else if(characters[(int)Type] == characters[2])
        {
            characters[2].gameObject.SetActive(true);
            CurrentCharacter = characters[2].gameObject;
            characters[1].gameObject.SetActive(false);
            characters[3].gameObject.SetActive(false);
        }
        return characters[(int)Type];
        
    }

    public Characters GetPlayer(Characters.CharatersType Player)
    {
        return characters[(int)Player];
    }

    public void Respawn()
    {
        CurrentCharacter.transform.position = spawnPoint.position;
        CurrentCharacter.transform.rotation = spawnPoint.rotation;
    }
 

}