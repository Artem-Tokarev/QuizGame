using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacksSpritesController
{
    static int currentPackSpritesOnMap;
    PackSprites cookiesSprites = new PackSprites("Cookies/");
    PackSprites lettersSprites = new PackSprites("Letters/");
    List<PackSprites> collectionPacksSprites = new List<PackSprites>();

    public PacksSpritesController()
    {
        LoadingPacksSprites();
    }

    void LoadingPacksSprites()
    {
        collectionPacksSprites.Add(cookiesSprites);
        collectionPacksSprites.Add(lettersSprites);
    }

    public int GetCountPacksSprites()
    {
        return collectionPacksSprites.Count;
    }

    public PackSprites GetRandomPackSprites()
    {
        currentPackSpritesOnMap = Random.Range(0, collectionPacksSprites.Count);
        if (currentPackSpritesOnMap == collectionPacksSprites.Count)
            --currentPackSpritesOnMap;
        return collectionPacksSprites[currentPackSpritesOnMap];
    }

    public PackSprites GetCurrentPackSpritesOnMap(out int currentPackSpritesIndex)
    {
        currentPackSpritesIndex = currentPackSpritesOnMap;
        return collectionPacksSprites[currentPackSpritesOnMap];
    }

    public void RemovePackSpritesAtIndex(int packSpritesIndex)
    {
        collectionPacksSprites.RemoveAt(packSpritesIndex);
    }

    public void ReloadPacksSprites()
    {
        LoadingPacksSprites();
    }
}