using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public List<Vector3> pathway;
    public int pathPointPercision = 2;
    [SerializeField] private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SetLineRenderer();
    }

    public void SetLineRenderer()
    {
        lineRenderer.positionCount = pathway.Count;
        lineRenderer.SetPositions(pathway.ToArray());
    }

    // Draw a line for reference in editor
    // update this at some point to use a sprite or something better than a gizmo
    private void OnDrawGizmos()
    {
        if (pathway.Count > 1)
        {
            for (int i = 0; i < pathway.Count - 1; i++)
            {
                Gizmos.DrawLine(pathway[i], pathway[i+1]);
            }
        }
    }
}

//[CustomEditor(typeof(Path))]
//public class ExampleEditor : Editor
//{
//    //
//    // Custom in-scene UI for when ExampleScript
//    // component is selected.
//    public void OnSceneGUI()
//    {
//        var t = target as Path;
//        var tr = t.transform;
//        var color = new Color(1, 0.8f, 0.4f, 1);
//        Handles.color = color;
//        Handles.DrawPolyLine(t.pathway.ToArray());
//        if (t.pathway.Count > 0)
//        {
//            for (int p = 0; p < t.pathway.Count; p++)
//            {
//                var pos = t.pathway[p];
//                if (p == t.pathway.Count - 1)
//                {
//                    Handles.color = Color.green;
//                    if (Handles.Button(pos + new Vector3(1, 1, 0), Quaternion.identity, 0.75f, 0.1f, Handles.SphereHandleCap))
//                    {
//                        t.pathway.Add(pos + new Vector3(1, 1, 0));
//                        t.SetLineRenderer();
//                    }
//                    Handles.color = Color.red;
//                    if (Handles.Button(pos + new Vector3(-1, 1, 0), Quaternion.identity, 0.75f, 0.1f, Handles.SphereHandleCap))
//                    {
//                        t.pathway.Remove(pos);
//                        t.SetLineRenderer();
//                    }
//                }
//                EditorGUI.BeginChangeCheck();
//                Vector3 newTargetPosition = Handles.PositionHandle(pos, Quaternion.identity);
//                if (EditorGUI.EndChangeCheck())
//                {
//                    Undo.RecordObject(t, "Change Look At Target Position");
//                    newTargetPosition.x = Mathf.Round(newTargetPosition.x * t.pathPointPercision) / t.pathPointPercision;
//                    newTargetPosition.y = Mathf.Round(newTargetPosition.y * t.pathPointPercision) / t.pathPointPercision;
//                    t.pathway[p] = newTargetPosition;
//                    t.SetLineRenderer();
//                }
//                Handles.Label(pos, "point " + p.ToString());
//            }
//        } 
//        else
//        {
//            Handles.color = Color.blue;
//            if (Handles.Button(t.gameObject.transform.position, Quaternion.identity, 0.75f, 0.1f, Handles.SphereHandleCap))
//            {
//                t.pathway.Add(t.gameObject.transform.position);
//                t.SetLineRenderer();
//            }
//        }
//    }
//}