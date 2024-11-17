using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider; // Referência para o Slider
    private AudioSource audioSource; // Referência para o AudioSource

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
        audioSource.volume = volume; // Define o volume do AudioSource
        PlayerPrefs.SetFloat("volume", volume); // Salva o volume no PlayerPrefs
        PlayerPrefs.Save(); // Garante que o PlayerPrefs seja salvo
    }
}
