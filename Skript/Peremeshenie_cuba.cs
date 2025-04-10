using UnityEngine;

public class Peremeshenie_kubov : MonoBehaviour
{
    public float maxMoveDistance = 1.09f;
    public string[] cubeTags;
    public bool[] moveOnXAxis;     // true - движение по оси X, false - по оси Z
    private Rigidbody[] rigidbodies;
    private bool[] isDragging;
    private Vector3[] startPositions;
    private Vector3[] initialMousePositions;


    void Start()
    {
        int numCubes = cubeTags.Length;
        if (numCubes != moveOnXAxis.Length || numCubes == 0)
        {
            Debug.LogError("Некорректная настройка массивов cubeTags и moveOnXAxis!");
            enabled = false;
            return;
        }

        rigidbodies = new Rigidbody[numCubes];
        isDragging = new bool[numCubes];
        startPositions = new Vector3[numCubes];
        initialMousePositions = new Vector3[numCubes];

        for (int i = 0; i < numCubes; i++)
        {
            GameObject cube = GameObject.FindGameObjectWithTag(cubeTags[i]);
            if (cube == null)
            {
                Debug.LogError($"Куб с тегом '{cubeTags[i]}' не найден!");
                enabled = false;
                return;
            }
            rigidbodies[i] = cube.GetComponent<Rigidbody>();
            if (rigidbodies[i] == null)
            {
                Debug.LogError($"Куб с тегом '{cubeTags[i]}' не имеет компонента Rigidbody!");
                enabled = false;
                return;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                int cubeIndex = FindCubeIndex(hit.collider.gameObject);
                if (cubeIndex != -1)
                {
                    isDragging[cubeIndex] = true;
                    startPositions[cubeIndex] = rigidbodies[cubeIndex].position;
                    initialMousePositions[cubeIndex] = Input.mousePosition;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < isDragging.Length; i++)
            {
                if (isDragging[i])
                {
                    MoveCube(i);
                    isDragging[i] = false;
                }
            }
        }
    }

    void MoveCube(int cubeIndex)
    {
        float mouseDelta = moveOnXAxis[cubeIndex] ? Input.mousePosition.x - initialMousePositions[cubeIndex].x : Input.mousePosition.y - initialMousePositions[cubeIndex].y;
        Vector3 moveDirection = moveOnXAxis[cubeIndex] ? Vector3.right * Mathf.Sign(mouseDelta) * maxMoveDistance : Vector3.forward * Mathf.Sign(mouseDelta) * maxMoveDistance;
        rigidbodies[cubeIndex].MovePosition(startPositions[cubeIndex] + moveDirection);
        
    }


    int FindCubeIndex(GameObject obj)
    {
        for (int i = 0; i < cubeTags.Length; i++)
        {
            if (obj.CompareTag(cubeTags[i]))
            {
                return i;
            }
        }
        return -1;
    }


}

