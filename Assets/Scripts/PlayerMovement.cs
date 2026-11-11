using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameObject objCamera;

    [Header("Audio Langkah Kaki")]
    [SerializeField] private AudioSource audioLangkah;
    [SerializeField] private AudioClip clipLangkah; // Masukkan Footsteps.wav di sini

    void Start()
    {
        objCamera = this.transform.Find("Main Camera").gameObject;

        if (audioLangkah == null) audioLangkah = GetComponent<AudioSource>();

        if (audioLangkah != null)
        {
            if (clipLangkah != null) audioLangkah.clip = clipLangkah;
            audioLangkah.loop = true;          // Loop agar suara langkah berulang saat jalan terus
            audioLangkah.playOnAwake = false;   // Jangan langsung bunyi saat game baru mulai
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float h = 0f, v = 0f;

        if (Keyboard.current.aKey.isPressed) {
            h = -0.5f;
        } else if (Keyboard.current.dKey.isPressed) {
            h = 0.5f;
        }

        if (Keyboard.current.wKey.isPressed) {
            v = 1f;
        } else if (Keyboard.current.sKey.isPressed) {
            v = -1f;
        }

        this.transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * 3f);
        this.transform.Rotate(Vector3.up * h * 3f);

        if (v != 0f)
        {
            if (audioLangkah != null && !audioLangkah.isPlaying)
            {
                audioLangkah.Play();
            }
        }
        else
        {
            if (audioLangkah != null && audioLangkah.isPlaying)
            {
                audioLangkah.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubah_musik1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubah_musik2");
        }
    }
}