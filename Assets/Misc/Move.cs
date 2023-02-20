using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour{
public SoundManager sm;
public float speed;

void Update() {
   float h = Input.GetAxisRaw("Horizontal");
   float v = Input.GetAxisRaw("Vertical");
   
   gameObject.transform.position = new Vector3 (transform.position.x + (h * speed),0,transform.position.z + (v * speed));
   sm.PlayWater();
}
}

