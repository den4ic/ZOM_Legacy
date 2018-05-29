using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {
    private float destroyAfter = 15.0f;
    void Start() {
        Destroy(gameObject, destroyAfter);
    }
}


//public class DestroyAfter : MonoBehaviour
//{
//
//    public float destroyAfter = 15.0f;
//    public GameObject meleeHitEnemy;
//
//    //public GameObject CheckNPC;
//    //public Rigidbody DW;
//
//    public Transform npc_pos;
//
//    void Start()
//    {
//        // DW = CheckNPC.GetComponent<AllZombieAI>().transform.GetComponent<Rigidbody>();
//        var dwd = Instantiate(meleeHitEnemy, (npc_pos.position + new Vector3(0, 0.1f, 0)), npc_pos.rotation);
//        Destroy(gameObject, destroyAfter);
//        Destroy(dwd, destroyAfter);
//    }
//
//    void Update()
//    {
//
//    }
//
//}
