using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] AudioSource sumberSuara;
    [SerializeField] AudioClip clipMusik;
    [SerializeField] AudioClip clipMusik2;
    
    void Start()
    {
        sumberSuara.clip = clipMusik;
        sumberSuara.loop = true;
        sumberSuara.volume = 0.8f;
        sumberSuara.Play();
    }

    public void rubah_musik1() 
    {
        sumberSuara.Stop();
        sumberSuara.clip = clipMusik2;
        sumberSuara.Play();
    }

    public void rubah_musik2()
    {
        sumberSuara.Stop();
        sumberSuara.clip = clipMusik;
        sumberSuara.Play();
    }
}
