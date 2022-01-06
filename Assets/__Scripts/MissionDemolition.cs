using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // ������� ������-��������
    [Header("Set in Inspector")]
    public Text uitLevel; // ������ �� ������ UIText_Level
    public Text uitShots; // ������ �� ������ UIText_Shots
    public Text uitButton; // ������ �� �������� ������ Text � UIButton_View
    public Vector3 castlePos; // �������������� �����
    public GameObject[] castles; // ������ ������

    [Header("Set Dynamically")]
    public static int level; // ������� �������
    public int levelMax; // ���������� �������
    public int shotsTaken;
    public GameObject castle; // ������� �����
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; // ����� FollowCam

    void Start()
    {
        S = this; // ���������� ������-��������
        //level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        // ���������� ������� �����, ���� �� ����������
        if (castle != null)
        {
            Destroy(castle);
        }
        // ���������� ������� �������, ���� ��� ����������
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        // ������� ����� �����
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        // �������������� ������ � ��������� �������
        SwitchView("Show Both");
        ProjectileLine.S.Clear();
        // �������� ����
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        // �������� ������ � ��������� ��
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    void Update()
    {
        UpdateGUI();
        // ��������� ���������� ������
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            if (!PlayerPrefs.HasKey("BestScore" + level))
            {
                PlayerPrefs.SetInt("BestScore" + level, shotsTaken);
            }
            else if (shotsTaken < PlayerPrefs.GetInt("BestScore" + level))
            {
                PlayerPrefs.SetInt("BestScore" + level, shotsTaken);
            }
            // �������� �����; ����� ���������� �������� ���������� ������
            mode = GameMode.levelEnd;
            // ��������� �������
            SwitchView("Show Both");
            // ������ ����� ������� ����� 2 �������
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    // ����������� �����, ����������� �� ������ ���� ��������� shotsTaken
    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}
