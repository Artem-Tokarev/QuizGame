using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        new Config();
        main();
    }

    void main()
    {
        Map map = new Map();
        MapQuestion questionOnMap = new MapQuestion(map);
        Quiz quiz = new Quiz(questionOnMap);
        quiz.StartQuiz();//OR questionOnMap.Create(quiz);
    }
}
