using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour 
{
	private CursorMode _cursorMode = CursorMode.Auto;
	private Vector2 _hotSpot;

	public Texture2D cursorTexture;

	void Awake()
	{
		_cursorMode = CursorMode.Auto;
		_hotSpot = Vector2.zero;

		Cursor.SetCursor(cursorTexture, _hotSpot, _cursorMode);
	}
}
