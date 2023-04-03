using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneSwitcher : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {
        //находим компонент кнопки
        Button button = GetComponent<Button>();

        //метод нажатия
        button.onClick.AddListener(SwitchToScene);
    }

    private void SwitchToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
