using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] CameraRotation target;

    public enum CharatersType
    {
        unassigned,
        player,
        ship,
        shipWaiting,
        NumType,
    }

    public CharatersType charater = CharatersType.unassigned;


    private void Update()
    {
        if (charater == CharatersType.player)
        {
            
            target._RotationY_Limitation = 3;
            target._DistanceFromTarget = 1;
        }

        else if (charater == CharatersType.ship)
        {
            target._RotationY_Limitation = -5;
            target._DistanceFromTarget = 7;
        }
    }
}
