using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoGUI : MonoBehaviour 
{
	private GunScript ammoScript;
	public GameObject crosshair;

	private int _ammoCounter;
	[SerializeField]
	private Text _Counter;

	void Start()
	{
		ammoScript = crosshair.GetComponent<GunScript>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(crosshair != null)
		{
			_ammoCounter = ammoScript.GetComponent<GunScript>().ammo;
			_Counter.text = _ammoCounter.ToString();
		}
	}
}
