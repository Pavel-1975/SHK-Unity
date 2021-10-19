using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private GameObject _endLevel;


    public void TryEndLevel()
    {
        if (transform.childCount <= 1)
            _endLevel.SetActive(true);
    }
}
