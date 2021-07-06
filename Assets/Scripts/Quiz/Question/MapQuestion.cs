using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class MapQuestion : IQuestion
{
    Map map;
    Quiz quiz;
    MapAnswer answer;
    TextMeshProUGUI textQuestion;
    MapQuestionEventAnswer eventCorrectAnswer = new MapQuestionEventAnswer();
    MapQuestionEventAnswer eventIncorrectAnswer = new MapQuestionEventAnswer();

    public MapQuestion(Map map)
    {
        this.map = map;
        answer = new MapAnswer(map, new TweenCallback(CallbackCreateNewQuestion));
        eventCorrectAnswer.AddListener(answer.CorrectAnswer);
        eventIncorrectAnswer.AddListener(answer.IncorrectAnswer);
        textQuestion = GameObject.FindGameObjectWithTag(Config.tags.textQuestion).GetComponent<TextMeshProUGUI>();
    }

    public void Create(Quiz quiz)
    {
        this.quiz = quiz;
        quiz.SetQuestion(this);
        map.CreateMap();
        CreateQuestion();
    }

    void CreateQuestion()
    {
        Sprite spriteAnswer = answer.GenerateAnswer();
        textQuestion.text = "Find " + spriteAnswer.name;
        List<CellData> cellsData = map.GetCellsData();
        CellData correctAnswer = null;
        for (int i = 0; i < cellsData.Count; i++)//Check correct answer on map
        {
            if (cellsData[i].SpriteInCell.name == spriteAnswer.name)
            {
                correctAnswer = cellsData[i];
                cellsData.RemoveAt(i);
                break;
            }
        }
        if (correctAnswer == null)
        {
            int indexCorrectAnswer = Random.Range(0, cellsData.Count - 1);
            correctAnswer = cellsData[indexCorrectAnswer];
            cellsData.RemoveAt(indexCorrectAnswer);
        }
        correctAnswer.SpriteInCell = spriteAnswer;
        correctAnswer.SetOnCellClickEvent(eventCorrectAnswer);
        for (int i = 0; i < cellsData.Count; i++)
            cellsData[i].SetOnCellClickEvent(eventIncorrectAnswer);
        cellsData.Add(correctAnswer);
    }

    void CallbackCreateNewQuestion()
    {
        if (map.IsMaxLevelComplexityMap())
        {
            map.UpLevelComplexityMap();
            map.DeleteMap();
            quiz.EndQuiz();
        }
        else
        {
            map.UpLevelComplexityMap();
            map.RewriteMap();
            CreateQuestion();
            Config.EnableEventSystem();
        }
    }
}