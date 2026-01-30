using System.Collections;
using UnityEngine;

public class greenButton : MonoBehaviour, ITriggerable
{
    [SerializeField] Camera TOPVIEWCAM;
    enum State
    {
        Idle,
        Cooldown
    }
    State curState;
    //now before you ask yes I should make a parent class for the buttons
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator cooldown() { curState = State.Cooldown; yield return new WaitForSeconds(3f); curState = State.Idle; }
    public void callTriggerAction()
    {
        if (curState != State.Cooldown) { Debug.Log("GREEN"); TOPVIEWCAM.gameObject.SetActive(true);   StartCoroutine(cooldown()); }
        
    }

   
}
