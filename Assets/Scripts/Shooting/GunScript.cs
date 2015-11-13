using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour 
{
	public AudioClip shootSound;
	public AudioClip noAmmoSound;
	public AudioClip reloadSound;

	public int ammo = 5;
	public bool reloading;

	private AudioSource audioSource;
	private float _volume;
	private int _missingAmmo;
	
	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		ammo = 5;
	}

	void Start()
	{
		reloading = false;
		_missingAmmo = 0;
		_volume = 1;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(ammo > 0)
			{
				if(reloading != true)
				{
					Shoot();
				}
			}else
			{
				audioSource.PlayOneShot(noAmmoSound, _volume);
			}
		}

		if(Input.GetKey(KeyCode.Space))
		{
			if(reloading != true && ammo < 5)
			{
				StartCoroutine(Reload());
			}
		}
	}

	void Shoot()
	{
		audioSource.PlayOneShot(shootSound, _volume);
		ammo--;
		_missingAmmo += 1;
	}

	IEnumerator Reload()
	{
		audioSource.PlayOneShot(reloadSound, _volume);
		reloading = true;

		yield return new WaitForSeconds(reloadSound.length);
		
		ammo++;
		_missingAmmo--;
		reloading = false;

	}
	
}