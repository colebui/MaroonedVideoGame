using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Health : MonoBehaviour {

    [SerializeField] float maxHealth = 100f;

    // TODO: Should not be serialized, just is now for debugging
    [SerializeField] float currentHealth = 0f;

    // Start is called before the first frame update
    protected virtual void Start() {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageToTake) {
        currentHealth -= damageToTake;

        // TODO: Very basic, just to test
        if(currentHealth <= 0) {
            Destroy(gameObject);
        }

    }
}
