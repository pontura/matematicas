using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class AdminEjercicios : MonoBehaviour
{
    public Text title;
    public AdminEjerciciosButton button;
    public Transform content;

    public List<Block> blocks;

    [Serializable]
    public class Block
    {
        public string id;
        public string title;
        public string result;
    }

    public void Init(UserData userdata)
    {
        Events.OnAdminLoading(true);
        blocks.Clear();
        title.text = "Ejercicios de : " + userdata.username;

        int num = content.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(content.transform.GetChild(0).gameObject);

        SocialEvents.OnGetEjercicios(userdata.userID, OnGetEjerciciosReady);
    }
    void OnGetEjerciciosReady(string result)
    {
        print("OnGetAlumnosReady" + result);
        Events.OnAdminLoading(false);
        string[] allData = Regex.Split(result, "</n>");

        for (var i = 0; i < allData.Length - 1; i++)
        {
            string[] userData = Regex.Split(allData[i], ":");
            
            Block block = new Block();

            block.title = userData[0];
            block.result = userData[1];
            
            block.id = i.ToString();
            blocks.Add(block);

            AdminEjerciciosButton newButton = Instantiate(button);
            newButton.transform.SetParent(content);
            newButton.transform.localScale = Vector2.one;
            newButton.Init(this, block);

        }
    }
    public void Clicked(Block block)
    {
        print("ejercicios de : " + block.title);
        GetComponent<AdminBlock>().Init(block);
    }
}
