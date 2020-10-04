using UnityEngine;
using System.Collections;
using UnityEditor;

public static class EditorUtils
{
    [MenuItem("LD47/Top View #&q", false, 10)]
    private static void TopView()
    {
        SceneView s = SceneView.sceneViews[0] as SceneView;
        s.LookAt(s.pivot, Quaternion.LookRotation(new Vector3(0, -1, 0)), s.size, true);
        s.orthographic = true;
    }
}
