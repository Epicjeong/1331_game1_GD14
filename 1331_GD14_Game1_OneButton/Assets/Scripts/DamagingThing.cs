using UnityEngine;
/// <summary>
/// Script for things that can damage player
/// </summary>
public class DamagingThing : MonoBehaviour
{
    private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        TryApplyDamage(other.gameObject);
    }
    private void TryApplyDamage(GameObject target)
    {

        var damageReceiver = target.GetComponent<IDamageReciever>();
        if (damageReceiver != null)
        {
            var info = new DamageInfo
            {
                Amount = _damage,
                Source = gameObject
            };
            damageReceiver.ApplyDamage(info);
            Debug.Log($"[Contact Damage] damaged {target.name}");
        }
    }
}
