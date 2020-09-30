using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class PlayerHealth : Health {

    [SerializeField] TextMeshProUGUI healthText;
    // Time from taking damage to regenerating health
    [SerializeField] float healthRegenTimer = 5f;
    // The amount of health healed per second
    [SerializeField] float healthRegenPerSecond = 10f;
    [SerializeField] RectTransform anchor;
    private float timeSinceTakingDamage = 0f;

    protected override void Start() {
        // Display player health 
        base.Start(); 
        anchor.localScale = new Vector3(1f, 1f); 
    }

    public override void TakeDamage(float damageToTake) {
        base.TakeDamage(damageToTake);
        // Display player health
        anchor.localScale = new Vector3(currentHealth / 100, 1f);
        timeSinceTakingDamage = 0f;
    }

    protected override void Die() {
        Debug.Log("Blegh");
        GameLogic.Instance.PlayerDied();
    }

    private void Update() {
        timeSinceTakingDamage += Time.deltaTime;

        if(timeSinceTakingDamage >= healthRegenTimer) {
            currentHealth = Mathf.Clamp(currentHealth + (healthRegenPerSecond * Time.deltaTime), 0f, maxHealth);
            if (currentHealth < 0) {
                //Don't show negative health
                anchor.localScale = new Vector3(0, 0f);
                return;
            }
            anchor.localScale = new Vector3(currentHealth/100, 1f);
        }
    }

    public float GetHealthRegenTimer() { return healthRegenTimer; }
    public void SetHealthRegenTimer(float value) { healthRegenTimer = value; }
    public float GetHealthRegenPerSecond() { return healthRegenPerSecond; }
    public void SetHealthRegenPerSecond(float value) { healthRegenPerSecond = value; }
}
