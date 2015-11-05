using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserGUI : MonoBehaviour 
{
	public string submittedUser;
	[SerializeField]
	private Text user;
	
	void Update () 
	{
		submittedUser = user.text;
	}
}
