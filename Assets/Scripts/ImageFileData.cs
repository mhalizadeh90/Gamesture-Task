using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Image Data", menuName = "Scriptable Objects/Image Data")]
public class ImageFileData : ScriptableObject
{
    public List<ImageData> ImageDatas;
}

[System.Serializable]
public class ImageData
{
    public Sprite imageFile;
    public string imageName;
    public string imageCreationDate;

    public ImageData(Sprite image, string name, string date)
    {
        imageFile = image;
        imageName = name;
        imageCreationDate = date;
    }
}
