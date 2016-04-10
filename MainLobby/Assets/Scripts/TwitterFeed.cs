using UnityEngine;
using System.Collections;

public class TwitterFeed : MonoBehaviour {

	public TextMesh textMesh;

	private int frameCount = 0;

	// Use this for initialization
	IEnumerator Start () {
		textMesh.text = "Loading...";
		WWW www = new WWW ("http://localhost/TweetPHP.php?user=axel_springer");
		yield return www;
		Debug.Log (www.error);
		Debug.Log (www.text);
		textMesh.text = www.text;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
