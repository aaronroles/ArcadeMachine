using UnityEngine;
using System.Collections;

public class LevelHandler : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Application.LoadLevel("Level01_TheBakery");
		}

		if(Input.GetKeyDown(KeyCode.Alpha2)){
			Application.LoadLevel("Level02_DessertDesert");
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)){
			Application.LoadLevel("Level03_Jellyville");
		}

		if(Input.GetKeyDown(KeyCode.Alpha4)){
			Application.LoadLevel("Level04_Final");
		}

	}
}
