using UnityEngine;
using System.Collections;

public class Music: MonoBehaviour
{
    public AudioSource AudioSource;

    public void FadeOut(float duration)
    {
        StartCoroutine(FadeOutCoroutine(duration));
    }
    
    private IEnumerator FadeOutCoroutine(float duration)
    {
        float srcLevel = AudioSource.volume;
        var curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            AudioSource.volume = Mathf.Lerp(srcLevel, 0f, curve.Evaluate(f / duration));
            yield return null;
        }

        AudioSource.Stop();
    }

    public void Stop()
    {
        AudioSource.Stop();
    }

}
