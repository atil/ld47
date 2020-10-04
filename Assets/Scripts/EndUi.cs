using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndUi: MonoBehaviour
{
    public Image FadeImage;

    [Header("Image")]
    public Color Color1;
    public Color Color2;
    public AnimationCurve AnimationCurve;
    public Image Image;

    private IEnumerator Start()
    {
        const float duration = 3f;
        
        for (float f = 0; f < duration; f += Time.deltaTime)
        {
            Image.color = Color.Lerp(Color1, Color2, AnimationCurve.Evaluate(f / duration));
            yield return null;
        }


    }
}
