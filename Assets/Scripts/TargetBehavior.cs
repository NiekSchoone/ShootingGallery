using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TargetBehavior : MonoBehaviour 
{
	public GameObject manager;

	private float _speed;

	private List<Vector2> _spawnPoints = new List<Vector2>();
	private Vector2 _spawnPoint1;
	private Vector2 _spawnPoint2;
	private Vector2 _spawnPoint3;
	private Vector2 _spawnPoint;

	public GameObject[] endPoints;
	private GameObject _endPoint;


	void Start()
	{
		manager = GameObject.FindGameObjectWithTag("Manager");

		_spawnPoint1 = new Vector2(-8f, -0.3f);
		_spawnPoints.Add(_spawnPoint1);
		_spawnPoint2 = new Vector2(7.6f, 1f);
		_spawnPoints.Add(_spawnPoint2);
		_spawnPoint3 = new Vector2(-7.6f, 2.6f);
		_spawnPoints.Add(_spawnPoint3);

		int random = Random.Range(0, _spawnPoints.Count);

		_endPoint = endPoints[random];
		_spawnPoint = _spawnPoints[random];

		transform.position = _spawnPoint;

		_speed = Random.Range(4, 8);

		SpriteRenderer layer = this.GetComponent<SpriteRenderer>();

		layer.sortingOrder = -(random+1) - 1;

		if((random+1) == 1)
		{
			this.transform.localScale = new Vector3(1.7f,1.7f,1);
		}else if((random+1) == 2)
		{
			this.transform.localScale = new Vector3(1.5f,1.5f,1);
		}else if((random+1) == 3)
		{
			this.transform.localScale = new Vector3(1.3f,1.3f,1);
		}
	}

	void Update () 
	{
		float velocity = _speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(this.transform.position, _endPoint.transform.position, velocity);
		Quaternion rotation = Quaternion.LookRotation(_endPoint.transform.position - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

		if(this.transform.position == _endPoint.transform.position)
		{
			manager.GetComponent<WaveSystem>().killedTargets += 1;
			Destroy(this.gameObject);
		}
	}
}
