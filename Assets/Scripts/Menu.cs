using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour {
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    public void toggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("menuOpen", isMenuOpen);
    }

    private void OnGUI() {
        Debug.Log(currencyUI.text);
        Debug.Log(LevelManager.main.currency.ToString());
        currencyUI.text = LevelManager.main.currency.ToString();
    }

    public void setSelected() {

    }
}
