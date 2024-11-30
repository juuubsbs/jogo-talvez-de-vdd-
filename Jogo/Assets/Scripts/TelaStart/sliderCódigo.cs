using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider; // Referência para o Slider
    private AudioSource audioSource; // Referência para o AudioSource
    [SerializeField] private AudioMixer audioMixer; // Referência para o AudioMixer

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtém o componente AudioSource do GerenciadorDeJogo

        // Carrega o volume salvo no PlayerPrefs, se existir, ou define um valor padrão
        float volumeSalvo = PlayerPrefs.GetFloat("volume", 0.5f);
        audioSource.volume = volumeSalvo; // Define o volume do AudioSource
        volumeSlider.value = volumeSalvo; // Define o valor inicial do Slider para o volume salvo

        volumeSlider.onValueChanged.AddListener(SetVolume); // Adiciona um listener para o evento de mudança de valor do Slider
    }

    void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1);
        
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20); // Define o volume do AudioMixer
        PlayerPrefs.SetFloat("volume", volume); // Salva o volume no PlayerPrefs
        PlayerPrefs.Save(); // Garante que o PlayerPrefs seja salvo
    }
}
