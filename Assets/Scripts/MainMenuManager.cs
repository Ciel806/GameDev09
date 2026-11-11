using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameObject TeksJudul;
    private GameObject PlayButton;
    private GameObject OptionButton;

    [Header("Option Window")]
    public GameObject windowOption;

    [Header("Scene Settings")]
    public string gameplaySceneName = "GameplayScene";

    void Start()
    {
        // Mengambil referensi object berdasarkan hierarki
        TeksJudul = this.transform.Find("Panel").Find("bground").Find("txtJudul").gameObject;
        PlayButton = this.transform.Find("Panel").Find("bground").Find("btnPlay").gameObject;
        OptionButton = this.transform.Find("Panel").Find("bground").Find("btnOption").gameObject;

        // Animasi Intro iTween
        iTween.MoveFrom(TeksJudul, iTween.Hash("y", 1000, "time", 2f, "delay", 0f, "easeType", "easeOutBounce"));
        iTween.ScaleFrom(PlayButton, iTween.Hash("x", 0, "y", 0, "time", 2f, "delay", 1f, "easeType", "easeOutQuart"));
        iTween.MoveFrom(OptionButton, iTween.Hash("x", -1000, "time", 2f, "delay", 2f, "easeType", "easeOutExpo",
            "oncomplete", "selesaianim", "oncompletetarget", this.gameObject));

        // Inisialisasi pop-up window: sembunyikan di awal
        if (windowOption != null)
        {
            windowOption.transform.localScale = Vector3.zero;
            windowOption.SetActive(false);
        }
    }

    void selesaianim()
    {
        Debug.Log("selesai sudah animasinya");
        this.transform.Find("Panel").Find("bground").GetComponent<Image>().color = Color.yellow;
    }

    // Tombol Play: Pindah ke Scene Gameplay
    public void OnPlayClicked()
    {
        SceneManager.LoadScene(gameplaySceneName);
    }

    // Tombol Option: Membuka pop-up dengan efek Pop-in (membesar)
    public void OpenOptionWindow()
    {
        if (windowOption == null) return;

        windowOption.SetActive(true);
        windowOption.transform.localScale = Vector3.zero;

        iTween.ScaleTo(windowOption, iTween.Hash(
            "scale", Vector3.one,
            "time", 0.5f,
            "easeType", "easeOutBack",
            "ignoretimescale", true
        ));
    }

    // Tombol Close: Menutup pop-up dengan efek Pop-out (mengecil lalu nonaktif)
    public void CloseOptionWindow()
    {
        if (windowOption == null) return;

        iTween.ScaleTo(windowOption, iTween.Hash(
            "scale", Vector3.zero,
            "time", 0.35f,
            "easeType", "easeInBack",
            "oncomplete", "DisableOptionObject",
            "oncompletetarget", this.gameObject,
            "ignoretimescale", true
        ));
    }

    private void DisableOptionObject()
    {
        windowOption.SetActive(false);
    }
}