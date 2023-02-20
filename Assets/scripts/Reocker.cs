using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reocker : MonoBehaviour
{
    
    [Range(-0.05f, 0.05f)]
    public float MaxAngleDeflectionX = 0.01f;
    [Range(-2.5f, 2.5f)]
    public float SpeedOfPendulumX = 0.5f;

    [Range(-0.05f, 0.05f)]
    public float MaxAngleDeflectionZ = 0.01f;
    [Range(-2.5f, 2.5f)]
    public float SpeedOfPendulumZ = 0.5f;

    [Range(-0.05f, 0.05f)]
    public float MaxAngleDeflectionY = 0.01f;
    [Range(-2.5f, 2.5f)]
    public float SpeedOfPendulumY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This makes the rotation happen
        float angleX = MaxAngleDeflectionX * Mathf.Sin( Time.time * SpeedOfPendulumX);
        float angleZ = MaxAngleDeflectionZ * Mathf.Sin( Time.time * SpeedOfPendulumZ);
        float angleY = MaxAngleDeflectionY * Mathf.Sin( Time.time * SpeedOfPendulumY);

        this.gameObject.transform.Rotate(Vector3.left * angleX );
        this.gameObject.transform.Rotate(Vector3.forward * angleZ);
        this.gameObject.transform.Rotate(Vector3.up * angleY);
    }
}