using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageData : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dateText;
    [SerializeField] Image uiImage;
    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void SetCreationData(string date)
    {
        dateText.text = date;
    }

    public void SetImage(Sprite image)
    {
        uiImage.sprite = image;
    }
}
