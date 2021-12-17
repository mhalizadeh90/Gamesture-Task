using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustScrollSizeBasedOnItemNumber : MonoBehaviour
{
    #region Fields

    [SerializeField] CanvasScaler canvasscalar;
    [SerializeField] ImageFileData imageFileToRead;
    float uiImageHeight;
    int uiImagesInRow;
    RectTransform rectTransform;

    #endregion

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        CalculateCellSizeOfUIImageFiles();
    }


    void OnEnable()
    {
        LoadImageFiles.OnLoadingImagesDataDone += AdjustScrollRect;
    }

    void AdjustScrollRect()
    {
        rectTransform.sizeDelta = GetScrollRectSizeBasedOnImageFilesNumber();
        rectTransform.localPosition = GetScrollRectPositionAtTopCenter();
    }

    private Vector2 GetScrollRectPositionAtTopCenter()
    {
        return new Vector2(0, -(rectTransform.sizeDelta.y / 2));
    }

    private Vector2 GetScrollRectSizeBasedOnImageFilesNumber()
    {
        Vector2 newSize = rectTransform.sizeDelta;
        int rowNumber = (imageFileToRead.ImageData.Count / uiImagesInRow) + (imageFileToRead.ImageData.Count % uiImagesInRow == 0 ? 0 : 1);
        newSize.y = uiImageHeight * rowNumber;
        return newSize;
    }

    private void CalculateCellSizeOfUIImageFiles()
    {
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        Vector2 uiImageSize = new Vector2(gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x, gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y);
        
        uiImageHeight = uiImageSize.y;
        uiImagesInRow = Mathf.RoundToInt(canvasscalar.referenceResolution.x / uiImageSize.x);
    }

    void OnDisable()
    {
        LoadImageFiles.OnLoadingImagesDataDone -= AdjustScrollRect;
    }
}
