using UnityEngine;

public class Stolknovenie : MonoBehaviour
{
    public string[] cubeTags;
    [SerializeField] GameObject _oknoProigrisha;
    [SerializeField] GameObject _oknoIgrovoe;
    void Start()
    {
        //���������, ��� ������� GameObject � ����� �� cubeTags �������� ���� ������
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in cubeTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log("�� ��������!");
                _oknoIgrovoe.SetActive(false);
                _oknoProigrisha.SetActive(true);
                // �������� ����� ������ ��������, ��������, ��������� ����
                break; 
            }
        }
    }
}
