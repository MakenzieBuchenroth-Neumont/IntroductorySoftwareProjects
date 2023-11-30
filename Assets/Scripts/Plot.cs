using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

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
        
=======
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour {
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public GameObject towerObj;
    public TowerTargeting towerTargeting;
    private Color startColor;

    private void Start() {
        startColor = sr.color;
    }

    private void OnMouseEnter() {
        sr.color = hoverColor;
    }

    private void OnMouseExit() {
        sr.color = startColor;
    }
    private void OnMouseDown() {
        if (UIManager.main.IsHoveringUI()) return;

        if (towerObj != null)
        {
            towerTargeting.OpenUpgradeUI();
            return;
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Tower towerToBuild = BuildManager.main.getSelectedTower();
            if (LevelManager.main.spendCurrency(towerToBuild.cost))
            {
                towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
                towerTargeting = towerObj.GetComponent<TowerTargeting>();
            }
        }
>>>>>>> Stashed changes
    }
}
