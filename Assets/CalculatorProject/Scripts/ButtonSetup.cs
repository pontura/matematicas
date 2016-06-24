using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ButtonSetup : MonoBehaviour {
	public string buttonText;
	public KeyCode keycode;
	// Use this for initialization
	void Start () {
		transform.Find ("Text").GetComponent<Text>().text = buttonText;
	}
	// Uncomment for quick initialization in editor
	// Update is called once per frame
	void Update () {
		transform.Find ("Text").GetComponent<Text>().text = buttonText;
	}

}
