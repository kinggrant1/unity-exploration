using UnityEngine;
using TMPro;

public class OnHit : MonoBehaviour
{
    public static int lives = 3;
    private TextMeshProUGUI livesText;

    void Start()
    {
        livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D projHitbox)
    {
        Destroy(projHitbox.gameObject);
        GameManager.projectileCount --;
        lives --;
        lives = Mathf.Clamp(lives, 0, 3);
        livesText.text = lives.ToString();

        if (lives == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
        }
        else if (lives == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }
}