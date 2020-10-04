using UnityEngine;
using System.Collections;

public class Button: MonoBehaviour
{
    public TimedExecuter[] ConnectedExecuters;

    public bool IsPressed;

    private void OnDrawGizmosSelected()
    {
        if (ConnectedExecuters != null)
        {
            foreach (var executer in ConnectedExecuters)
            {
                Debug.DrawLine(transform.position, executer.transform.position);
            }
        }
    }
}
