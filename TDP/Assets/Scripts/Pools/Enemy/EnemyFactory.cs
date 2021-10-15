using UnityEngine;
using Game.Framework.Factory;

[CreateAssetMenu(menuName = "Factory/Enemy")]
public class EnemyFactory : FactorySO<EnemyController>
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefab = default;

    public override EnemyController Create()
    {
        return (Instantiate(enemyPrefab) as GameObject).GetComponent<EnemyController>();
    }
}
