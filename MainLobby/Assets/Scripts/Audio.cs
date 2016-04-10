using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.IO;

public class Audio : MonoBehaviour {

    public AudioSource audio1;
    public AudioSource audio2;
    public TextMesh textMesh;
    public Renderer renderer1;
    private bool isPlaying = true;
    private JSONNode jsonData;

    // Use this for initialization
    IEnumerator Start () {
        textMesh.text = "Introducing Spotify API";
        yield return new WaitForSeconds(2);
        WWW www = new WWW("http://localhost/index.php");
        yield return www;
        jsonData = JSON.Parse(www.text);
        textMesh.text = "Artist: " + jsonData["artists"][0]["name"].Value + " \n" + jsonData["name"].Value;

        audio1.Play();
        WWW www2 = new WWW("http://localhost/index2.php");
        yield return www2;
        jsonData = JSON.Parse(www2.text);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlaying)
            {
                audio2.Pause();
                isPlaying = false;
                textMesh.text = "Playing paused";
            }
            else
            {
                audio2.Play();
                isPlaying = true;
                textMesh.text = "Artist: " + jsonData["artists"][0]["name"].Value + " \n" + jsonData["name"].Value;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.OpenURL("http://spotify.com/");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            textMesh.text = "Looking for next song";
            audio1.Stop();
            audio2.Play();
            textMesh.text = "Artist: " + jsonData["artists"][0]["name"].Value + " \n" + jsonData["name"].Value;
        }
    }

}
