using UnityEngine;

public class GunAimAtMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private float planeDistance = 10f; // distance from camera along forward

    void Update()
    {
        float scaleX = renderTexture.width / (float)Screen.width;
        float scaleY = renderTexture.height / (float)Screen.height;

        Vector3 rtMouse = new Vector3(
            Input.mousePosition.x * scaleX,
            Input.mousePosition.y * scaleY,
            0
        );

        // Cast ray from camera using scaled position
        Ray ray = mainCamera.ScreenPointToRay(rtMouse);

        // Plane perpendicular to camera at fixed distance
        Plane plane = new Plane(mainCamera.transform.forward, mainCamera.transform.position + mainCamera.transform.forward * planeDistance);

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // Rotate gun to look at this point
            Vector3 direction = hitPoint - transform.position;
            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }
    }
}
