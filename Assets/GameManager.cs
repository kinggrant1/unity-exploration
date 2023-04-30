using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject projectile;
    private float screenWidth = 160f / 9;
    public static int projectileCount = 0;
    private float spawnTime = 0;
    public static float spawnDelay = 4;
    public static int score = 0;
    private Transform projectilesParent;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI livesText;
    private GameObject circle;
    private TextMeshProUGUI gameOverText;
    public static bool gameOver = false;

    void Start()
    {
        projectile = GameObject.Find("Projectile");
        projectilesParent = GameObject.Find("ProjectilesParent").transform;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        circle = GameObject.Find("Circle");
        gameOverText = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (gameOver == false)
        {
            if (projectileCount == 0 | (projectileCount > 0 & Time.time - spawnTime >= spawnDelay))
                {
                    GameObject newProjectileGO = Instantiate(projectile, projectilesParent.transform);
                    Transform newProjectile = newProjectileGO.transform;
                    projectileCount ++;
                    int side = Random.Range(1, 5);

                    if (side == 1)
                    {
                        newProjectile.position = new Vector2(Random.Range(-screenWidth / 2, screenWidth / 2), 5);
                    }
                    else if (side == 2)
                    {
                        newProjectile.position = new Vector2(screenWidth / 2, Random.Range(-5f, 5f));
                    }
                    else if (side == 3)
                    {
                        newProjectile.position = new Vector2(Random.Range(-screenWidth / 2, screenWidth / 2), -5);
                    }
                    else if (side == 4)
                    {
                        newProjectile.position = new Vector2(-screenWidth / 2, Random.Range(-5f, 5f));
                    }

                    newProjectileGO.GetComponent<ApproachCircle>().enabled = true;
                    spawnTime = Time.time;
                }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                gameOverText.text = "";
                spawnTime = Time.time;
                projectileCount = 0;
                spawnDelay = 4;
                ApproachCircle.approachTime = 5;
                score = 0;
                scoreText.text = "Score: " + score.ToString();
                OnHit.lives = 3;
                livesText.text = OnHit.lives.ToString();
                circle.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
                gameOver = false;
            }
        }

        if (OnHit.lives == 0)
        {
            foreach (Transform child in projectilesParent)
            {
                Destroy(child.gameObject);
            }

            gameOverText.text = "GAME OVER";
            gameOver = true;
        }
    }
}