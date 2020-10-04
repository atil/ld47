using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Lerper))]
public class LerperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Lerper lerper = (Lerper)target;

        if(GUILayout.Button("Append"))
        {
            lerper.KeyFrames.Add(new KeyFrame
            {
                Position = lerper.transform.position,
                Rotation = lerper.transform.rotation,
                Duration = 2
            });
        }

        if(GUILayout.Button("Initial"))
        {
            lerper.transform.position = lerper.KeyFrames[0].Position;
            lerper.transform.rotation = lerper.KeyFrames[0].Rotation;
        }

        if(GUILayout.Button("Fallen"))
        {
            lerper.transform.position = lerper.KeyFrames[1].Position;
            lerper.transform.rotation = lerper.KeyFrames[1].Rotation;
        }

        if(GUILayout.Button("Clear"))
        {
            lerper.KeyFrames.Clear();
        }

        GUILayout.Space(10);

        base.OnInspectorGUI();
   }
}
