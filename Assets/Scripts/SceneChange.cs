using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public string sceneToLoad;

    public Button Button;

    private void Start()
    {
        if (Button != null)
        {
            Button.onClick.AddListener(LoadScene);
        }
        else
        {
            Debug.LogError("Load scene button is not assigned");
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene to load not specified");
        }
    }
}