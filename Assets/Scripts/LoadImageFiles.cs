using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadImageFiles : MonoBehaviour
{
    #region Fields
    
    [SerializeField] ImageFileData imageFileData;
    [SerializeField] string resourceFolder;
    int lastIndexOfDirectoryString;
    string directoryAddress;
    #endregion


    void Start()
    {
        directoryAddress = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\" + resourceFolder;
        lastIndexOfDirectoryString = directoryAddress.Length + 1;
        
        LoadImagesDataFromDirectory();
    }

    public void LoadImagesDataFromDirectory()
    {
        if (!Directory.Exists(directoryAddress))
            return;

        imageFileData.ImageData.Clear();
        imageFileData.ImageData = getFileDataFromDirectory();
       
        OnLoadingImagesDataDone?.Invoke();
    }

    List<ImageData> getFileDataFromDirectory()
    {
        List<ImageData> fileData = new List<ImageData>();
        string[] fileAdresses = Directory.GetFiles(directoryAddress, "*.png");

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
    public static Action OnLoadingImagesDataDone;
}
