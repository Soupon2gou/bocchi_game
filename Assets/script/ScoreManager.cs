using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    private int Score = 0;

    private void Start()
    {
        txtScore.text = "0";
    }
    public void SetScore(GameObject nextObj)
    {
        int num = 0;
        string s = nextObj.name;
        Debug.Log(s);
        num = int.Parse(s.Substring(12, 4));
        Score += num;
        txtScore.text = Score.ToString();
        Debug.Log(Score);
    }

    private bool IsDigits(char v)
    {
        throw new NotImplementedException();
    }
}