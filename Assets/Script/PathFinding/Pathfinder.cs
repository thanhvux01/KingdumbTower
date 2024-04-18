using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int endCoordinates;

    Node startNode;
    Node endNode;
    Node currentSearchNode;

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    GridManager gridManager;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }


    }
    void Start()
    {
        //    startNode = new Node(startCoordinates,true);
        //     endNode =  new Node(endCoordinates,true);
        //Gán điểm đến vào điểm đi tham chiếu tới giá trị trong gridmanager 
        startNode = gridManager.Grid[startCoordinates];
        endNode = gridManager.Grid[endCoordinates];
        BFS();
        BuildPath();

    }
    public List<Node> GetNewPath()
    {

        gridManager.ResetNode();
        BFS();
        return BuildPath();

    }
    void ExploreNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        if (node.coordinates != null)
        {
            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighborCoord = node.coordinates + direction;
                Node neighborNode = gridManager.GetNode(neighborCoord);
                if (neighborNode != null)
                {
                    neighbors.Add(neighborNode);
                    // grid[neighborCoord].isExplored = true;
                    // Debug.Log(grid[neighborCoord].coordinates);
                    // grid[currentSearchNode.coordinates].isPath = true;

                }

            }
            foreach (Node neighbor in neighbors)
            {
                // kiểm tra 4 node xung quanh đã đi hay chưa nếu chưa thì đánh dấu đã đi
                if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
                {

                    neighbor.connectedTo = node;

                    reached.Add(neighbor.coordinates, neighbor);
                    //Thêm neighbor vào vùng cần kiểm tra
                    frontier.Enqueue(neighbor);
                }
            }

        }
        else
        {
            Debug.Log("Không thể xuất phát vị trí này");
        }
    }

    void BFS()
    {
        frontier.Clear();
        reached.Clear();
        //reset moi khi tim kiem duong di moi

        bool isRunning = true;
        //Thêm startnode để kiểm tra
        frontier.Enqueue(startNode);
        //Đánh dấu starnode đã đi qua
        reached.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            // Lấy node hiện tại là toạ độ ban đầu và xoá nó khỏi hàng chờ
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            // kiểm tra xem node hiện tại có phải là điểm đến nếu không thì sẽ tiêp tục tìm những node xung quanh 
            //kiểm tra 4 ô xung quanh của node hiện tại
            ExploreNeighbors(currentSearchNode);
            if (currentSearchNode.coordinates == endCoordinates)
            {
                isRunning = false;
            }

        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        path.Add(currentNode);
        //moi node chi co 1 connected 
        //xet tu diem den keo ve diem xuat phat
        while (currentNode.connectedTo != null)
        {
            currentNode.isExplored = false;
            currentNode.isPath = true;
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);

        }
        //dao nguoc duong di 
        path.Reverse();
        return path;

    }

    public bool WillInterferePath(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {

            bool prevState = grid[coordinates].isWalkable;
            grid[coordinates].isWalkable = false;
            //set diem hien tai khong the di qua duoc sau do tim duong di
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = true;
             //neu duong di < 1 thi khong the dat duoc no se block enemies
            if (newPath.Count < 1)
            {
                GetNewPath();
                return true;
            }

            
        }
        return false;

    }
}
