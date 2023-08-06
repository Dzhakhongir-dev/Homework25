using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void UseGravity()
    {
        rigidbody.useGravity = true;
    }

    public void ChangeScale()
    {
        transform.localScale = new Vector3(20f, 1f, 20f);
    }
    public void RotateCube()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
    }
}
