using UnityEngine;

public class Pistol : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        firePoint = transform.Find("FirePoint").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();


        }
    }
    protected override void shoot()
    {
        Vector3 targetPoisition = Camera.main.transform.position + Camera.main.transform.forward * range;
        Vector3 shootDirection = (targetPoisition - firePoint.position).normalized;
        Debug.DrawRay(firePoint.position, shootDirection * range, Color.red, 2f);
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit " + hit.transform.name);
        }
    }
}
