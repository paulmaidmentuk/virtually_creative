using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;

public class FirePlace : MonoBehaviour {

     //public AudioClip otherClip;
     public AudioSource audio;
     private bool isPlaying = true;
     private JSONNode jsonData; 


    // Use this for initialization
    //   IEnumerator Start () {
    IEnumerator Start()
    {
        //var url = ;
        //WWW www = new WWW("http://www.bigsoundbank.com/sounds/ogg/0935.ogg");
        //yield return www;
        //Debug.Log("WWW Ok!: " + www.text);

        // Post a request to an URL with our custom headers
        WWW www = new WWW("http://localhost/index.php");
        yield return www;
        jsonData = JSON.Parse(www.text);
        //Debug.Log("WWW Ok!: " + www.error);

        //.. process results from WWW request here...

        // var N = JSON.Parse(www.text);
        //Debug.Log(N["artists"][0]["name"].Value);
        //      WWW www = new WWW("http://www.bigsoundbank.com/sounds/ogg/0935.ogg");
        //        yield return www;
        //       otherClip = www.GetAudioClip(false, true, AudioType.MPEG);

        // audio.Play();
        //yield return new WaitForSeconds(30);
        //       audio.clip = www.audioClip;
        //audio.Play();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if(isPlaying)
            {
                audio.Pause();
                isPlaying = false;
            } else
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
