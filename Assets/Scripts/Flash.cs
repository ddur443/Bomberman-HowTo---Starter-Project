using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    // Start is called before the first frame update
   
    
        //放闪现的按键
        public KeyCode keyCode = KeyCode.C;
        //闪现的距离
        public float moveDistance = .5f;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        release();
    }
    void release()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Terrain")
                {
                    Vector3 hitPos = hit.point;
                    Vector3 playerPos = transform.position;
                    //向量减法 和y无关，所以同步一下高度
                    playerPos.y = hitPos.y;
                    //向量减法，得到一个向量，包含方向和距离
                    Vector3 dir = (hitPos - playerPos);
                    //归一化 去除距离 ，只要方向，如果不去除距离 ，那么角色闪到鼠标点击的位置
                    dir = dir.normalized;
                    //目标点 点b =点a + 方向 * 距离;
                    Vector3 targetPos = transform.position + dir * moveDistance;
                    //计算目标点 的地面实际高度
                    targetPos.y = hit.point.y;
                    transform.position = targetPos;
                }
            }
        }
    }

}
