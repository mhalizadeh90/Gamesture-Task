using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    [SerializeField] string resourceFolder;
    [SerializeField] string fullDirectory;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    
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

        sprites.Clear();

        string[] fileInfo = Directory.GetFiles(fullDirectory, "*.png");

        foreach (string file in fileInfo)
        {
            //  print($"Creation Time: {Directory.GetCreationTime(file)}");
       //     print($"File: {file}");
            
            string filename = file.Substring(lastIndex);
            //print($"{filename} ==> Lenght {filename.Length} ");
            string namewithoutformat = filename.Substring(0, filename.Length - 4);
     //       print("Name without Format: "+namewithoutformat);
            string finalPath = resourceFolder + "\\" + namewithoutformat;
            sprites.Add(Resources.Load<Sprite>(finalPath));

    //        print("===============");

            imageFileData.ImageDatas.Add(new ImageData(Resources.Load<Sprite>(finalPath), namewithoutformat, Directory.GetCreationTime(file).ToString()));
        }

        //TODO: CALL EVENT TO START REPLACING THESE DATA TO SCREEN
        OnImagesLoaded?.Invoke();


        //if(sprites.Count > 0)
        //{
        //    UIImage.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        //}
        //UIText.text = fullDirectory;
    }

    public static Action OnImagesLoaded;
}
