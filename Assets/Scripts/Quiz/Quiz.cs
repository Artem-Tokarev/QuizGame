using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : IRestartObject
{
    IQuestion question;
    Restart restart;

    public Quiz(IQuestion question)
    {
        this.question = question;
        restart = GameObject.FindGameObjectWithTag(Config.tags.restart).GetComponent<Restart>();
        restart.SetRestart(this);
    }

    public void SetQuestion(IQuestion question)
    {
        this.question = question;
    }

    public void StartQuiz()
    {
        question.Create(this);
    }

    public void EndQuiz()
    {
        restart.ShowRestartMenu();
    }

    public void Restart()
    {
        StartQuiz();
    }
}