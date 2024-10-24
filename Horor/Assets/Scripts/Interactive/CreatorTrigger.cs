using UnityEngine;

public class CreatorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject prefabEffect;
    [SerializeField] private bool _oneShoot = false;
    [SerializeField] private Transform _positionSpawn;
    private bool _active = true;

    void OnTriggerEnter(Collider other)
    {
        if (_active)
        {
            if (other.tag == "Player")
            {
                GameObject objectEffect = Instantiate(prefabEffect,_positionSpawn.position,_positionSpawn.rotation);
                if (_oneShoot)
                {
                    _active = false;
                }
            }
        }
    }
}
