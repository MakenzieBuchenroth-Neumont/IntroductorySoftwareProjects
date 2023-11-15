using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void OnMouseEnter()
    {
        startColor = sprite.color;
    }

    private void OnMouseExit()
    {
        sprite.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Can't build here");
            return;
        }
        Debug.Log("Build tower here" + name);

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
