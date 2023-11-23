using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public static TowerMenu TOWERMENU;

    [SerializeField] TextMeshProUGUI pokemonName;
    [SerializeField] TextMeshProUGUI xpAmount;
    [SerializeField] Animator anim;

    private GameObject tower;

    private bool openMenu;

    // Start is called before the first frame update
    void Start()
    {
        TOWERMENU = this;
        CloseMenu();
    }

    public void OpenMenu()
    {
        openMenu = true;
        anim.SetBool("IsMenuOpen", true);
    }

    public void CloseMenu()
    {
        openMenu = false;
        anim.SetBool("IsMenuOpen", false);
        this.tower = null;
    }

    private void OnGUI()
    {
        if (this.tower != null)
        {
            pokemonName.text = this.tower.name;
            // xpAmount.text = "xp: " + tower.getXP() + "/" + tower.getXPToLevelUp()   
        }
    }

    public void SetUpMenu(GameObject tower)
    {
        this.tower = tower;
        OpenMenu();
    }
}
