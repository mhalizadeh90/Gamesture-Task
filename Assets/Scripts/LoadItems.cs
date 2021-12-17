using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    [SerializeField] string resourceFolder;
    [SerializeField] string fullDirectory;
    
    [SerializeField] ImageFileData imageFileData;

    int lastIndex;

    void Awake()
    {
        fullDirectory = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\" + resourceFolder;
        lastIndex = fullDirectory.Length + 1 ;
    }

    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Load();
        }
    }

    public void Load()
    {
        imageFileData.ImageDatas.Clear();

        print("Loading Items...");
        //-----------------------------------

        SearchByDirectory();
    }

    private void SearchByDirectory()
    {
        if (!Directory.Exists(fullDirectory))
            return;

        string[] fileInfo = Directory.GetFiles(fullDirectory, "*.png");

        foreach (string file in fileInfo)
        {
            string filename = file.Substring(lastIndex);
            string namewithoutformat = filename.Substring(0, filename.Length - 4);
            string finalPath = resourceFolder + "\\" + namewithoutformat;
           
    //        print("===============");

            imageFileData.ImageDatas.Add(new ImageData(Resources.Load<Sprite>(finalPath), namewithoutformat, Directory.GetCreationTime(file).ToString()));
        }

        //TODO: CALL EVENT TO START REPLACING THESE DATA TO SCREEN
        OnImagesLoaded?.Invoke();
    }

    public static Action OnImagesLoaded;
}
