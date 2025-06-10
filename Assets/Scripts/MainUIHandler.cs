using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void StartNew()
    {
        if (nameInputField != null)
        {
            GameManager.Instance.playerName = nameInputField.text;
        }
        else
        {
            Debug.LogWarning("Name Input Field is not assigned.");
        }

        SceneManager.LoadScene(1);
    }
}
