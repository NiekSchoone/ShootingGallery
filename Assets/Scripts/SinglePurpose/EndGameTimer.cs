using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameTimer : MonoBehaviour 
{
	private float _lastUpdate;

	public int gameTimer = 60;
	
	public GameObject restartButton;
	public GameObject gameOverText;

	public GameObject[] elements;

	private GameObject[] targets;

	public GameObject canvas;

	void Update () 
	{
		if(Time.time - _lastUpdate >= 1f)
		{
			gameTimer--;
			_lastUpdate = Time.time;
		}
		if (gameTimer == 0)
		{
			Cursor.visible = true;

			restartButton.SetActive(true);
			gameOverText.SetActive(true);

			targets = GameObject.FindGameObjectsWithTag("Target");

			Destroy(canvas.GetComponent<ScoreGUI>());
			Destroy(canvas.GetComponent<TimeGUI>());

			for (int t = 0; t < targets.Length; t++) 
			{
				Destroy(targets[t]);
			}

			for (int i = 0; i < elements.Length; i++) 
			{
				Destroy(elements[i]);
			}
		}
	}
}

