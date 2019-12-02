using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text Timer, Score;
	private GameObject G1,G2;
	private GameObject G1_Smile,G2_Smile;
	float Delay = 1.0f;
	public Camera m_MainCamera;

	public static bool isTreatment = false, CheckGirl_1 = false, CheckGirl_2 = false;// CheckGirl_3 = false;
	int intScore = 0;
	float timeLeft = 60.0f;
	// Use this for initialization
	void Start () {
		isTreatment = false; CheckGirl_1 = false; CheckGirl_2 = false; //CheckGirl_3 = false;
		intScore = 0;
		timeLeft = 60.0f;

		G1 = GameObject.Find ("Hipppo_Sick");G2 = GameObject.Find ("Panda_Sick");//G3 = GameObject.Find ("Scene_02_Character_3");
		G1_Smile = GameObject.Find ("Hipppo_Happy");G2_Smile = GameObject.Find ("Panda_Happy");//G3_Smile = GameObject.Find ("Scene_02_Character_3_Smile");

		G1_Smile.SetActive (false);G2_Smile.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (m_MainCamera.transform.position, m_MainCamera.transform.forward);
		if (Physics.Raycast (landingRay, out hit, 10)) {
			print (hit.collider.name);
			if (isTreatment == true) {
				
				if((hit.collider.name == "Hipppo_Sick" )&& CheckGirl_1 == false){
					StartCoroutine(FuncGirl_1());

				}
				if((hit.collider.name == "Panda_Sick")&& CheckGirl_2 == false){
					StartCoroutine(FuncGirl_2());

				}
					
			}


		}


		Score.text ="000"+ intScore;

		timeLeft -= Time.deltaTime;
		int timeTemp = Mathf.RoundToInt (timeLeft);
		if(timeTemp >= 10)
		{
			Timer.text = "00:" + timeTemp;
		}else if(timeTemp < 10){
			Timer.text = "00:0" + timeTemp;
		}

		if(timeTemp < 0 || timeTemp < 1){
			Timer.text = "00:0" + timeTemp;
			//Application.LoadLevel("Scene_04");
		}

		if(intScore == 3){
			//Application.LoadLevel("Scene_03");
		}
	}

	public void TreatementButton(){
		isTreatment = true;
	}

	IEnumerator FuncGirl_1()
	{
		//Girl_1.sprite = PGirl_1;
		isTreatment = false;
		CheckGirl_1 = true;

		G1.SetActive (false);
		//G1_Blash.SetActive (true);
		yield return new WaitForSeconds(Delay);
		//G1_Blash.SetActive (false);
		G1_Smile.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G1_Smile.SetActive (false);


		intScore++;
	}


	IEnumerator FuncGirl_2()
	{

		isTreatment = false;
		CheckGirl_2 = true;
		//Girl_2.sprite = PGirl_2;

		G2.SetActive (false);
		//G2_Blash.SetActive (true);
		yield return new WaitForSeconds(Delay);
		//G2_Blash.SetActive (false);
		G2_Smile.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G2_Smile.SetActive (false);


		intScore++;
	}
		
}
