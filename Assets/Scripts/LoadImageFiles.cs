using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadImageFiles : MonoBehaviour
{
    #region Fields
    
    [SerializeField] ImageFileData imageFileData;
    [SerializeField] string resourceFolder;
    string directoryAddress;
    int lastIndexOfDirectoryString;

    #endregion

    void Awake()
    {
        directoryAddress = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\" + resourceFolder;
        lastIndexOfDirectoryString = directoryAddress.Length + 1 ;
    }

    void Start()
    {
        LoadImageFromDirectory();
    }

    public void LoadImageFromDirectory()
    {
        if (!Directory.Exists(directoryAddress))
            return;

        imageFileData.ImageDatas.Clear();
        imageFileData.ImageDatas = getFileDataFromDirectory(directoryAddress);
       
        OnLoadingImagesDone?.Invoke();
    }

    List<ImageData> getFileDataFromDirectory(string address)
    {
        List<ImageData> fileData = new List<ImageData>();
        string[] fileAdresses = Directory.GetFiles(address, "*.png");

        foreach (string fileAddress in fileAdresses)
        {
            string filename = getFileNameFromFullDirectory(fileAddress);
            fileData.Add(new ImageData(Resources.Load<Sprite>(resourceFolder + "\\" + filename), filename, Directory.GetCreationTime(fileAddress).ToString()));
        }
        
        return fileData;
    }

    string getFileNameFromFullDirectory(string FileAddress)
    {
        string fullFileName = FileAddress.Substring(lastIndexOfDirectoryString);
        return (fullFileName.Substring(0, fullFileName.Length - 4));
    }

    //--------Actions------------
    public static Action OnLoadingImagesDone;
}
