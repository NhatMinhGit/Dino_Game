using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        //Lấy giá trị của vị trí rìa bên trái - 2 ( để sau khi chướng ngại vật đi qua sẽ xóa nó ) 
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 4f;
    }

    private void Update()
    {

        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime; //di chuyển chướng ngại vật từ trái sang phải (sẽ nhanh dần dựa vào gameSpeed

        if (transform.position.x < leftEdge) {//khi di chuyển qua giá trị leftEdge sẽ bị xóa để tối ưu
            Destroy(gameObject);
        
        }
    }

}
