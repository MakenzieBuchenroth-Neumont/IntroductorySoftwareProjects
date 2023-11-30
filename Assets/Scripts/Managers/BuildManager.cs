using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Assets/Scripts/Level Manager/BuildManager.cs
public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    } 

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
public class BuildManager : MonoBehaviour {
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers;

    private int selectedTower = 0;

    private void Awake() {
        main = this;
    }

    public Tower getSelectedTower() {
        return towers[selectedTower];
    }

    public void setSelectedTower(int _selectedTower) {
        selectedTower = _selectedTower;
>>>>>>> Stashed changes:Assets/Scripts/Managers/BuildManager.cs
    }
}
