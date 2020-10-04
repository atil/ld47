using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Lerper))]
public class TimedExecuter : MonoBehaviour
{
    public float Timestamp;

    public IEnumerator Init(bool reverseAnimation = false)
    {
        yield return new WaitForSeconds(Timestamp);
        yield return new WaitWhile(() => GetComponent<Lerper>().IsPlaying);
        StartCoroutine(GetComponent<Lerper>().PlayAnimation(reverseAnimation));
    }
}
