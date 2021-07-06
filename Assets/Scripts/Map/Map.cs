using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    bool isMapCreated;
    MapData mapData;
    MapEditor editMap;
    ComplexityGridController complexityGrid = new ComplexityGridController();
    public PacksSpritesController packsSpritesOnMap { get; } = new PacksSpritesController();
    public CellEffects cellEffector { get; } = new CellEffects();


    public Map()
    {
        mapData = new MapData();
        editMap = new MapEditor(mapData);
    }

    public List<CellData> GetCellsData()
    {
        return mapData.cellsData;
    }

    public float GetMapScale()
    {
        return mapData.GetMapScale();
    }

    public bool CreateMap()
    {
        if (!isMapCreated)
        {
            editMap.DrawMapWithBounceEffect(complexityGrid.GetCurrentComplexity(), packsSpritesOnMap.GetRandomPackSprites(), cellEffector);
            isMapCreated = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RewriteMap()
    {
        if (isMapCreated)
        {
            editMap.DrawMap(complexityGrid.GetCurrentComplexity(), packsSpritesOnMap.GetRandomPackSprites());
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteMap()
    {
        if (isMapCreated)
        {
            editMap.EraseMap();
            isMapCreated = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// For the changes to take effect, you need to rewrite the map.
    /// </summary>
    public void UpLevelComplexityMap()
    {
        complexityGrid.IncreaseComplexity();
    }

    public bool IsMaxLevelComplexityMap()
    {
        return complexityGrid.IsMaxLevelComplexityGrid();
    }
}