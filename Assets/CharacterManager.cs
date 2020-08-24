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
    public SpriteRenderer[] hairsContainer;
    

    GameObject[] gameObj;
    Texture2D[] textList;

    
    private string pathPreFix;
    private ClothesSettings clothSettings;
    private SavedSettings savedSettings;
    private string sex;

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
    public void ChangeHair(bool next)
    {
        savedSettings.myPlayerSettings.hairs = ChangeCloth(clothSettings.hairs, next, savedSettings.myPlayerSettings.hairs);
    }
    public void SetSex(SavedSettings.PlayerSettings.sexType type)
    {
        sex = "boys";
        if (type == SavedSettings.PlayerSettings.sexType.MUJER) sex = "girls";
    }
    private string pathTemp;

    public int ChangeCloth(List<string> arr, bool next, int idNum)
    {
        if (next) idNum++;
        else idNum--;
        if (idNum < 0) idNum = arr.Count - 1;
        else if (idNum > arr.Count-1) idNum = 0;

        SetCloth(arr, idNum, false);

        return idNum;
    }
    public void SetCloth(List<string> arr, int idNum, bool npc = false)
    {
        pathPreFix = @"file://";
        clothSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        if (arr == clothSettings.clothes)
        {
            string path = "";
            
            if (npc)
				path = Events.GetPathBySystem( pathPreFix + @"images\npc\clothes\npcTop_" + clothSettings.npc[idNum] );
            else 
                path =  pathPreFix + clothSettings.clothes[idNum];


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
            string path = "";
            if (npc)
				path = Events.GetPathBySystem( pathPreFix + @"images\npc\clothes\npcBottom_" + clothSettings.npc[idNum] );
            else 
                path = pathPreFix + clothSettings.legs[idNum];
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
            pathTemp = path + "_skirt.png";
            StartCoroutine("LoadImages", legsContainer[5]);
        }
        else if (arr == clothSettings.shoes)
        {
            string path = "";
            if (npc)
				path = Events.GetPathBySystem( pathPreFix + @"images\npc\clothes\npcShoes_" + clothSettings.npc[idNum] );
            else
                path = pathPreFix + clothSettings.shoes[idNum];
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
            string path = Events.GetPathBySystem( pathPreFix + @"images\skin\");
            idNum += 1;

            string sex_skin = "boys_boy";
            if (sex == "girls") sex_skin = "girls_girl";

            pathTemp = path + sex_skin + "_head_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[0]);
            pathTemp = path + sex_skin + "_nose_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[1]);
            pathTemp = path + sex_skin + "_torax_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[2]);

            pathTemp = path + sex_skin + "_arm1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[3]);
            pathTemp = path + sex_skin + "_arm1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[4]);
            pathTemp = path + sex_skin + "_hand1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[5]);
            pathTemp = path + sex_skin + "_hand1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[6]);


            pathTemp = path + sex_skin + "_arm2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[7]);
            pathTemp = path + sex_skin + "_arm2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[8]);
            pathTemp = path + sex_skin + "_hand2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[9]);
            pathTemp = path + sex_skin + "_hand2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[10]);

            pathTemp = path + sex_skin + "_leg1a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[11]);
            pathTemp = path + sex_skin + "_leg1b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[12]);
            pathTemp = path + sex_skin + "_foot1_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[13]);

            pathTemp = path + sex_skin + "_leg2a_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[14]);
            pathTemp = path + sex_skin + "_leg2b_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[15]);            
            pathTemp = path + sex_skin + "_foot2_skin" + idNum + ".png";
            StartCoroutine("LoadImages", skinContainer[16]);

        }
        else if (arr == clothSettings.hairs)
        {
            string path = "";
            if (npc)
				path = Events.GetPathBySystem( pathPreFix + @"images\npc\hair\npcHair_" + clothSettings.npc[idNum] + "_color1" );
            else
                path = pathPreFix + clothSettings.hairs[idNum];

            pathTemp = path + "_1.png";
            StartCoroutine("LoadImages", hairsContainer[0]);
            pathTemp = path + "_2.png";
            StartCoroutine("LoadImages", hairsContainer[1]);
        }
    }
    public void ChangeColor(bool next)
    {

    }
    public void SetColor(int colorID)
    {

    }


    private IEnumerator LoadImages(SpriteRenderer spriteContainer)
    {
        pathTemp = pathTemp.Replace("_SEX_", sex);

        WWW www = new WWW(Events.OnGetFilePath(pathTemp));

        yield return www;

        if (www.error != null)
        {
            spriteContainer.sprite = null;
        } else
        {

            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);

            spriteContainer.sprite = sprite;
        }
    }
}
