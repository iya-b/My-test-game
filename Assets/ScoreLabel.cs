using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour 
{
    private static int score;
    private Text label;
    public static int Score { get; internal set; }

    void Start()
    {
        Text text = label;
    }

    void Update()
    {
        label.text = score.ToString();

    }

}
