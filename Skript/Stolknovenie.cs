using UnityEngine;

public class Stolknovenie : MonoBehaviour
{
    public string[] cubeTags;
    [SerializeField] GameObject _oknoProigrisha;
    [SerializeField] GameObject _oknoIgrovoe;
    void Start()
    {
        //Убедитесь, что каждому GameObject с тегом из cubeTags назначен этот скрипт
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in cubeTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log("Ты проиграл!");
                _oknoIgrovoe.SetActive(false);
                _oknoProigrisha.SetActive(true);
                // Добавьте здесь другие действия, например, остановку игры
                break; 
            }
        }
    }
}
