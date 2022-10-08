using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject optionsMenu;

    public void PlayButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
    }
}
