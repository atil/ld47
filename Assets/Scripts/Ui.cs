using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class Ui : MonoBehaviour
{
    [Header("Squish")]
    public Color SquishColor1;
    public Color SquishColor2;
    public AnimationCurve SquishAnimationCurve;
    public Image SquishImage;
    
    [Header("Fall down")]
    public Color FallDownColor1;
    public Color FallDownColor2;
    public AnimationCurve FallDownAnimationCurve;
    public Image FallDownImage;


    [Header("End")]
    public Color EndColor1;
    public Color EndColor2;
    public AnimationCurve EndAnimationCurve;
    public Image EndImage;

    [Header("Timer")]
    public TextMeshProUGUI TimerText;
    public Slider GameTimeSlider;

    public void SetTriggerTimerText(float timer)
    {
        TimerText.text = timer.ToString("F2");

    }

    public IEnumerator EndCorutine(float duration)
    {
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            EndImage.color = Color.Lerp(EndColor1, EndColor2, EndAnimationCurve.Evaluate(f / duration));
            yield return null;
        }
    }

    public IEnumerator SquishCoroutine(float duration)
    {
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            SquishImage.color = Color.Lerp(SquishColor1, SquishColor2, SquishAnimationCurve.Evaluate(f / duration));
            yield return null;
        }
    }

    public IEnumerator FallDownCoroutine(float duration)
    {
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            FallDownImage.color = Color.Lerp(FallDownColor1, FallDownColor2, FallDownAnimationCurve.Evaluate(f / duration));
            yield return null;
        }

    }

    public void SetGameTimer(float timerRatio)
    {
        GameTimeSlider.value = 1f - timerRatio;
    }
}
