using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu_controller : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("First_Scene");
    }

    public void QuitGame() {
        Debug.Log("Game has quit!");
        Application.Quit();
    }
}
