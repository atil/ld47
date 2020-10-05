using UnityEngine;
using System.Collections;
using System;

public class TimedExecuteInitTrigger: MonoBehaviour
{
    public TimedExecuter[] ExecutersToInit;

    public bool ReverseAnimations = false;

    public bool FreezePlayer = false;

    private bool _isTriggered = false;

    void OnTriggerEnter(Collider coll)
    {
        if (!_isTriggered && coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<Game>().OnTimerTrigger();

            _isTriggered = true;
           foreach (TimedExecuter timedExecuter in ExecutersToInit)
           {
               if (timedExecuter == null)
               {
                   continue;
               }

               StartCoroutine(timedExecuter.Init(ReverseAnimations));
           }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (ExecutersToInit != null)
        {
            foreach (TimedExecuter timedExecuter in ExecutersToInit)
            {
                Debug.DrawLine(transform.position, timedExecuter.transform.position, Color.green);
            }
        }
    }

}
