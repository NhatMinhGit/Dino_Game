using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {

        float speed = GameManager.Instance.gameSpeed / transform.localScale.x; // speed = giá trị của gameSpeed / tỉ lệ kích thước của giá trị x của ground
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;// (tăng giá trị của ground về hướng bên trái thì sẽ có hoạt ảnh chuyển động về hướng bên phải)
    }

}
