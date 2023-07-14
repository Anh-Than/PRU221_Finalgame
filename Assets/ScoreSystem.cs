using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public int defaultScore;
    public int curScore;
    void Start()
    {
        defaultScore = 0;
        curScore = defaultScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainScore(int number)
    {
        curScore += number;
    }
}
