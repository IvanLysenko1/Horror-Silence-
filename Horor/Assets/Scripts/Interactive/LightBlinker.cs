using System.Collections;
using UnityEngine;

public class LightBlinker : MonoBehaviour
{
    public GameObject lightBlinked;                 //������ ������� ������ ���������

    [SerializeField] private bool _oneShoot = false;

    private bool _active = true;

    void OnTriggerEnter(Collider other)
    {    
        if(_active)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Blink());
                if(_oneShoot)
                {
                    _active = false;
                }
            }
        }      
    }

    IEnumerator Blink()
    {
        // ������ ���-�� ������
        int blinkCount = Random.Range(3, 7);

        for (int i = 0; i < blinkCount * 2; i++)
        {
            //������ ����� ����� ������� (��� �� ���������� ������� � ��������� ��������)
            float blinkTime = Random.Range(0.05f, 0.4f);
            yield return new WaitForSecondsRealtime(blinkTime);
            lightBlinked.SetActive(!lightBlinked.activeSelf);
        }

    }
}
