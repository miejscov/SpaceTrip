using UnityEngine;

public class Flight : MonoBehaviour
{
    public float rotationSpeed = 15f;
    public float rocketPower = 10.5f;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.AddRelativeForce(Vector2.up * rocketPower);

        transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * (-rotationSpeed));
    }
}
