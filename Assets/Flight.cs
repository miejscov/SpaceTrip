using UnityEngine;

public class Flight : MonoBehaviour {

    public float speed = 5f;
    public float power = 7f;

    private Rigidbody2D rigid;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        rigid.AddRelativeForce(Vector2.up * power);

        transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * (-speed));

        /*if (Input.GetKey("left"))
            transform.Translate(Vector2.left * speed);
        if (Input.GetKey("right"))
            transform.Translate(Vector2.right * speed);
    */}
}
