using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    Transform map;
    public readonly Transform cellPrefab;
    public readonly List<CellData> cellsData = new List<CellData>();
    public readonly float maxWidthMap;
    public readonly float maxHeightMap;
    public readonly float stepHorizontal;
    public readonly float stepVertical;

    public MapData()
    {
        map = new GameObject("Map").transform; 
        cellPrefab = Resources.Load<GameObject>("Cell").transform;
        SpriteRenderer cellRender = cellPrefab.GetComponent<SpriteRenderer>();
        stepHorizontal = cellRender.sprite.rect.width / cellRender.sprite.pixelsPerUnit;
        stepVertical = cellRender.sprite.rect.height / cellRender.sprite.pixelsPerUnit;
        if (Screen.width >= Screen.height)
        {
            maxWidthMap = Screen.width * 0.45f / 100;
            maxHeightMap = Screen.height * 0.9f / 100;
        }
        else
        {
            maxWidthMap = Screen.width * 0.6f / 100;
            maxHeightMap = Screen.height * 0.6f / 100;
        }
    }

    public Transform GetInstantiateParent()
    {
        return map;
    }

    public float GetMapScale()
    {
        return map.localScale.x;
    }

    public void SetMapScale(float newScale)
    {
        map.localScale = new Vector3(newScale, newScale, 1);
    }

    public void SetMapPosition(Vector3 position)
    {
        map.position = position;
    }
}