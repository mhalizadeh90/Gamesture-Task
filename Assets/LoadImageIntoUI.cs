using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImageIntoUI : MonoBehaviour
{

    [SerializeField] ImageFileData imageFileToRead;
    [SerializeField] GameObject imagePrefab;
    List<SetImageData> allImages = new List<SetImageData>();


    void OnEnable()
    {
        LoadItems.OnImagesLoaded += LoadImagesIntoUI;
    }

    void LoadImagesIntoUI()
    {
        for (int i = 0; i < allImages.Count; i++)
        {
            allImages[i].gameObject.SetActive(false);
        }
        while (allImages.Count < imageFileToRead.ImageDatas.Count)
        {
            allImages.Add(Instantiate<GameObject>(imagePrefab, transform).GetComponent<SetImageData>());
        }

        for (int i = 0; i < allImages.Count; i++)
        {
            allImages[i].SetCreationData(imageFileToRead.ImageDatas[i].imageCreationDate);
            allImages[i].SetImage(imageFileToRead.ImageDatas[i].imageFile);
            allImages[i].SetName(imageFileToRead.ImageDatas[i].imageName);

            allImages[i].gameObject.SetActive(true);

        }
    }


    void OnDisable()
    {
        LoadItems.OnImagesLoaded -= LoadImagesIntoUI;
    }
}
