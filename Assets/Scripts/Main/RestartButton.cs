using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        // Получаем ссылку на компонент кнопки
        button = GetComponent<Button>();

        // Добавляем обработчик нажатия на кнопку
        button.onClick.AddListener(RestartScene);
    }

    void RestartScene()
    {
        // Получаем номер текущей сцены и загружаем ее заново
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
