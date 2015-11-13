using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSystem : MonoBehaviour 
{
	private int _targetAmount;

	public int killedTargets = 0;
	public GameObject target;



	void Start () 
	{
		_targetAmount = 2;

		NewWave();
	}
	
	void Update () 
	{
		if(killedTargets >= _targetAmount)
		{
			NewWave();
			killedTargets = 0;
		}
	}

	IEnumerator SpawnTarget(float _seconds)
	{
		yield return new WaitForSeconds (_seconds);

		Instantiate(target, target.transform.position, Quaternion.identity);
	}

	void NewWave()
	{
		_targetAmount += 1;

		for(int i = 0; i <= _targetAmount - 1; i++)
		{
			StartCoroutine(SpawnTarget(Random.Range(0.5f, 2f) * i));
		}
	}
}