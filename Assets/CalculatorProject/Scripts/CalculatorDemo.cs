using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalculatorDemo : MonoBehaviour {

	public Calculator calc;
	public Text numberText;

	// Use this for initialization
	void Start () {
		calc.OKcallback = delegate(string f) {
			numberText.text = f;
			//(can use float.Parse(f) to get floating point number)

			//now close the calculator
			calc.gameObject.SetActive(false);
		};
	}

	//This is called when the calculator icon is clicked
	public void OnCalcButtonPressed(){
		calc.gameObject.SetActive(true);
		//set the value of the calculator to something
		calc.reset(0);
	}


}
