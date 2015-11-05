using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickDeath : MonoBehaviour 
{
	private WaveSystem _targets;
	private GunScript _getGun;

	public GameObject gun;
	public GameObject manager;
	
	public int addedScore;

	void Start()
	{
		addedScore = 10;

		manager = GameObject.FindGameObjectWithTag("Manager");
		gun = GameObject.FindGameObjectWithTag("Gun");

		_targets = manager.GetComponent<WaveSystem>();
	}

	public void KillTarget()
	{
		manager.GetComponent<ScoreScript>().playerScore += addedScore;
		_targets.killedTargets += 1;

		Destroy (this.gameObject);
	}

	void Update()
	{
		_getGun = gun.GetComponent<GunScript>();

	}

	void OnMouseDown()
	{
		if(_getGun.ammo > 0 && _getGun.reloading != true)
		{
			KillTarget();
		}
	}
}
