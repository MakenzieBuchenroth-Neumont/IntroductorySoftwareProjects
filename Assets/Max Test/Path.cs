using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Path : MonoBehaviour
{
    [SerializeField] public List<Vector3> pathway;
    public int pathPointPercision = 2;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject enemy;
    public float speed = 10;
    public int currentpoint = 0;
    public float currentpathprogress = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = pathway[currentpoint];
        lineRenderer.positionCount = pathway.Count;
        lineRenderer.SetPositions(pathway.ToArray());
    }

    // Update is called once per frame
    void Update()
    {

        // probably place this stuff in the enemy
        if (currentpoint < pathway.Count - 1)
        {
            // move the enemy from the currentpoint point to the next path point based on speed
            enemy.transform.position = Vector3.Lerp(pathway[currentpoint], pathway[currentpoint + 1], currentpathprogress);
            currentpathprogress += (speed / Vector2.Distance(pathway[currentpoint], pathway[currentpoint + 1])) * Time.deltaTime;

            if (currentpathprogress >= 1)
            {
                currentpathprogress = 0;
                currentpoint++;
            }
        } else
        {
            currentpoint = 0;
        }
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

[CustomEditor(typeof(Path))]
public class ExampleEditor : Editor
{
    // Custom in-scene UI for when ExampleScript
    // component is selected.
    public void OnSceneGUI()
    {
        var t = target as Path;
        var tr = t.transform;
        var color = new Color(1, 0.8f, 0.4f, 1);
        Handles.color = color;
        Handles.DrawPolyLine(t.pathway.ToArray());
        for (int p = 0; p < t.pathway.Count; p++)
        {
            var pos = t.pathway[p];
            GUI.color = color;
            EditorGUI.BeginChangeCheck();
            Vector3 newTargetPosition = Handles.PositionHandle(pos, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(t, "Change Look At Target Position");
                newTargetPosition.x = Mathf.Round(newTargetPosition.x * t.pathPointPercision) / t.pathPointPercision;
                newTargetPosition.y = Mathf.Round(newTargetPosition.y * t.pathPointPercision) / t.pathPointPercision;
                t.pathway[p] = newTargetPosition;
            }
            Handles.Label(pos, "point " + p.ToString());
        }
    }
}