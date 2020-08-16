using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            transform.Translate(Vector2.up);
        } else if (Input.GetButtonDown("Down"))
        {
            transform.Translate(Vector2.down);
        }
        else if (Input.GetButtonDown("Right"))
        {
            transform.Translate(Vector2.right);
        }
        else if (Input.GetButtonDown("Left"))
        {
            transform.Translate(Vector2.left);
        }

    }
}
