using UnityEngine;
using System.Collections;

public class FallTrigger: MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<Game>().OnFallDown();
        }

    }

}
