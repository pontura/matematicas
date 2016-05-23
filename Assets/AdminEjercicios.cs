using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

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
        title.text = "Ejercicios de : " + userdata.username;
        string url = SocialManager.Instance.FIREBASE + "/block.json?orderBy=\"userID\"&equalTo=\"" + userdata.userID + "\"";

        Debug.Log(url);

        HTTP.Request someRequest = new HTTP.Request("get", url);
        someRequest.Send((request) =>
        {
            Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);

            if (decoded == null)
            {
                Debug.Log("no existe el user or malformed response ):");
                return;
            }
            else if (decoded.Count == 0)
            {
                //usuario nuevo manda email:
                // Events.OnUserRegistration();
                //Data.Instance.userData.OnRegistration(_username, _email, UnityEngine.Random.Range(10000, 99999).ToString(), "");
            }
            else
            {
                foreach (DictionaryEntry json in decoded)
                {
                    Hashtable jsonObj = (Hashtable)json.Value;
                    //Score s = new Score();
                    string _id = (string)json.Key.ToString();
                    string _title = (string)jsonObj["title"];
                    string _content = (string)jsonObj["content"];

                    print("id: " + _id + " title " + _title + " content" + _content);

                    Block block = new Block();
                    block.result = _content;
                    block.title = _title;
                    block.id = _id;
                    blocks.Add(block);

                    AdminEjerciciosButton newButton = Instantiate(button);
                    newButton.transform.SetParent(content);
                    newButton.transform.localScale = Vector2.one;
                    newButton.Init(this, block);
                }
            }
        });
    }
    public void Clicked(Block block)
    {
        print("ejercicios de : " + block.title);
        GetComponent<AdminBlock>().Init(block);
    }
}
