using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor
{
    MapData mapData;

    public MapEditor(MapData mapData)
    {
        this.mapData = mapData;
    }

    public void DrawMapWithBounceEffect(ComplexityGrid complexity, PackSprites packSprites, CellEffects cellEffector)
    {
        DrawMap(complexity, packSprites);
        cellEffector.BounceEffect(mapData.cellsData);
    }

    public void DrawMap(ComplexityGrid complexity, PackSprites packSprites)
    {
        EraseMap();
        List<Sprite> sprites = packSprites.GetRandomSprites(complexity.GetCountCells());
        BuildingMap(complexity, sprites);
    }

    public void EraseMap()
    {
        if (mapData.cellsData.Count == 0)
            return;
        else
            for (int i = 0; i < mapData.cellsData.Count; i++)
                mapData.cellsData[i].DestroyCell();
        mapData.cellsData.Clear();
        mapData.SetMapScale(1);
        mapData.SetMapPosition(Vector3.zero);
    }

    void BuildingMap(ComplexityGrid complexity, List<Sprite> sprites)
    {
        for (int i = 0; i < complexity.countRow; i++)
        {
            float y = mapData.stepVertical * i;
            for (int j = 0; j < complexity.countColum; j++)
            {
                float x = mapData.stepHorizontal * j;
                InstantiateTilemap(sprites[0], new Vector3(x, y, 0));
                sprites.RemoveAt(0);
            }
        }
        AlignMap(complexity);
    }

    void InstantiateTilemap(Sprite sprite, Vector3 position)
    {
        Transform cell = MonoBehaviour.Instantiate(mapData.cellPrefab, mapData.GetInstantiateParent());
        cell.position = position;
        CellData cellData = cell.GetComponent<CellData>();
        cellData.SpriteInCell = sprite;
        mapData.cellsData.Add(cellData);
    }

    void AlignMap(ComplexityGrid complexity)
    {
        CalculateScaleMap(complexity, out float newScale);
        float stepHorizontal = mapData.stepHorizontal * newScale;
        float stepVertical = mapData.stepVertical * newScale;
        float countHorizontalSteps = (complexity.countColum - 1);
        float countVerticalSteps = (complexity.countRow - 1);
        float deltaMapPosX = (countHorizontalSteps / 2) * -1;
        float deltaMapPosY = (countVerticalSteps / 2) * -1;
        Vector3 mapPosToCenter = new Vector3(stepHorizontal * deltaMapPosX, stepVertical * deltaMapPosY, 0);
        mapData.SetMapPosition(mapPosToCenter);
    }

    void CalculateScaleMap(ComplexityGrid complexity, out float newScale)
    {
        float currentWidth = complexity.countColum * mapData.stepHorizontal;
        float currentHeight = complexity.countRow * mapData.stepVertical;
        float newWidth = (currentWidth > mapData.maxWidthMap) ? mapData.maxWidthMap / currentWidth : 1;
        float newHeight = (currentHeight > mapData.maxHeightMap) ? mapData.maxHeightMap / currentHeight : 1;
        newScale = (newWidth <= newHeight) ? newWidth : newHeight;
        mapData.SetMapScale(newScale);
    }
}