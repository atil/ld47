using UnityEngine;
using System.Collections;
using System;

public class TimedExecuteInitTrigger: MonoBehaviour
{
    public TimedExecuter[] ExecutersToInit;

    public bool ReverseAnimations = false;

    private bool _isTriggered = false;

    void OnTriggerEnter(Collider coll)
    {
        if (!_isTriggered && coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<Game>().OnTimerTrigger();

            _isTriggered = true;
            for (int i = 0; i < ExecutersToInit.Length; i++)
            {
                StartCoroutine(ExecutersToInit[i].Init(ReverseAnimations));
            }

            foreach (TimedExecuter timedExecuter in ExecutersToInit)
            {
                timedExecuter.Init();
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
