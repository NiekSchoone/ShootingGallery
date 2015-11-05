using UnityEngine;
using System.Collections;

public class timeBase : MonoBehaviour {


	public float timer = 60;
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			Application.LoadLevel("gameover");
		}

	
	}
}
