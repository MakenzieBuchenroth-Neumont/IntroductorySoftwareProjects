using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour {
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI livesUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    public void toggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("menuOpen", isMenuOpen);
    }

    private void OnGUI() {
        currencyUI.text = LevelManager.main.currency.ToString();
        livesUI.text = "Lives: " + LevelManager.main.lives.ToString();
    }

    public void setSelected() {

    }
}
