using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Image Data", menuName = "Scriptable Objects/Image Data")]
public class ImageFileData : ScriptableObject
{
    public List<ImageData> ImageData;
}
