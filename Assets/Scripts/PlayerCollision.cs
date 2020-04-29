using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Material startMaterial;
    public Texture[] texture;
    public float resetDealay = 5f;

    private Renderer rend;
    private int randomNumber;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        resetTexture();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            getRandomNumber();
            rend.material.mainTexture = texture[randomNumber];
            Invoke("resetTexture", resetDealay);
        }
    }

    private void resetTexture()
    {
        rend.sharedMaterial = startMaterial;
    }

    private void getRandomNumber()
    {
        randomNumber = Random.Range(0, 3);
    }
}
