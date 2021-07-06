using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellData : MonoBehaviour, IPointerClickHandler
{
    MapQuestionEventAnswer onCellClick;
    Transform transformInCell;
    SpriteRenderer spriteRenderInCell;
    public Transform cellTransform { get; private set; }
    public Sprite SpriteInCell
    {
        get
        {
            return spriteRenderInCell.sprite;
        }
        set
        {
            spriteRenderInCell.sprite = value;
        }
    }


    void Awake()
    {
        cellTransform = GetComponent<Transform>();
        transformInCell = GetComponentsInChildren<Transform>()[1];
        spriteRenderInCell = GetComponentsInChildren<SpriteRenderer>()[1];
    }

    public void SetOnCellClickEvent(MapQuestionEventAnswer onCellClick)
    {
        this.onCellClick = onCellClick;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onCellClick?.Invoke(transformInCell);
    }

    public void DestroyCell()
    {
        Destroy(gameObject);
    }
}