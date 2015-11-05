using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour 
{
	private int _scoreCounter;
	[SerializeField]
	private Text _Counter;
	
	public GameObject manager;
	
	void Update () 
	{
		_scoreCounter = manager.GetComponent<ScoreScript>().playerScore;
		_Counter.text = "Score: " + _scoreCounter.ToString();
	}
}

