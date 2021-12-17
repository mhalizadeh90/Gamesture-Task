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
        LoadItems.OnImagesLoaded += updateRectSize;
    }

    void updateRectSize()
    {
        //print($"Old Size: {rectTransform.sizeDelta}");
        Vector2 newSize = rectTransform.sizeDelta;
        int rowNumber = (imageFileToRead.ImageDatas.Count % itemsInEachRow == 0) ? imageFileToRead.ImageDatas.Count / itemsInEachRow : (imageFileToRead.ImageDatas.Count / itemsInEachRow)+1;
        newSize.y = cellHeight * rowNumber;
        rectTransform.sizeDelta = newSize;
        print($"OLD position: {rectTransform.position}");


        rectTransform.localPosition = new Vector2(0, -(newSize.y / 2));
        print($"New position: {rectTransform.position}");
        //print($"new Size: {rectTransform.sizeDelta}");

    }

    void OnDisable()
    {
        LoadItems.OnImagesLoaded -= updateRectSize;
    }
}
