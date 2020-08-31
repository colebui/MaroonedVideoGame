using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : Health {

    [SerializeField] TextMeshProUGUI healthText;
    // Time from taking damage to regenerating health
    [SerializeField] float healthRegenTimer = 5f;
    // The amount of health healed per second
    [SerializeField] float healthRegenPerSecond = 10f;

    private float timeSinceTakingDamage = 0f;

    protected override void Start() {
        // Display player health
        base.Start();
        healthText.text = currentHealth.ToString();
    }

    public override void TakeDamage(float damageToTake) {
        base.TakeDamage(damageToTake);
        // Display player health
        healthText.text = currentHealth.ToString();
        timeSinceTakingDamage = 0f;
    }

    protected override void Die() {
        Debug.Log("Blegh");
        FindObjectOfType<GameLogic>().PlayerDied();
    }

    private void Update() {
        timeSinceTakingDamage += Time.deltaTime;

        if(timeSinceTakingDamage >= healthRegenTimer) {
            currentHealth = Mathf.Clamp(currentHealth + (healthRegenPerSecond * Time.deltaTime), 0f, maxHealth);
            healthText.text = ((int)currentHealth).ToString();
        }
    }
}
