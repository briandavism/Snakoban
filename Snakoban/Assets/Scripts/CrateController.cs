using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{


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
        }
        else if (hit.transform.tag == "Crate")
        {
            Debug.Log("Crate hit.");

            // Placeholder logic.
            result = false;
        } else if (hit.transform.tag == "Player")
        {
            Debug.Log("Player hit.");

            result = false;
        }

        return result;
    }

    public void PushCrate(Vector2 direction)
    {
        transform.Translate(direction);
    }
}
