using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchivementButtonUI : MonoBehaviour {

    public int id;
    public Image container;
    private string url;

    public void LoadImage(string _url)
    {
        this.url =  @"file://" + @"images\achievements\" + _url;
        StartCoroutine("LoadRoutine");        
    }
    private IEnumerator LoadRoutine()
    {
        print("LoadImages url: " + url);
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            container.sprite = null;
        }
        else
        {
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100.0f);
            container.sprite = sprite;
        }
    }
}
