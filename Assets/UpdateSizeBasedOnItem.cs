using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSizeBasedOnItem : MonoBehaviour
{
    [SerializeField] CanvasScaler canvasscalar;
    RectTransform rectTransform;
    [SerializeField] ImageFileData imageFileToRead;

    [SerializeField] float cellHeight;
    [SerializeField] int itemsInEachRow;

    Vector2 defaultAnchoredPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        defaultAnchoredPosition = rectTransform.anchoredPosition;

        Vector2 cellSize;
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        cellSize = new Vector2(gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x, gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y);
        cellHeight = cellSize.y;
        itemsInEachRow = Mathf.RoundToInt(canvasscalar.referenceResolution.x / cellSize.x);
    }

    void OnEnable()
    {
        LoadItems.OnImagesLoaded += updateRectSize;
    }

    void updateRectSize()
    {
        print($"Old Size: {rectTransform.sizeDelta}");
        Vector2 newSize = rectTransform.sizeDelta;
        newSize.y = cellHeight * (imageFileToRead.ImageDatas.Count / itemsInEachRow);
        rectTransform.sizeDelta = newSize;
        rectTransform.anchoredPosition = defaultAnchoredPosition;

        print($"new Size: {rectTransform.sizeDelta}");

    }

    void OnDisable()
    {
        LoadItems.OnImagesLoaded -= updateRectSize;
    }
}
