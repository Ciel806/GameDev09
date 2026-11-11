using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Header("UI References")]
    public Canvas healthCanvas;
    public Image bloodImage;

    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float damagePerPress = 20f;

    void Start()
    {
        currentHealth = maxHealth;

        // Pastikan fill amount penuh di awal
        if (bloodImage != null)
        {
            bloodImage.fillAmount = 1f;
        }
    }

    void Update()
    {
        // Challenge 2: Tekan Spasi untuk mengurangi darah
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damagePerPress);
        }
    }

    void LateUpdate()
    {
        // Challenge 1: Cegah rotasi health bar mengikuti badan karakter.
        // Canvas dibuat selalu menghadap searah kamera utama (Billboard)
        if (healthCanvas != null && Camera.main != null)
        {
            healthCanvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // Update tampilan fill bar Image
        if (bloodImage != null)
        {
            bloodImage.fillAmount = currentHealth / maxHealth;
        }

        // Hancurkan karakter jika darah habis
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Challenge 2: Karakter menghilang (destroy)
        Destroy(gameObject);
    }
}