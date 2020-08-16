using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{


    // Detect objects in a given direction.
    public bool LegalMove(Vector2 direction)
    {
        bool result = true;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(pos, pos + direction);

        if (hit.transform.tag == "Wall")
        {
            result = false;
        }
        else if (hit.transform.tag == "Crate")
        {
            // hit.transform.gameObject.
        }

        return result;
        ;
    }
}
