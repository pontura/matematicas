using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class ClothesSettings : MonoBehaviour {

    public List<string> clothes;
    public List<string> legs;
    public List<string> shoes;
    public List<string> skin;
    public List<string> hairs;
    public List<string> npc;


	void Start () {
        LoadArray(clothes, @"images\clothes\");
        LoadArray(legs, @"images\legs\");
        LoadArray(shoes, @"images\shoes\");
        LoadArrayHairs(hairs, @"images\hair\");
     //   LoadArrayHairs(skin, @"images\skin\");
	}

    private void LoadArray(List<string> arr, string path)
    {
        path = Events.GetPathBySystem(path);

        string lastName = "";

        foreach (string name in System.IO.Directory.GetFiles(path, "*.png"))
        {
            String[] textSplit = name.Split("."[0])[0].Split("_"[0]);

            string realName = textSplit[0] + "_" + textSplit[1];
            // print(name + "           " + textSplit.Length);
            realName = AddSex(realName);
            if (realName != "" && realName != lastName)
            {
                arr.Add(realName);
                lastName = realName;
            }
        }
    }
    private void LoadArrayHairs(List<string> arr, string path)
    {
        path = Events.GetPathBySystem(path);

        string lastName = "";

        foreach (string name in System.IO.Directory.GetFiles(path, "*.png"))
        {
            String[] textSplit = name.Split("."[0])[0].Split("_"[0]);

            
            string realName = textSplit[0] + "_" + textSplit[1] + "_" + textSplit[2];
            // print(name + "           " + textSplit.Length);
            realName = AddSex(realName);
            if (realName != "" && realName != lastName)
            {
                arr.Add(realName);
                lastName = realName;
            }
        }
    }
    private string AddSex(string text)
    {
        if (text.Contains("boys"))
            return text.Replace("boys", "_SEX_");
        else
            return "";
    }
}
