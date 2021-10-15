using System.Collections.Generic;
using UnityEngine;

public class EnemyRouteNode : MonoBehaviour
{
    [SerializeField] private EnemyRouteNode[] NextNodes;
    private Queue<EnemyRouteNode> nextNodes;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (nextNodes.Count == 0)
            return;

        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy == null || Vector2.Distance(transform.position, enemy.transform.position) > .1f)
            return;

        Debug.Log($"redirected {enemy.name} to {nextNodes.Peek()} : {nextNodes.Peek().transform.position}");
        enemy.RedirectTo(nextNodes.Peek().transform);
        nextNodes.Enqueue(nextNodes.Dequeue());
    }

    private void OnValidate() {
        if (NextNodes == null)
            return;

        nextNodes = new Queue<EnemyRouteNode>();
        foreach (EnemyRouteNode node in NextNodes)
        {
            nextNodes.Enqueue(node);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (nextNodes == null)
            return;

        for (int i = 0; i < nextNodes.Count; i++)
        {
            if (nextNodes.Peek() == null)
            {
                Debug.LogWarning($"null node found in enemy route!");
                return;
            }

            Gizmos.DrawLine(transform.position, nextNodes.Peek().transform.position);
            nextNodes.Enqueue(nextNodes.Dequeue());
        }
    }
}
