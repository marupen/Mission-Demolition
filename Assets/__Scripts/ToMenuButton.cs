using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
