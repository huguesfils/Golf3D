using System.Security.Cryptography;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
