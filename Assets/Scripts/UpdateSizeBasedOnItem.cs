using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSizeBasedOnItem : MonoBehaviour
{
    #region Fields

    [SerializeField] CanvasScaler canvasscalar;
    [SerializeField] ImageFileData imageFileToRead;
    float cellHeight;
    int itemsInEachRow;
    RectTransform rectTransform;

    #endregion

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        Vector2 cellSize;
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        cellSize = new Vector2(gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x, gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y);
        cellHeight = cellSize.y;
        itemsInEachRow = Mathf.RoundToInt(canvasscalar.referenceResolution.x / cellSize.x);
    }

    void OnEnable()
    {
        LoadImageFiles.OnLoadingImagesDone += updateRectSize;
    }

    void updateRectSize()
    {
        Vector2 newSize = rectTransform.sizeDelta;
        int rowNumber = (imageFileToRead.ImageData.Count % itemsInEachRow == 0) ? imageFileToRead.ImageData.Count / itemsInEachRow : (imageFileToRead.ImageData.Count / itemsInEachRow)+1;
        newSize.y = cellHeight * rowNumber;
        rectTransform.sizeDelta = newSize;
        rectTransform.localPosition = new Vector2(0, -(newSize.y / 2));
    }

    void OnDisable()
    {
        LoadImageFiles.OnLoadingImagesDone -= updateRectSize;
    }
}
