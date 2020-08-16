using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        // Input Detection and movement.
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

    // Detect objects in a given direction.
    public bool LegalMove(Vector2 direction)
    {
        bool result = true;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(pos, pos + direction);

        if (hit.transform.tag == "Wall")
        {
            result = false;
        } else if (hit.transform.tag == "Crate")
        {
            result = hit.transform.gameObject.GetComponent<CrateController>().LegalMove(direction);
        }

        return result;
        ;
    }
}
