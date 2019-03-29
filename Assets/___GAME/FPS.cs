using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public float speed = 2f;
    Vector3 moveVector;
    public CharacterController ch;
    public float gravity;
    public float jump = 10f;
    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
       moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;

        moveVector.y = gravity;
        ch.Move(moveVector * Time.deltaTime);


        if (!ch.isGrounded) gravity -= 20f * Time.deltaTime;
        else gravity = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch.isGrounded)
            gravity = jump;

    }


}
