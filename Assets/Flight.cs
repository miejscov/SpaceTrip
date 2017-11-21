using UnityEngine;

public class Flight : MonoBehaviour
{
    public float rotationSpeed = 15f;
    public float rocketPower = 10.5f;
    public float amountOfFuel = 100f;
    public float weight = 1f;
    public Transform ground;
    public float speed = 0f;

    private Rigidbody2D rigid;
    private ConstantForce2D force;
    private float heigh = 0f;
    private float vel = 0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        force = GetComponent<ConstantForce2D>();


        rigid.mass = weight;
    }

    void Update()
    {
        speed = rigid.velocity.magnitude;
        speed += 4;
        if (speed >= 4.5 && speed < 7.3)
            SetZoom(speed);
        else if (speed >= 7.3)
            SetZoom(7.3f);

        heigh = -Vector2.Distance(transform.position, new Vector2(transform.position.x, ground.position.y));
        DecreaseFuel();
        if (amountOfFuel > 0)
            rigid.AddForce(transform.up * rocketPower);

        transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * (-rotationSpeed));
    }

    private void DecreaseFuel()
    {
        amountOfFuel -= Time.deltaTime * weight;
    }

    public float GetHeigh()
    {
        return heigh;
    }

    private void SetZoom(float upTo)
    {
        if (GetComponentInChildren<Camera>().orthographicSize + (Time.deltaTime / 3) <= upTo)
            GetComponentInChildren<Camera>().orthographicSize = GetComponentInChildren<Camera>().orthographicSize + (Time.deltaTime / 3);
        else
            GetComponentInChildren<Camera>().orthographicSize = upTo;
    }
}
