using UnityEngine;
using TMPro;

public class Revolve : MonoBehaviour
{
    private Transform shield;
    private float angle = 0;
    private float speed = 0;
    private float scale = 0.001f;
    private float deceleration = 0.01f;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        shield = GameObject.Find("Shield").transform;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // angle += Input.mouseScrollDelta.y * scale;
        // shield.position = new Vector2(Mathf.Cos(angle) * 2, Mathf.Sin(angle) * 2);
        // shield.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

        if (GameManager.gameOver == false)
        {
            speed += -Input.mouseScrollDelta.y * scale;
        }
        else
        {
            speed = 0;
            angle = 0;
        }

        speed = Mathf.Clamp(speed, -0.005f, 0.005f);
        angle += speed;
        shield.position = new Vector2(Mathf.Cos(angle) * 2, Mathf.Sin(angle) * 2);
        shield.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg);

        if (speed > 0)
        {
            if (speed - deceleration * Time.deltaTime < 0)
                speed = 0;
            else
                speed += -deceleration * Time.deltaTime;
        }
        else if (speed < 0)
        {
            if (speed + deceleration * Time.deltaTime > 0)
                speed = 0;
            else
                speed += deceleration * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D projHitbox)
    {
        Destroy(projHitbox.gameObject);
        GameManager.projectileCount --;
        GameManager.score ++;
        scoreText.text = "Score: " + GameManager.score;

        if (GameManager.score >= 5 & GameManager.score < 10) {
            GameManager.spawnDelay = 3.5f;
            ApproachCircle.approachTime = 4.6f;
        }
        else if (GameManager.score >= 10 & GameManager.score < 15)
        {
            GameManager.spawnDelay = 3;
            ApproachCircle.approachTime = 4.2f;
        }
        else if (GameManager.score >= 15 & GameManager.score < 20)
        {
            GameManager.spawnDelay = 2.5f;
            ApproachCircle.approachTime = 3.8f;
        }
        else if (GameManager.score >= 20 & GameManager.score < 25)
        {
            GameManager.spawnDelay = 2;
            ApproachCircle.approachTime = 3.4f;
        }
        else if (GameManager.score >= 25 & GameManager.score < 30)
        {
            GameManager.spawnDelay = 1.5f;
            ApproachCircle.approachTime = 3;
        }
        else if (GameManager.score >= 30 & GameManager.score < 35)
        {
            GameManager.spawnDelay = 1f;
            ApproachCircle.approachTime = 2.6f;
        }
    }
}