using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeGUI : MonoBehaviour 
{
	private int _timeCounter;
	[SerializeField]
	private Text _Counter;

	private EndGameTimer getTimer;

	public GameObject manager;

	void Start()
	{
		getTimer = manager.GetComponent<EndGameTimer>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(getTimer != null)
		{
			_timeCounter = (int) Mathf.Ceil(manager.GetComponent<EndGameTimer> ().gameTimer);
			_Counter.text = "Time: " + _timeCounter.ToString();
		}
	}
}
