using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIFromDirectory : MonoBehaviour
{
    #region Fields

    [SerializeField] ImageFileData imageFileToRead;
    [SerializeField] GameObject UIImagePrefab;
    List<SetImageData> imagesData = new List<SetImageData>();

    #endregion

    void OnEnable()
    {
        LoadImageFiles.OnLoadingImagesDataDone += updateUI;
    }

    void updateUI()
    {
        DisableAllUIObjectsInPool();
        ExpandUIObjectPool();

        for (int i = 0; i < imageFileToRead.ImageData.Count; i++)
        {
            imagesData[i].updateCreationData(imageFileToRead.ImageData[i].imageCreationDate);
            imagesData[i].updateImageSource(imageFileToRead.ImageData[i].imageFile);
            imagesData[i].updateName(imageFileToRead.ImageData[i].imageName);

            imagesData[i].gameObject.SetActive(true);
        }
    }

    private void ExpandUIObjectPool()
    {
        while (imagesData.Count < imageFileToRead.ImageData.Count)
        {
            imagesData.Add(Instantiate<GameObject>(UIImagePrefab, transform).GetComponent<SetImageData>());
        }
    }

    private void DisableAllUIObjectsInPool()
    {
        for (int i = 0; i < imagesData.Count; i++)
        {
            imagesData[i].gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        LoadImageFiles.OnLoadingImagesDataDone -= updateUI;
    }
}
