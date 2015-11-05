using UnityEngine;
using System.Collections;

public class PostScoreURL : MonoBehaviour 
{
	private int scoredPoints;
	private string connectedUser;

	void Start () 
	{
		connectedUser = Camera.main.gameObject.GetComponent<UserScript>().userName;
		scoredPoints = Camera.main.gameObject.GetComponent<ScoreScript>().playerScore;

		string url = "http://localhost/PHPvieuwer101/UnityHS/postHS.php";
		WWWForm form = new WWWForm();
		form.AddField("action", "send");
		form.AddField("username", connectedUser);
		form.AddField("score", scoredPoints.ToString());
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}

		Application.LoadLevel(Application.loadedLevel);
	}
}
