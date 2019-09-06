using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnMenu : MonoBehaviour {

	public Button menu; 

	void Start () {
		Button btn = menu.GetComponent<Button>();
		btn.onClick.AddListener(ChamaMenu);	
	}
	
	void ChamaMenu(){
		SceneManager.LoadScene(1);
	}

}
