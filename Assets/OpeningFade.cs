using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningFade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Update();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private Image image;
    public float duration = 3f;
    private float timer = 0f;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("No Image component found on this GameObject!");
        }
    }

    private void Update()
    {
        if (image == null) return;

        timer += Time.deltaTime;

        // Progress from 0 → 1 → 0 across the duration
        float t = Mathf.PingPong(timer / (duration / 2f), 1f);
        image.color = Color.Lerp(Color.black, Color.white, t);

        // After the full cycle (black → white → black), load the scene
        if (timer >= duration)
        {
            SceneManager.LoadScene("TitlePage");
        }
    }
}
