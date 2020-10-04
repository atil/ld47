using UnityEngine;
using System.Collections;

public class EndTrigger: MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<Game>().OnEnd();
        }
    }
}
