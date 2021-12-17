using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageData : MonoBehaviour
{
    #region Fields

    [SerializeField] Text nameText;
    [SerializeField] Text dateText;
    [SerializeField] Image uiImage;

    #endregion

    public void updateName(string name)
    {
        nameText.text = name;
    }

    public void updateCreationData(string date)
    {
        dateText.text = date;
    }

    public void updateImageSource(Sprite image)
    {
        uiImage.sprite = image;
    }
}
