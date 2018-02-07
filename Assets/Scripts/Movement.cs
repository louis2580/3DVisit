using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 6f;
    public float turningSpeed = 6f;
    Vector3 movement;
    int floorMask; // A layer mask so that a ray can be cast just at gameobjects on the floor
    Vector3 prevMousePos;
    bool paused = false;


    // Use this for initialization
    void Start () {
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
            // Keep the balance feeling
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
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
        if (!Input.GetMouseButton(0)) // left click not pressed
        {
            prevMousePos.Set(mousePos.x, mousePos.y, 0);
        }
        else // pressed left click
        {
            float xMov = mousePos.x - prevMousePos.x;
            float yMov = mousePos.y - prevMousePos.y;

            transform.Rotate(-Vector3.right * yMov);
            transform.Rotate(Vector3.up * xMov);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

            prevMousePos.Set(mousePos.x, mousePos.y, 0);
        }

    }

}
