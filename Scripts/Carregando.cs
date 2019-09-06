using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Carregando : MonoBehaviour {

    public float countdown = 8.0f;
    
	void Update () {
        countdown -= Time.deltaTime;

        if(countdown <= 0.0f){
            SceneManager.LoadScene(2);
        }
	}

}
