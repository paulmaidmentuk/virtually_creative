using UnityEngine;
using System.Collections;

public class GettyImages : MonoBehaviour {


    public Material gettyImagesMaterial;
    WWW imageSource;
    Texture2D imgTexture;

    // Use this for initialization
    void Start()
    {
        DownloadImage();
    }

    void DownloadImage()
    {
        imgTexture = new Texture2D(732, 549, TextureFormat.ARGB32, false);
        imageSource = new WWW("http://localhost/gettyImages.php");

        StartCoroutine("loadImageUrl");
    }

    IEnumerator loadImageUrl()
    {
        while (!imageSource.isDone)
        {
            yield return new WaitForSeconds(0.5f);
        }

        imageSource.LoadImageIntoTexture(imgTexture);
        gettyImagesMaterial.mainTexture = imgTexture;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("ahoj");
            DownloadImage();
        }
    }
}
