using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletCount;
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void shoot()
    {
        
    }
    protected virtual void reload()
    {

    }
}
