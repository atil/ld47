using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class Ui : MonoBehaviour
{
    [Header("FadeIn")]
    public Color FadeInColor1;
    public Color FadeInColor2;
    public AnimationCurve FadeInAnimationCurve;
    public Image FadeInImage;

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

    [Header("Console")]
    public TextMeshProUGUI ConsoleText;
    public Color TextColorNormal;
    public Color TextColorError;

    [Space]
    public TextMeshProUGUI RunText;

    public void SetTriggerTimerText(float timer)
    {
        TimerText.text = timer.ToString("F2");

    }

    public IEnumerator RunTextCoroutine()
    {
        RunText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        RunText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        RunText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        RunText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        RunText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        RunText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);

        RunText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        RunText.gameObject.SetActive(false);
    }

    public IEnumerator FadeInCoroutine(float duration)
    {
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            FadeInImage.color = Color.Lerp(FadeInColor1, FadeInColor2, FadeInAnimationCurve.Evaluate(f / duration));
            yield return null;
        }
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

    public IEnumerator ConsoleTextCoroutine(string text, bool isError)
    {
        ConsoleText.text = "";
        const float normalCharDuration = 0.05f;
        const float fastCharDuration = 0.03f;

        float charDuration = isError ? fastCharDuration : normalCharDuration;
        ConsoleText.color = isError ? TextColorError : TextColorNormal;

        foreach (char c in text)
        {
            ConsoleText.text += c;
            yield return new WaitForSeconds(charDuration);
        }

    }
}
