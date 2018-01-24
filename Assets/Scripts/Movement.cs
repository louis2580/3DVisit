using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 6f;
    public float turningSpeed = 6f;
    Vector3 movement;
    int floorMask; // A layer mask so that a ray can be cast just at gameobjects on the floor
    float camRayLength = 100f;
    Vector3 prevMousePos;
    bool paused = false;


    // Use this for initialization
    void Start () {
        Screen.lockCursor = true;
        prevMousePos = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        // call on every physics update
        float h = Input.GetAxisRaw("Horizontal"); // get raw to have less variation, 0 or 1 (more reaction because of full speed)
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            paused = !paused;
        }
        if (!paused)
        {
            // move the player on the scene
            Move(h, v);
            // to rotate the camera
            Turning();
        }
        
    }

    void Move(float h, float v)
    {
            // movement in the player referentiel
            if (Input.GetKey(KeyCode.Z))
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                transform.position -= transform.right * Time.deltaTime * speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }
        
    }

    void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        float xMov = mousePos.x - prevMousePos.x;
        float yMov = mousePos.y - prevMousePos.y;

        transform.Rotate(Vector3.right * xMov);
        transform.Rotate(Vector3.up * yMov);

        Input.mousePosition.Set()

    }

}
