using UnityEngine;

public class ApproachCircle : MonoBehaviour
{
    private Transform projectile;
    private Transform circle;
    public static float approachTime = 5;
    float projX;
    float projY;
    float circleX;
    float circleY;
    float adjacent;
    float opposite;

    void Start()
    {
        projectile = gameObject.transform;
        circle = GameObject.Find("Circle").transform;
        projX = projectile.position.x;
        projY = projectile.position.y;
        circleX = circle.position.x;
        circleY = circle.position.y;
        adjacent = circleX - projX;
        opposite = circleY - projY;
    }
    
    void Update()
    {
        projectile.position = new Vector2(projectile.position.x + (adjacent / approachTime) * Time.deltaTime, projectile.position.y + (opposite / approachTime) * Time.deltaTime);

        //float hypotenuse = Mathf.Sqrt(Mathf.Pow(circleX - projY, 2) + Mathf.Pow(circleY - projY, 2));
    }
}