using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
 

public class CharacterManager : MonoBehaviour {

    public GameObject[] skin;

    public SpriteRenderer[] clothesContainer;
    public SpriteRenderer[] shoesContainer;
    public SpriteRenderer[] legsContainer;
    

    GameObject[] gameObj;
    Texture2D[] textList;

    
    private string pathPreFix;
    private ClothesSettings clothSettings;
    private SavedSettings savedSettings;

    void Start()
    {
        pathPreFix = @"file://";
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

    }

    public void Idle()
    {
        GetComponent<Animator>().Play("Idle1", 0, 0);
    }
    public void ChangeClothes(bool next)
    {
        savedSettings.myPlayerSettings.clothes = ChangeCloth(clothSettings.clothes, next, savedSettings.myPlayerSettings.clothes);
       // GetComponent<Animator>().Play("face1", 0, 0);
    }
    public void ChangeLegs(bool next)
    {
        savedSettings.myPlayerSettings.legs = ChangeCloth(clothSettings.legs, next, savedSettings.myPlayerSettings.legs);
    }

    public void ChangeShoes(bool next)
    {
    }
    public void ChangeTop(bool next)
    {
       
    }
    public void ChangeHair(bool next)
    {
    
    }
    public void ChangeFaces(bool next)
    {
       
    }
    private string pathTemp;

    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count-1) idNum = 0;

        SetCloth(arr, idNum);

        return idNum;
    }
    public void SetCloth(List<string> arr, int idNum)
    {
        pathPreFix = @"file://";
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        

        if (arr == clothSettings.clothes)
        {
            string path =  pathPreFix + clothSettings.clothes[idNum];
            //boysTop_B_torax1
            pathTemp = path + "_torax1.png";
            StartCoroutine("LoadImages", clothesContainer[0]);
            pathTemp = path + "_torax2.png";
            StartCoroutine("LoadImages", clothesContainer[1]);
            pathTemp = path + "_arm1a.png";
            StartCoroutine("LoadImages", clothesContainer[2]);
            pathTemp = path + "_arm1b.png";
            StartCoroutine("LoadImages", clothesContainer[3]);
            pathTemp = path + "_arm2a.png";
            StartCoroutine("LoadImages", clothesContainer[4]);
            pathTemp = path + "_arm2b.png";
            StartCoroutine("LoadImages", clothesContainer[5]);
        }
        if (arr == clothSettings.legs)
        {
            string path = pathPreFix + clothSettings.legs[idNum];
            //boysTop_B_torax1
            pathTemp = path + "_hips.png";
            StartCoroutine("LoadImages", legsContainer[0]);
            pathTemp = path + "_leg1a.png";
            StartCoroutine("LoadImages", legsContainer[1]);
            pathTemp = path + "_leg1b.png";
            StartCoroutine("LoadImages", legsContainer[2]);
            pathTemp = path + "_leg2a.png";
            StartCoroutine("LoadImages", legsContainer[3]);
            pathTemp = path + "_leg2b.png";
            StartCoroutine("LoadImages", legsContainer[4]);
        }

        print(pathTemp);
        //if (arr == clothSettings.arm)
        //{
        //    pathTemp = pathPreFix + clothSettings.arm[idNum] + ".png";
        //    StartCoroutine("LoadImages", shoesContainer[0]);
        //    StartCoroutine("LoadImages", shoesContainer[1]);
        //}
        //else if (arr == clothSettings.faces)
        //{
        //    pathTemp = pathPreFix + clothSettings.faces[idNum] + ".png";
        //    StartCoroutine("LoadImages", HeadContainer[0]);
        //}
        //else if (arr == clothSettings.tops)
        //{
        //    pathTemp = pathPreFix + clothSettings.tops[idNum] + "_a.png";
        //    StartCoroutine("LoadImages", BodyContainer[0]);

        //    pathTemp = pathPreFix + clothSettings.tops[idNum] + "_b.png";
        //    StartCoroutine("LoadImages", Arm1Container[0]);
        //    StartCoroutine("LoadImages", Arm1Container[1]);

        //    pathTemp = pathPreFix + clothSettings.tops[idNum] + "_c.png";
        //    StartCoroutine("LoadImages", Arm2Container[0]);
        //    StartCoroutine("LoadImages", Arm2Container[1]);

        //    pathTemp = pathPreFix + clothSettings.tops[idNum] + "_d.png";
        //    StartCoroutine("LoadImages", Arm3Container[0]);
        //    StartCoroutine("LoadImages", Arm3Container[1]);
        //}
        //else if (arr == clothSettings.legs)
        //{
        //    pathTemp = pathPreFix + clothSettings.legs[idNum] + "_a.png";
        //    StartCoroutine("LoadImages", HipContainer[0]);

        //    pathTemp = pathPreFix + clothSettings.legs[idNum] + "_b.png";
        //    StartCoroutine("LoadImages", LegsContainer[0]);
        //    StartCoroutine("LoadImages", LegsContainer[1]);
        //}
        //else if (arr == clothSettings.hairs)
        //{
        //    pathTemp = pathPreFix + clothSettings.hairs[idNum] + "_a.png";
        //    StartCoroutine("LoadImages", Hair1Container[0]);

        //    pathTemp = pathPreFix + clothSettings.hairs[idNum] + "_b.png";
        //    StartCoroutine("LoadImages", Hair2Container[0]);
        //}
    }
    public void ChangeColor(bool next)
    {

    }
    public void SetColor(int colorID)
    {

    }


    private IEnumerator LoadImages(SpriteRenderer spriteContainer)
    {
       // print("loading: " + pathTemp);
        WWW www = new WWW(pathTemp);
        yield return www;

        if (www.error != null)
        {
            spriteContainer.sprite = null;
        } else
        {
            Sprite sprite = new Sprite();

            sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);

            spriteContainer.sprite = sprite;
        }
    }
}
