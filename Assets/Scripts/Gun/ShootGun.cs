using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootGun : MonoBehaviour
{
    public Transform muzzle;
    public LineRenderer laserLine;
    public LayerMask targetMask;

    public PlayerData data = new PlayerData();
    float lastShotTime = -1f;
    float lastHitTime = -1f;

    [SerializeField] private float range = 100f, fireRate = 0.5f, laserDuration = 0.1f, nextFireTime = 0f;

    void Awake()
    {
        laserLine.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(muzzle.position, muzzle.forward);
        RaycastHit hit;
        Vector3 endPos = muzzle.position + muzzle.forward * range;

        if (lastShotTime >= 0f)
        {
            data.timeBetweenShots.Add(Time.time - lastShotTime);
        }
        lastShotTime = Time.time;
        data.shotsFired++;

        if (Physics.Raycast(ray, out hit, range, targetMask))
        {
            GameManager.Instance.scoreManager.AddScore(1);
            Destroy(hit.collider.gameObject);

            if (lastHitTime >= 0)
            {
                data.timeBetweenHits.Add(Time.time - lastHitTime);
            }
            lastHitTime = Time.time;
            data.targetsHit++;
        }
        GetComponent<RecoilGun>().Recoil();
        Debug.DrawRay(muzzle.position, muzzle.forward * range, Color.red, 100f);
        StartCoroutine(FireLaser(endPos));
    }

    System.Collections.IEnumerator FireLaser(Vector3 endPos)
    {
        laserLine.SetPosition(0, muzzle.position);
        laserLine.SetPosition(1, endPos);
        laserLine.enabled = true;

        yield return new WaitForSeconds(laserDuration);

        laserLine.enabled = false;
    }
}
