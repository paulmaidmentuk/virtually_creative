using UnityEngine;
using SimpleJSON;
using System.Collections;

public class Audio : MonoBehaviour {

    public AudioSource audio;
    private bool isPlaying = true;
    private JSONNode jsonData;

    // Use this for initialization
    IEnumerator Start () {
        WWW www = new WWW("http://localhost/index.php");
        yield return www;
        jsonData = JSON.Parse(www.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlaying)
            {
                audio.Pause();
                isPlaying = false;
            }
            else
            {
                audio.Play();
                isPlaying = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.OpenURL("http://spotify.com/");
        }
    }

    void OnMouseOver()
    {
        Debug.Log(jsonData["artists"][0]["name"].Value + " " + jsonData["name"].Value);
    }
}
