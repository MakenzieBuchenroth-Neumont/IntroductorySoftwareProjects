using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public List<Vector3> pathway;
    public int pathPointPercision = 2;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject enemy;
    public float speed = 10;
    public int currentpoint = 0;
    public float currentpathprogress = 0;

    // ... (rest of the script remains unchanged)

    // Draw a checkered grid with boxes bordering the path in black
    private void OnDrawGizmos()
    {
        if (pathway.Count > 1)
        {
            for (int i = 0; i < pathway.Count - 1; i++)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pathway[i], pathway[i + 1]);
                DrawCheckeredGrid(pathway[i], pathway[i + 1]);
            }
        }
    }

    private void DrawCheckeredGrid(Vector3 start, Vector3 end)
    {
        float gridSize = 1.0f; // Change this value based on your grid size
        int divisions = Mathf.CeilToInt(Vector3.Distance(start, end) / gridSize);

        for (int i = 0; i < divisions; i++)
        {
            float t = i / (float)divisions;
            Vector3 point = Vector3.Lerp(start, end, t);

            // Draw a checkered pattern
            if (i % 2 == 0)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(point, Vector3.one * gridSize);
            }
            else
            {
                Gizmos.color = Color.white;
                Gizmos.DrawCube(point, Vector3.one * gridSize);
            }
        }
    }

    // ... (rest of the script remains unchanged)
}
