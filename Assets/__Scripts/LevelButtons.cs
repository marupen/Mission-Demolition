using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    public void First()
    {
        MissionDemolition.level = 0;
        SceneManager.LoadScene("_Scene_0");
    }
    public void Second()
    {
        MissionDemolition.level = 1;
        SceneManager.LoadScene("_Scene_0");
    }
    public void Third()
    {
        MissionDemolition.level = 2;
        SceneManager.LoadScene("_Scene_0");
    }
    public void Fourth()
    {
        MissionDemolition.level = 3;
        SceneManager.LoadScene("_Scene_0");
    }
}
