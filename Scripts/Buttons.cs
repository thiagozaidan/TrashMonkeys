using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttons : MonoBehaviour {

	public Button playGame; 
	public Button settings;
	public Button credits;

	void Start () {
		Button btn = playGame.GetComponent<Button>();
		btn.onClick.AddListener(ChamaJogo);	

		Button btn1 = settings.GetComponent<Button>();
		btn1.onClick.AddListener(ChamaConf);	

		Button btn2 = credits.GetComponent<Button>();
		btn2.onClick.AddListener(ChamaCred);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChamaJogo(){
		SceneManager.LoadScene(0);
	}

	void ChamaConf(){
		SceneManager.LoadScene(3);
	}
	
	void ChamaCred(){
		SceneManager.LoadScene(4);
	}
}
