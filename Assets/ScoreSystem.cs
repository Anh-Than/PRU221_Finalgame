using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    string highscoreFile;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public int defaultScore;
    public int curScore;
    public int highscore;
    void Start()
    {
        defaultScore = 0;
        curScore = defaultScore;
        highscoreFile = Application.dataPath + "/HighscoreText" + "/highscore.txt";
        GetHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainScore(int number)
    {
        curScore += number;
    }

    public void GetHighscore()
    {
        try
        {
            if (ReadWriteFromFile.instance.ReadText(highscoreFile) != null)
            {
                string[] lines = ReadWriteFromFile.instance.ReadText(highscoreFile);
                if(lines.Length > 0)
                {
                    List<int> scores = new List<int>();
                    foreach (string line in lines)
                    {
                        string[] component = line.Split('-');
                        scores.Add(int.Parse(component[1]));
                    }
                    highscore = scores.Max();
                }               
            }
            else
            {
                highscore = 0;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }
}
