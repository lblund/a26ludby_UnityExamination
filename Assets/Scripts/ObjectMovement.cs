using UnityEngine;

public class TestScript2 : MonoBehaviour
{
    [SerializeField] private float magnitude = 5f;
    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector2 sine = new Vector2(Mathf.Abs(Mathf.Sin(Time.time * speed)), Mathf.Abs(Mathf.Sin(Time.time * speed)));

        transform.localScale =  magnitude * sine;
        transform.position = new Vector2(Mathf.Sin(Time.time * speed), Mathf.Abs(Mathf.Sin(Time.time * speed)));
        transform.rotation = Quaternion.AngleAxis(360 * (Mathf.Abs(Mathf.Sin(Time.time))), new Vector3(1, 1, 1));
        
    }
}
