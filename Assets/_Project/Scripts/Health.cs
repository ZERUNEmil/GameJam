using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initHealth;
    [SerializeField] private int currentHealth;

    public HealthBar healthBar;

    private Animator anim;

    private void OnEnable()
    {
        currentHealth = initHealth;
        healthBar.SetMaxHealth(initHealth);
        anim = GetComponent<Animator>();

    } 

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
            PlayAnimationAndDestroy();
    }

    private void PlayAnimationAndDestroy()
    {
       Destroy(gameObject, 0.6f);
       gameObject.GetComponent<Patrol>().speed = 0;
       anim.Play("Enemy_die");
    }
    
}