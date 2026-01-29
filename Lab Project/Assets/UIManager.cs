using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject ammoSlider;
    private void Awake()
    {
        ammoSlider = GameObject.FindGameObjectWithTag("AmmoCountSliderTag");
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
    

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateAmmoCountSlider(float curBulletCount,float bulletCount,float totalBulletInInventory)
    {
        ammoSlider.GetComponent<Slider>().value = curBulletCount / bulletCount;
        ammoSlider.transform.Find("AmmoCount").GetComponent<TextMeshProUGUI>().text = curBulletCount.ToString() + "/" + bulletCount.ToString();
        ammoSlider.transform.Find("TotalAmmoLeftText").GetComponent<TextMeshProUGUI>().text = "Total Ammo Left: " + totalBulletInInventory.ToString();
    }
}
