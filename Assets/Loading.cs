using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Loading : MonoBehaviour {

    public Image masker;

	void Start () {
        masker.gameObject.SetActive(false);
        Events.OnLoading += OnLoading;
	}
    void OnDestroy()
    {
        Events.OnLoading -= OnLoading;
    }
    void OnLoading()
    {
        masker.gameObject.SetActive(true);
        masker.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeStart());
    }
    private IEnumerator FadeStart()
    {
        float t = 1;
        //while (t < 1)
        //{
        //    yield return new WaitForEndOfFrame();
        //    t += Time.deltaTime;
        //    masker.color = new Color(0, 0, 0, t);
        //}
        while (t > 0f)
        {
            yield return new WaitForEndOfFrame();
            t -= Time.deltaTime;
            masker.color = new Color(0, 0, 0, t);
        }
        masker.gameObject.SetActive(false);
    }
}
