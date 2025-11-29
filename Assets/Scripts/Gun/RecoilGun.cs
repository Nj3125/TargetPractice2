using UnityEngine;

public class RecoilGun : MonoBehaviour
{
    public float recoilDistance = 0.2f;
    public float recoilSpeed = 10f;
    private Vector3 originalLocalPos;
    private Vector3 currentVelocity;
    void Start()
    {
        originalLocalPos = transform.localPosition;
    }

    public void Recoil()
    {
        transform.localPosition -= transform.forward * recoilDistance;
    }
    void Update()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, originalLocalPos, ref currentVelocity, 1f / recoilSpeed);
    }
}
