using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

	public Text outputText;
	public Text memoryText;
	public GameObject buttonHolder;
	// Use this for initialization
	void Start () {
		if(!isReset) CEPressed();
	}

	//the total stored in the memory
	double total=0;

	//the current number to be used in operations
	double number=0;

	//the current operation
	public enum OPERATION { NONE, PLUS, TIMES, MINUS, DIVIDE ,EQUALS};
	OPERATION operation = OPERATION.NONE;

	//indicates that you can type in a new number
	bool newNumber=true;

	int getDigits(string s){
		int n=s.Length;
		if(s.Contains("-")) n--;
		if(s.Contains (".")) n--;
		return n;
	}

	public void NumberPressed(int N){
		if(N==0 && outputText.text=="0") return;
		if(newNumber) outputText.text = ""+N;
		else {
			if( getDigits(outputText.text)>=8) return;
			outputText.text +=""+N;
		}
		number = double.Parse(outputText.text);
		newNumber=false;
	}


	public void DotPressed(){
		if(outputText.text.Contains(".")) return;
		outputText.text +=".";
		number = double.Parse(outputText.text);
		newNumber=false;
	}



	void ShowOutput(){
		outputText.text = formatNumber (number);
		if(memory==0) memoryText.text="";
		else memoryText.text="M";
	}

	void ShowTotal(){
		outputText.text = formatNumber (total);
		if(memory==0) memoryText.text="";
		else memoryText.text="M";
	}

	string formatNumber(double n){
		if(System.Math.Abs (n)<1) return n.ToString ("0.#######");
		if(System.Math.Abs (n)>99999999 && !double.IsInfinity(n)) return ""+double.NaN;
		return n.ToString ("G8");
	}

	public void CPressed(){
		number=0;
		newNumber = true;
		lastEquals = false;
		ShowOutput();
	}

	public void CEPressed(){
		total = 0;
		number = 0;
		newNumber = true;
		memory = 0;
		lastEquals = false;
		operation = OPERATION.NONE;
		ShowOutput();
	}
	double memory = 0;

	public void MPlusPressed(){
		memory += number;
		newNumber = true;
		ShowOutput();
	}

	public void MMinusPressed(){
		memory -= number;
		newNumber = true;
		ShowOutput();
	}

	public void MRPressed(){
		number = memory;
		newNumber = true;
		ShowOutput();
	}

	public void MCPressed(){
		memory = 0;
		ShowOutput ();
	}

	public void PercentPressed(){
		number = (total * number)/100.0f;
		ShowOutput ();
		newNumber = true;
	}

	public void PlusPressed(){
		updateTotal();
		operation = OPERATION.PLUS;
	}
	public void MinusPressed(){
		updateTotal();
		operation = OPERATION.MINUS;
	}

	public void DividePressed(){
		updateTotal();
		operation = OPERATION.DIVIDE;
	}

	public void TimesPressed(){
		updateTotal();
		operation = OPERATION.TIMES;
	}

	public void SqrtPressed(){
		number = System.Math.Sqrt(double.Parse(outputText.text));
		ShowOutput ();
		newNumber = true;
	}

	public void PMPressed(){
		number = -double.Parse(outputText.text);
		ShowOutput();
	}

	public void OperatorPressed(OPERATION o){
		updateTotal();
		operation = o;
	}
	public void EqualsPressed(){
		lastEquals = false;
		updateTotal ();
		lastEquals = true;
	}
	
	bool lastEquals=false;

	void updateTotal(){
		if(!lastEquals)
		switch(operation){
		case OPERATION.PLUS:
			total+=number;
			break;
		case OPERATION.TIMES:
			total*=number;
			break;
		case OPERATION.DIVIDE:
			total/=number;
			break;
		case OPERATION.MINUS:
			total-=number;
			break;
		case OPERATION.NONE:
			total=number;
			break;
		}
		ShowTotal ();
		//number=0;
		newNumber = true;
		lastEquals = false;
	}

	public void OKButtonPressed(){
		if(OKcallback!=null) OKcallback( outputText.text );
	}

	bool isReset=false;

	public void reset(double f){
		isReset = true;
		CEPressed();
		outputText.text = formatNumber(f);
		number = f;
		newNumber = true;
	}

	public delegate void VoidToString(string f);

	public VoidToString OKcallback;

	
	// Update is called once per frame
	void Update () {
		//Keypresses. The keycode is stores in the ButtonSetup class
		if(Input.anyKeyDown){
			foreach(Transform t in buttonHolder.transform){
				if(Input.GetKeyDown (t.gameObject.GetComponent<ButtonSetup>().keycode) ){
					t.gameObject.GetComponent<Button>().OnPointerClick (
						new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current));
				}
			}

		}
	}
}
