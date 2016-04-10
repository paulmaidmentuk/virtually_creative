using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.IO;

public class Audio : MonoBehaviour {

    public AudioSource audio1;
    public AudioSource audio2;
    public TextMesh textMesh;
    public Material spotifyMaterial;
    private bool isPlaying = true;
    private JSONNode jsonData;

    // Use this for initialization
    IEnumerator Start () {
        textMesh.text = "Introducing Spotify API";
        WWW www = new WWW("http://localhost/index.php?id=2zYzyRzz6pRmhPzyfMEC8s");
        yield return www;
        jsonData = JSON.Parse(www.text);
        DownloadImage();
        textMesh.text = "Artist: " + jsonData["artists"][0]["name"].Value + " \n" + jsonData["name"].Value;
        audio1.Play();
        WWW www2 = new WWW("http://localhost/index.php?id=4CJVkjo5WpmUAKp3R44LNb");
        yield return www2;
        jsonData = JSON.Parse(www2.text);
    }

    WWW imageSource;
    Texture2D imgTexture;

    void DownloadImage()
    {
        imgTexture = new Texture2D(732, 549, TextureFormat.ARGB32, false);
        imageSource = new WWW("http://localhost/getImage.php?link=" + jsonData["album"]["images"][0]["url"].Value);

        StartCoroutine("loadImageUrl");
    }

    IEnumerator loadImageUrl()
    {
        while (!imageSource.isDone)
        {
            yield return new WaitForSeconds(0.5f);
        }

        imageSource.LoadImageIntoTexture(imgTexture);
        spotifyMaterial.mainTexture = imgTexture;
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
            DownloadImage();
        }
    }

}
