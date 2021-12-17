using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadItems : MonoBehaviour
{
    [SerializeField] string resourceFolder;
    [SerializeField] string fullDirectory;
    [SerializeField] AudioClip[] audios;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] Image UIImage;
    [SerializeField] Text UIText;
    
    [SerializeField] ImageFileData imageFileData;

    int lastIndex;

    void Awake()
    {
        fullDirectory = Directory.GetCurrentDirectory() + "\\Assets\\Resources\\" + resourceFolder;
        lastIndex = fullDirectory.Length + 1 ;

        imageFileData.ImageDatas.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Load();
        }
    }

    void Load()
    {
        print("Loading Items...");
        //-----------------------------------

        SearchByDirectory();

        // print(Path.GetExtension(pathToGetExtension));

        //SearchByResourceFolder();
    }

    private void SearchByResourceFolder()
    {
        print("Current Directory: "+Directory.GetCurrentDirectory());

      //  sprites = Resources.LoadAll<Sprite>(resourceFolder);

        var items = Resources.LoadAll(resourceFolder);
        foreach (var item in items)
        {
            print(item.name);
        }
    }

    private void SearchByDirectory()
    {
        UIText.text = Directory.GetCurrentDirectory();

        if (!Directory.Exists(fullDirectory))
            return;

        sprites.Clear();

        string[] fileInfo = Directory.GetFiles(fullDirectory, "*.png");

        foreach (string file in fileInfo)
        {
            //  print($"Creation Time: {Directory.GetCreationTime(file)}");
            print($"File: {file}");
            
            string filename = file.Substring(lastIndex);
            //print($"{filename} ==> Lenght {filename.Length} ");
            string namewithoutformat = filename.Substring(0, filename.Length - 4);
            print("Name without Format: "+namewithoutformat);
            string finalPath = resourceFolder + "\\" + namewithoutformat;
            sprites.Add(Resources.Load<Sprite>(finalPath));

            print("===============");

            imageFileData.ImageDatas.Add(new ImageData(Resources.Load<Sprite>(finalPath), namewithoutformat, Directory.GetCreationTime(file).ToShortDateString()));
        }

        //TODO: CALL EVENT TO START REPLACING THESE DATA TO SCREEN

        if(sprites.Count > 0)
        {
            UIImage.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        }



        UIText.text = fullDirectory;
    }
}
