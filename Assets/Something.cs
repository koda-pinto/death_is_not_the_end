using UnityEngine;

public class Something : MonoBehaviour
{
    public GameObject littleguy;

    void Start()
    {
        if (littleguy != null)
            littleguy.SetActive(false);
    }

    void Update()
    {
        // koda = laaaaaaaame!!
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "unexpectedguest" && littleguy != null)
            littleguy.SetActive(true);
    }
}
