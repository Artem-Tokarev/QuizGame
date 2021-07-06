using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapAnswer : IAnswer<Transform, Sprite>
{
    Map map;
    PacksSpritesController packsSpritesPastAnswers = new PacksSpritesController();
    ParticleAnswer particleCorrectAnswer;
    TweenCallback callbackCreateNewQuestion;

    public MapAnswer(Map map, TweenCallback callbackCreateNewQuestion)
    {
        this.map = map;
        this.callbackCreateNewQuestion = callbackCreateNewQuestion;
        particleCorrectAnswer = GameObject.FindGameObjectWithTag(Config.tags.particlesCorrectAnswer).GetComponent<ParticleAnswer>();
    }

    public Sprite GenerateAnswer()
    {
        int currectPackSpritesIndex;
        PackSprites packSpritesAnswer = packsSpritesPastAnswers.GetCurrentPackSpritesOnMap(out currectPackSpritesIndex);
        int spriteAnswerIndex;
        Sprite spriteAnswer = packSpritesAnswer.GetRandomSprite(out spriteAnswerIndex);
        packSpritesAnswer.RemoveSpriteAtIndex(spriteAnswerIndex);//removed so that there are no repetitions
        if (packSpritesAnswer.GetCountSprites() == 0)
        {
            packSpritesAnswer.ReloadSprites();
            packsSpritesPastAnswers.RemovePackSpritesAtIndex(currectPackSpritesIndex);
            map.packsSpritesOnMap.RemovePackSpritesAtIndex(currectPackSpritesIndex);
        }
        if (packsSpritesPastAnswers.GetCountPacksSprites() == 0)
        {
            packsSpritesPastAnswers.ReloadPacksSprites();
            map.packsSpritesOnMap.ReloadPacksSprites();
        }   
        return spriteAnswer;
    }

    public void CorrectAnswer(Transform transformSpriteInCell)
    {
        Config.DisableEventSystem();
        map.cellEffector.BounceEffect(transformSpriteInCell, startScale: 1, callbackCreateNewQuestion);
        particleCorrectAnswer.SpawnParticleAnswer(transformSpriteInCell.position, map.GetMapScale());
    }

    public void IncorrectAnswer(Transform transformSpriteInCell)
    {
        map.cellEffector.EaseInBounce(transformSpriteInCell);
    }
}