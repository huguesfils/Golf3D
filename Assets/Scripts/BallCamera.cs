using UnityEngine;
using UnityEngine.EventSystems;

public class BallCamera : MonoBehaviour
{
    public GameObject balle;
    public float camDistance = 3.5f;

    float x = 0.0f;
    float y = 0.0f;
    Quaternion rotation;

    Touch touch1;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;

    }

    void LateUpdate()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
    x += Input.GetAxis("Mouse X") * 3;
#endif

#if UNITY_IPHONE || UNITY_ANDROID
    if(Input.touches.Length == 1)
    {
    x += Input.GetTouch(0).deltaPosition.x * 0.1f;
    }
#endif

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            rotation = Quaternion.Euler(y, x, 0);
        }
        Vector3 position = rotation
                * new Vector3(0.0f, balle.transform.position.y / 3, -camDistance)
                + balle.transform.position;

        transform.rotation = rotation;
        transform.position = position;

        if (transform.position.y < (3.0f))
        {
            transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
        }
    }
}