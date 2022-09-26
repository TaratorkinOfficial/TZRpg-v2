using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FinderTextures
{
    private int countL;
    private List<SpriteRenderer> textures;
    private List<GameObject> images;
    private List<GameObject> imagesChar;
    private GameObject panel;
    public void CreateImages()
    {
        images = null;
        panel = GameObject.FindGameObjectWithTag("panel");
        textures = Resources.LoadAll<SpriteRenderer>("References").ToList();
        countL = textures.Count;
        images = new List<GameObject>(countL);
        for (int i = 0; i < countL; i++)
        {
            images.Add(new GameObject("Char" + (i + 1)));
            images[i].transform.SetParent(panel.transform);
            images[i].transform.tag = "charIm";
            images[i].AddComponent<Image>().sprite = textures[i].sprite;
            images[i].transform.localScale = new Vector3(1, 1, 1);
            images[i].GetComponent<Image>().preserveAspect = true;
        }
    }

    public void HighliahtChar(int i)
    {
        imagesChar = GameObject.FindGameObjectsWithTag("charIm").ToList();
        for (int j = 0; j < countL; j++)
        {
            imagesChar[j].GetComponent<Image>().color = Color.white;
        }
        imagesChar[i].GetComponent<Image>().color = Color.green;
    }
}
