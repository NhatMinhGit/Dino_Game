using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;//khai báo prefab
        
        [Range(0f, 1f)]
        public float spawnChance;//Tỉ lệ spawn
    }

    public SpawnableObject[] objects;//danh sách các vật có thể spawn

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));//Invoke dùng để gọi hàm và thời gian chờ trước khi gọi hà
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;//tạo ra giá trị ngẫu nhiên từ 0.0 - 1.0

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance) // nếu spawnChance < obj.spawnChance thì sp
            {
                GameObject obstacle = Instantiate(obj.prefab);//tạo
                obstacle.transform.position += transform.position;//cộng vào để obstacle spawn lệch phải
                break;
            }

            spawnChance -= obj.spawnChance;//ví dụ nếu spawnChance = 0.3 thì sẽ bị trừ với spawnChance của object cho tới bé hơn và được in ra 
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));//lại gọi hàm để tạo thành 1 vòng lặp
    }

}
