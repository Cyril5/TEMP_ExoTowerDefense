using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    Camera _camera;

    [SerializeField] List<GameObject> clones;

    private void Awake()
    {
        clones = new();
        _camera = Camera.main;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject clone = Instantiate(towerPrefab,new Vector3(14,25,65),Quaternion.Euler(new Vector3(90,0,0)));
        //    clone.transform.position = new Vector3(Random.Range(0,10f),Random.Range(0,10f),0);
        //    clones.Add(clone);
        //}
        
        
    }

    private void OnEnable()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,1000f))
            {
                // hit point est la coordonnée 3D de l'impact
                Vector3 targetPos = hit.point;
                
                GameObject clone = Instantiate(towerPrefab, targetPos, Quaternion.identity);
                clones.Add(clone);

            }
        }

    }

    private void FixedUpdate()
    {
        
    }
}
