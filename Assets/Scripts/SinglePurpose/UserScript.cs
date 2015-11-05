using UnityEngine;
using System.Collections;

public class UserScript : MonoBehaviour 
{
	public string userName;

	public GameObject getInputUI;

	public GameObject inputUsername;
	
	void Start()
	{
		this.enabled = false;
	}

	public void EnableThis()
	{
		this.enabled = true;
	}

	void Update()
	{
		userName = getInputUI.GetComponent<UserGUI>().submittedUser;

		inputUsername.SetActive(true);
	}

}
