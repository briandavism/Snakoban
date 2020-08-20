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
            if (LegalMove(Vector2.up))
            {
                transform.Translate(Vector2.up);
            }
        } else if (Input.GetButtonDown("Down"))
        {
            if (LegalMove(Vector2.down))
            {
                transform.Translate(Vector2.down);
            }
        }
        else if (Input.GetButtonDown("Right"))
        {
            if (LegalMove(Vector2.right))
            {
                transform.Translate(Vector2.right);
            }
        }
        else if (Input.GetButtonDown("Left"))
        {
            if (LegalMove(Vector2.left))
            {
                transform.Translate(Vector2.left);
            }
        }

    }

    // Detect objects in a given direction.
    public bool LegalMove(Vector2 direction)
    {
        bool result = true;

        Vector2 pos = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos + direction);
        Debug.DrawLine(pos, pos + direction, Color.red, 6f, false);

        // If nothing hit, return true.
        if (!hit)
        {
            Debug.Log("No hit.");

            return result;
        }

        if (hit.transform.tag == "Wall")
        {
            Debug.Log("Wall hit.");

            result = false;
        } else if (hit.transform.tag == "Crate")
        {
            Debug.Log("Crate hit.");

            result = hit.transform.gameObject.GetComponent<CrateController>().LegalMove(direction);

            // If a crate move is possible, move the crate as well.
            if (result)
            {
                hit.transform.gameObject.GetComponent<CrateController>().PushCrate(direction);
            }
        }
        else if (hit.transform.tag == "Player")
        {
            // Placeholder for when the player hits themselves.
            Debug.Log("Player hit.");
            
        }

        return result;
    }
}
