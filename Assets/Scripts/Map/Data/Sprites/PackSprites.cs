using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PackSprites
{
    string pathToSprites;
    List<Sprite> allSprites;

    public PackSprites(string resourcesPathToSprites)
    {
        pathToSprites = resourcesPathToSprites;
        allSprites = new List<Sprite>();
        allSprites.AddRange(Resources.LoadAll<Sprite>(pathToSprites));
    }

    public void ReloadSprites()
    {
        allSprites.AddRange(Resources.LoadAll<Sprite>(pathToSprites));
    }

    public List<Sprite> GetRandomSprites(int countSprites)
    {
        List<Sprite> randSprites = new List<Sprite>();
        for (int i = 0; i < countSprites; i++)
        {
            int rand = Random.Range(0, allSprites.Count - 1);
            randSprites.Add(allSprites[rand]);
            allSprites.RemoveAt(rand);
        }
        allSprites.AddRange(randSprites);
        return randSprites;
    }

    public Sprite GetRandomSprite(out int spriteIndex)
    {
        spriteIndex = Random.Range(0, allSprites.Count - 1);
        return allSprites[spriteIndex];
    }

    public int GetCountSprites()
    {
        return allSprites.Count;
    }

    public void RemoveSpriteAtIndex(int spriteIndex)
    {
        allSprites.RemoveAt(spriteIndex);
    }
}