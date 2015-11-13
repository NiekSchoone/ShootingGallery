using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoCounter : MonoBehaviour 
{
	private List<GameObject> _bullets = new List<GameObject>();
	
	private int _gunAmmo;

	public GunScript gun;
	
	public GameObject bullet;
	
	public Sprite[] bulletModes;

	void Start () 
	{
		_gunAmmo = gun.GetComponent<GunScript>().ammo;

		for (int i = 0; i < _gunAmmo; i++) 
		{
			GameObject newBullet = Instantiate(bullet, new Vector2((i * 1) + -2 ,-4), Quaternion.identity) as GameObject;

			_bullets.Add(newBullet);

			_bullets[i].GetComponent<SpriteRenderer>().sprite = bulletModes[0];

			Debug.Log("am i working?");
		}
	}

	void Update()
	{
		_gunAmmo = gun.GetComponent<GunScript>().ammo;
		for (int i = 0; i < _bullets.Count; i++) 
		{
			_bullets[i].GetComponent<SpriteRenderer>().sprite = bulletModes[1];
		
			for (int j = 0; j < _gunAmmo; j++) 
			{
				_bullets[j].GetComponent<SpriteRenderer>().sprite = bulletModes[0];
			}
		}
	}
}
