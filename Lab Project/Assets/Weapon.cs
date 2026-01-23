using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IReload, IWeapon
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    //max ammo count of the gun
    [SerializeField] protected float bulletCount;
    //current bullet in the gun
    [SerializeField] protected float curBulletCount;
    //max ammo in the player's inventory for this gun
    [SerializeField] protected float totalBulletInInventory;
    //time inbetween to reload 1 bullet or just the whole mag
    protected GameObject ammoCountSilderGUI;
    protected WaitForSeconds reloadInbetweenBulletTime;
    protected Coroutine onGoingReloadCorotuine;


    protected virtual void Start()
    {
        ammoCountSilderGUI = GameObject.FindGameObjectWithTag("AmmoCountSliderTag");
    }

    // Update is called once per frame
    protected virtual void shoot()
    {

    }
    //reloads the gun mainly just to call the coroutine for reloading bullets
    protected virtual void reload()
    {
        if (curBulletCount == bulletCount && onGoingReloadCorotuine == null)
        {
            Debug.Log("Can't reload");
        }
        else
        {
            onGoingReloadCorotuine = StartCoroutine(reloadingBullets());
        }

    }
    //the majority of the reload logic happens here
    protected virtual IEnumerator reloadingBullets()
    {
        curBulletCount++;
        totalBulletInInventory--;
        updateAmmoCountSlider();
        yield return reloadInbetweenBulletTime;
        if (curBulletCount != bulletCount || totalBulletInInventory! <= 0)
        {
            StartCoroutine(reloadingBullets());
        }
    }
    protected void updateAmmoCountSlider()
    {
        Debug.Log(ammoCountSilderGUI);
        ammoCountSilderGUI.GetComponent<Scrollbar>().size = curBulletCount / bulletCount;
        ammoCountSilderGUI.transform.Find("AmmoCount").GetComponent<TextMeshProUGUI>().text = curBulletCount.ToString() + "/" + bulletCount.ToString();
        ammoCountSilderGUI.transform.Find("TotalAmmoLeftText").GetComponent<TextMeshProUGUI>().text = "Total Ammo Left: " + totalBulletInInventory.ToString();
    }
    public void callShoot()
    {
        shoot();
    }
    public void callReload()
    {
        reload();
    }
}
