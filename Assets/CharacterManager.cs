using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
 

public class CharacterManager : MonoBehaviour {


    public SpriteRenderer[] skinContainer;
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
        savedSettings.myPlayerSettings.shoes = ChangeCloth(clothSettings.shoes, next, savedSettings.myPlayerSettings.shoes);
    }
    public void ChangeSkin(bool next)
    {
        savedSettings.myPlayerSettings.skin = ChangeCloth(clothSettings.skin, next, savedSettings.myPlayerSettings.skin);
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
        else if (arr == clothSettings.legs)
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
        else if (arr == clothSettings.shoes)
        {
            string path = pathPreFix + clothSettings.shoes[idNum];
            //boysShoes_A_1a
            pathTemp = path + "_1a.png";
            StartCoroutine("LoadImages", shoesContainer[0]);
            pathTemp = path + "_1b.png";
            StartCoroutine("LoadImages", shoesContainer[1]);
            pathTemp = path + "_2a.png";
            StartCoroutine("LoadImages", shoesContainer[2]);
            pathTemp = path + "_2b.png";
            StartCoroutine("LoadImages", shoesContainer[3]);
        }
        else if (arr == clothSettings.skin)
        {
            string path = pathPreFix + @"images\skin\";
            idNum += 1;

            pathTemp = path + "boys_boy_head_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[0]);
            pathTemp = path + "boys_boy_nose_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[1]);
            pathTemp = path + "boys_boy_torax_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[2]);

            pathTemp = path + "boys_boy_arm1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[3]);
            pathTemp = path + "boys_boy_arm1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[4]);
            pathTemp = path + "boys_boy_hand1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[5]);
            pathTemp = path + "boys_boy_hand1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[6]);


            pathTemp = path + "boys_boy_arm2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[7]);
            pathTemp = path + "boys_boy_arm2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[8]);
            pathTemp = path + "boys_boy_hand2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[9]);
            pathTemp = path + "boys_boy_hand2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[10]);

            pathTemp = path + "boys_boy_leg1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[11]);
            pathTemp = path + "boys_boy_leg1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[12]);
            pathTemp = path + "boys_boy_foot1_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[13]);

            pathTemp = path + "boys_boy_leg2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[14]);
            pathTemp = path + "boys_boy_leg2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[15]);            
            pathTemp = path + "boys_boy_foot2_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[16]);

            
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
