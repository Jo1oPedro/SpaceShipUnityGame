using UnityEngine;

public class shipController : MonoBehaviour
{
    public float xSpeed = 3.5f;
    public float ySpeed = 3.5f;
    public GameObject shootPrefab;
    public objectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new objectPool(shootPrefab, 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float vx = Input.GetAxis("Horizontal") * xSpeed;
        float vy = Input.GetAxis("Vertical") * ySpeed;
    
        Vector2 v = new Vector2(vx, vy);
        pos += v * Time.fixedDeltaTime;

        if(pos.y < -4)
        {
            pos.y = -4;
        } else if(pos.y > 4) {
            pos.y = 4;
        }

        transform.position = pos;

        if(Input.GetKeyDown(KeyCode.Space)) {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject bullet = objectPool.GetFromPool();

        if(bullet != null) {
            bullet.transform.position = transform.position + new Vector3(1, 0);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 10f;
        }
    }
}
