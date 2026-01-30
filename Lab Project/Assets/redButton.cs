using System.Collections;
using UnityEngine;
public class redButton : MonoBehaviour, ITriggerable
{
    [SerializeField] Camera TOPVIEWCAM;
    bool triggered=false;
    enum State
    {
        Idle,
        Cooldown
    }
    State curState;

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
        if (curState != State.Cooldown && triggered == false) { triggered = true; TOPVIEWCAM.gameObject.SetActive(false); StartCoroutine(cooldown()); }

    }
}

