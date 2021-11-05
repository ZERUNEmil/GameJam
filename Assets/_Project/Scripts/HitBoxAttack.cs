using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
   [SerializeField] private int _attackPower = 1;

   //the bool is to confirm that we will only hit the target once
   private bool _canAttack;
   private void OnEnable()
   {
      _canAttack = true;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      // Check if the target has the damage interface
      var hit = other.GetComponent<IDamageable>();

      if (hit != null && _canAttack)
      {
         hit.TakeDamage(_attackPower);
         _canAttack = false;
      }
   }
}
