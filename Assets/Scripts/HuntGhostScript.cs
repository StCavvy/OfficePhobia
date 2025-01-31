using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public NavMeshAgent agent; // Ссылка на NavMeshAgent

    [SerializeField] bool isPlayerPositionKnown = false;
    [SerializeField] GameObject Player;

    private void Start()
    {
        SetRandomDestination(); // Назначаем случайную цель перемещения при старте
    }

    private void Update()
    {
        if (isPlayerPositionKnown == false) 
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) // Проверяем, достиг ли бот текущей цели
            {
                SetRandomDestination(); // Если достиг, назначаем новую случайную цель перемещения
            }
        }
        else if (isPlayerPositionKnown == true) 
        {
            Terminate();
        }
    }
    
    private void Rotator(Vector3 Direction)
    {
            
    }

    private void Terminate()
    {   Vector3 playerPosition = Player.transform.position; 
        Rotator(playerPosition);
        agent.SetDestination(playerPosition);
    }

    private void SetRandomDestination()
    {
        Vector3 randomPosition = GetRandomPointOnNavMesh();
        agent.SetDestination(randomPosition);
        Rotator(randomPosition); // Устанавливаем случайную позицию как цель перемещения для NavMeshAgent
        
    }
    private Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation(); // Получаем данные навигационной сетки
        int randomIndex = Random.Range(0, navMeshData.vertices.Length); // Генерируем случайный индекс точки на сетке
        Vector3 randomPoint = navMeshData.vertices[randomIndex]; // Получаем случайную точку из данных сетки
        return randomPoint;
    }
}