using UnityEngine;
using TMPro;
public class KeyboardSound : MonoBehaviour
{
    private TMP_InputField inputField;
    private AudioSource audioSource;
    [SerializeField] private AudioClip keyboardSound;
    [SerializeField] private AudioClip backspaceSound;
    [SerializeField] private float minPitch = 0.8f;
    [SerializeField] private float maxPitch = 1.2f;

    private string previousText = "";

private void Awake()
    {
        if (inputField == null)
        {
            inputField = GetComponent<TMP_InputField>();
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    private void Start()
    {
        previousText = inputField.text;
        inputField.onValueChanged.AddListener(OnTextChanged);
    }

 private void OnTextChanged(string newText)
    {
        if (newText.Length > previousText.Length)
        {
            // Ha escrito una letra
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(keyboardSound);
        }
        else if (newText.Length < previousText.Length)
        {
            audioSource.pitch = 1f;
            // Ha borrado una letra
            audioSource.PlayOneShot(backspaceSound);
        }
        previousText = newText;
    }
    
}
