using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TargetInfo : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0,0,0);
    private GameObject target;
    [SerializeField]
    public bool dropText = false;
    // Start is called before the first frame update
    
    void Start()
    {
        target = new GameObject();
        target.transform.position = new Vector3(transform.position.x + Offset.x,transform.position.y + Offset.y,transform.position.z + Offset.z);
        target.transform.rotation = transform.rotation;
        // Set name
        target.name = "Target";
        // Set as child of current object
        target.transform.parent = transform;
        // Find Canvas in children
        TextMeshProUGUI tmpro = GetComponentInChildren<TextMeshProUGUI>();
        if (tmpro != null){
            tmpro.text = transform.name;
            // Get tmpro parent and set as child of scene
            if (dropText){
                
                tmpro.transform.parent.parent = null;
                tmpro.transform.parent.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
            }
        }
    }
    public void SetOffset(Vector3 offset)
    {
        Offset = offset;
        target.transform.position = new Vector3(transform.position.x + Offset.x,transform.position.y + Offset.y,transform.position.z + Offset.z);
        target.transform.rotation = transform.rotation;
    }
    public Vector3 GetTargetPosition()
    {
        return target.transform.position;
    }
    public Quaternion GetTargetRotation()
    {
        return target.transform.rotation;
    }
    public GameObject GetTarget()
    {
        return target;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
