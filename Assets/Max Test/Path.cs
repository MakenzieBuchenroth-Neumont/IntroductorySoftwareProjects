using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Vector2> pathway;

    [SerializeField] private GameObject enemy;
    public float speed = 10;
    public int currentpath = 0;
    public float currentpathwayprogress = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = pathway[currentpath];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentpath < pathway.Count - 1)
        {
            enemy.transform.position = Vector3.Lerp(pathway[currentpath], pathway[currentpath + 1], currentpathwayprogress);
            currentpathwayprogress += (speed / Vector2.Distance(pathway[currentpath], pathway[currentpath + 1])) * Time.deltaTime;

            if (currentpathwayprogress >= 1)
            {
                currentpathwayprogress = 0;
                currentpath++;
            }
        } else
        {
            currentpath = 0;
        }
    }

    // Draw a line for reference in editor
    // update this at some point to use a sprite or something idk
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
