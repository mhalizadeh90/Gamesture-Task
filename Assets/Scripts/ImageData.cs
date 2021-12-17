using UnityEngine;

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
