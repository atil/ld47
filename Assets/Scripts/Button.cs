using UnityEngine;
using System.Collections;

public class Button: MonoBehaviour
{
    public bool PlayEarthquake = false;

    public TimedExecuter[] ConnectedExecuters;

    public bool IsPressed;

    public Transform PushStone;


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
    
    public IEnumerator PlayPressAnim()
    {
        const float duration = 0.5f;
        Vector3 sourcePos = PushStone.localPosition;
        Vector3 targetPos = new Vector3(0.5f, 0.5f, -0.27f);

        var curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            float t = curve.Evaluate(f / duration);
            PushStone.localPosition = Vector3.Lerp(sourcePos, targetPos, t);

            yield return null;
        }
    }
}
