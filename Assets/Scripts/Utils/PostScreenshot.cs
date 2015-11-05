using UnityEngine;
using System.Collections;

public class PostScreenshot : MonoBehaviour 
{

	private string _url;

	private int _width;
	private int _height;

	private Texture2D _tex;

	private byte[] _bytes;

	private WWWForm _form;

	private WWW _www;

	// Use this for initialization
	void Start() 
	{
		_url = "http://localhost/PHPvieuwer101/UploadScreenshot/UploadScreenShot.php";

		_width = Screen.width;
		_height = Screen.height;
		_tex = new Texture2D( _width, _height, TextureFormat.RGB24, false);

		StartCoroutine(UploadPNG());
	}
	
	// Update is called once per frame
	IEnumerator UploadPNG() 
	{
		yield return new WaitForEndOfFrame();

		_tex.ReadPixels(new Rect(0, 0, _width, _height), 0, 0);
		_tex.Apply();

		_bytes = _tex.EncodeToPNG();

		_form = new WWWForm();
		_form.AddBinaryData("fileUpload", _bytes);

		_www = new WWW(_url, _form);

		Destroy(_tex);

		yield return _www;

		if(!string.IsNullOrEmpty(_www.error))
		{
			Debug.Log("An error has occured " + _www.error);
		}else{
			Debug.Log("A screenshot was succesfully uploaded " + _www.text);
		}
	}
}
