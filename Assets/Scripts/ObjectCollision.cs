using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.UI;

public class ObjectCollision : MonoBehaviour
{
    public RawImage rawimg;

    private Renderer rend;
    private GameObject collideObject;
    private Texture objectTexture;

    private int randomNumber;
    private JSONNode result;

    private readonly string baseURL = "http://app.stolperwege.hucompute.org/images";
    private readonly string type = "org.hucompute.publichistory.datastore.typesystem.Image";
    private string imgURL = "https://upload.wikimedia.org/wikipedia/commons/a/a2/Stolperst_martorffstr_7_zehden_arthur.jpg";

    private void Start()
    {
        StartCoroutine(GetJSON());
        Invoke("StartCollision", 1);

        rawimg.texture = Texture2D.blackTexture;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetCollisionObject(collision);

        if (collision.collider.CompareTag("Obstacle"))
        {
            StartCollision();
            if (objectTexture != null)
            {
                rend.material.mainTexture = objectTexture;
                rawimg.texture = objectTexture;
            }
            //Invoke("ResetTexture", resetDealay);
        }
    }

    private void GetCollisionObject(Collision collision)
    {
        collideObject = collision.gameObject;
        rend = collideObject.GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void StartCollision()
    {
        GetRandomNumber();
        GetImageURL();
        StartCoroutine(GetTexture(imgURL));
    }

    private void GetRandomNumber()
    {
        randomNumber = Random.Range(0, 778);
    }

    IEnumerator GetJSON()
    {
        UnityWebRequest resultRequest = UnityWebRequest.Get(baseURL);

        yield return resultRequest.SendWebRequest();

        if (resultRequest.isNetworkError || resultRequest.isHttpError)
        {
            Debug.LogError(resultRequest.error);
            yield break;
        }

        JSONNode infoRequest = JSON.Parse(resultRequest.downloadHandler.text);
        result = infoRequest["result"];
    }

     private void GetImageURL()
    {
        string imgType = result[randomNumber]["type"];
        Debug.Log(result[randomNumber]);
        if (imgType == type)
        {
            Debug.Log(result[randomNumber]["value"]);

            imgURL = result[randomNumber]["value"];
        }
        else
        {
            Debug.Log("Type is NOT the same");
        }
    }

    IEnumerator GetTexture(string url)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(url);
        yield return imgRequest.SendWebRequest();

        if (imgRequest.isNetworkError || imgRequest.isHttpError)
        {
            Debug.Log(imgRequest.error);
        }
        else
        {
            objectTexture = ((DownloadHandlerTexture)imgRequest.downloadHandler).texture;
        }
    }
}
