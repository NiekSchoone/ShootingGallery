using UnityEngine;
using System.Collections;

public class MouseMove2D : MonoBehaviour 
{
	private Vector3 mouseFollow;
	
	void Start()
	{
		Cursor.visible = false;
	}

	void Update () 
	{
		mouseFollow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(mouseFollow.x, mouseFollow.y, transform.position.z);
	}
}