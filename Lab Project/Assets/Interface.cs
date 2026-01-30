using UnityEngine;
public interface IWeapon
{
    void callShoot() { }
}
public interface IReload
{
    void callReload() { }
}
public interface ITriggerable
{
    void callTriggerAction() { }
}