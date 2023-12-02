using UnityEngine;

public class LeafShooter : MonoBehaviour
{
    public GameObject leafPrefab;
    public int numberOfLeaves = 5;
    public float spreadAngle = 45f;
    public float leafSpeed = 5f;

    public void ShootLeaves()
    {
        for (int i = 0; i < numberOfLeaves; i++)
        {
            // Create an instance of the leaf
            GameObject leaf = Instantiate(leafPrefab, transform.position, Quaternion.identity);

            // Calculate a random angle for each leaf
            float angle = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

            // Set the leaf's direction and speed
            BulbasaurLeaf leafScript = leaf.GetComponent<BulbasaurLeaf>();
            leafScript.moveDirection = direction;
            leafScript.leafSpeed = leafSpeed;

            // scale
            //leaf.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }
}