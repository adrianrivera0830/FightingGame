using Interfaces;
using UnityEngine;

public class PlayerRotator : MonoBehaviour,IObjectRotator
{
    [SerializeField] private Transform _player;

    public void RotateTowards(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _player.rotation = targetRotation;
        }
    }

}
