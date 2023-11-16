using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollower : MonoBehaviour
{
    private Path pathIfollow;
    private EnemySpawner spawner;

    public float speed = 10;
    public int currentpoint = 0;
    public float currentpathprogress = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pathIfollow.pathway[currentpoint];
    }

    // Update is called once per frame
    void Update()
    {
        // probably place this stuff in the enemy
        if (currentpoint < pathIfollow.pathway.Count - 1)
        {
            // move the enemy from the currentpoint point to the next path point based on speed
            transform.position = Vector3.Lerp(pathIfollow.pathway[currentpoint], pathIfollow.pathway[currentpoint + 1], currentpathprogress);
            currentpathprogress += (speed / Vector2.Distance(pathIfollow.pathway[currentpoint], pathIfollow.pathway[currentpoint + 1])) * Time.deltaTime;

            if (currentpathprogress >= 1)
            {
                currentpathprogress = 0;
                currentpoint++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.RemoveEnemy(this.gameObject);
    }

    public void SetEnemySpawner(EnemySpawner e)
    {
        spawner = e;
    }

    public void SetPath(Path path)
    {
        pathIfollow = path;
    }
}
