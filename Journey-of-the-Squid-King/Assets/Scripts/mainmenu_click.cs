using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu_click : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName: "Main_Menu");
    }
}
