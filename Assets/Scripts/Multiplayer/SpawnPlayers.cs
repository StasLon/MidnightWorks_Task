using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MidnightTestTask.Scripts.Multiplayer
{
    public class SpawnPlayers : MonoBehaviour
    {
        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private Transform carPos;

        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private void Start()
        {
            Vector3 randomPosition = new Vector3(Random.Range(carPos.transform.position.x, carPos.transform.position.x +6f), carPos.transform.position.y, carPos.transform.position.z);
            PhotonNetwork.Instantiate(_carPrefab.name, randomPosition, _carPrefab.transform.rotation);
        }
    }
}
