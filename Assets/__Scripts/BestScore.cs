using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public int[] Bestscore;
    public int numLevels;

    [Header("Set in Inspector")]
    public GameObject[] levels;

    // Awake is called when creating an instance
    void Awake()
    {
        numLevels = levels.Length;
        Bestscore = new int[4];
        for (int i = 0; i < numLevels; i++)
        {
            if (PlayerPrefs.HasKey("BestScore" + i))
            {
                Bestscore[i] = PlayerPrefs.GetInt("BestScore" + i);
            }
            else
            {
                Bestscore[i] = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numLevels; i++)
        {
            Text gt = this.levels[i].GetComponent<Text>();
            if (Bestscore[i] == 0)
            {
                gt.text = "NONE";
            }
            else
            {
                gt.text = Bestscore[i].ToString();
            }
        }
    }
}
