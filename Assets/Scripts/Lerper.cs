using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyFrame
{
    public Vector3 Position;
    public Quaternion Rotation = Quaternion.identity;
    public float Duration = 2;
}


public class Lerper : MonoBehaviour
{
    public AnimationCurve LerpCurve;

    public List<KeyFrame> KeyFrames = new List<KeyFrame>();

    public bool IsPlaying = false;

    public IEnumerator PlayAnimation(bool reverse)
    {
        IsPlaying = true;

        if (reverse)
        {
            KeyFrames.Reverse();
        }

        for (int i = 0; i < KeyFrames.Count - 1; i++)
        {
            Vector3 p1 = KeyFrames[i].Position;
            Quaternion q1 = KeyFrames[i].Rotation;
            Vector3 p2 = KeyFrames[i + 1].Position;
            Quaternion q2 = KeyFrames[i + 1].Rotation;

            float duration = KeyFrames[i].Duration;
            for (float f = 0; f < duration; f += Time.deltaTime)
            {
                float t = LerpCurve.Evaluate(f / duration);
                transform.position = Vector3.Lerp(p1, p2, t);
                transform.rotation = Quaternion.Lerp(q1, q2, t);
                yield return null;
            }

            transform.position = p2;
            transform.rotation = q2;
        }

        if (reverse)
        {
            KeyFrames.Reverse();
        }

        IsPlaying = false;
    }
}
