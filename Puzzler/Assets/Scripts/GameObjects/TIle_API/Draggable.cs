using UnityEngine;

public class Draggable : MonoBehaviour 
{
    public bool playerMovable;
    private bool canMove;
    private bool dragging;
    private Collider2D collider;
    public GameObject SpawnDragTarget;
    public GameObject SpawnTargetChecker;
    private GameObject DragTarget;
    private GameObject TargetChecker;
    private Vector3 LastValidPosition;
    private LayerMask BeltLayerMask;
    private LayerMask ValidTilelayerMask;
    //private LayerMask FloorLayerMask; //Reenable this when we implement floor tiles
   
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
        //FactoryLayerMask = 1 << 6; //belt layer (6)
        BeltLayerMask = 1 << 6 |1 << 8;
        ValidTilelayerMask = 1 << 9;
        //TODO add floor layer mask when it becomes applicable
    }

    private void Update()// code taken from here https://generalistprogrammer.com/game-design-development/unity-drag-and-drop-tutorial/
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//doesn't work for some reason when i try to simplify it
        if (Input.GetMouseButtonDown(0)) //on click down
        {
            if (playerMovable && collider == Physics2D.OverlapPoint(mousePos, BeltLayerMask))//figure out how to make it so the tiles cant be placed on eachother
            {
                canMove = true;
                GameObject g;//store as gameobject and set them to be 
                g = Instantiate(SpawnDragTarget, Vector3.zero, transform.rotation); //Creates DragTarget
                g.transform.SetParent(transform, false);//Alvin: changed transform.position to vector3.zero because it wasn't instantiating in the middle of the draggable object
                DragTarget = g;
                g = Instantiate(SpawnTargetChecker, Vector3.zero, transform.rotation); //Creates TargetChecker
                g.transform.SetParent(transform, false);
                TargetChecker = g;

                //need to initialize collision logic for targetchecker here
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging) //while dragging
        {
            //DragTarget object - visual representation of landing position
            //TargetChecker object - hidden validity checker for DragTarget
            //Check if rounded position is safe: 
            //1. Round TargetChecker's position: TargetChecker.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
            //2. Check if TargetChecker's position is valid:
            //2a: MUST be above a floor space (TODO)
            //2b: Must NOT be colliding with a belt
            //3. If the above are true, Set DragTarget's position to TargetChecker's
            //4. If checker's position is not valid, target should stay in place
            
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0); //moves tile to mouse pos

            TargetChecker.transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0); //1. Moves TargetChecker and rounds its pos to the tile grid

            //raycast check vvv

            //Temporarily move tile layer to ignore raycast
            int oldLayer = this.gameObject.layer;
            this.gameObject.layer = 2;

            //2a. TargetChecker's raycast that looks for factory tiles in the way
            RaycastHit2D notHitBelt = Physics2D.Raycast(TargetChecker.transform.position, TargetChecker.transform.forward, 0.1f, BeltLayerMask);
            if(!notHitBelt) //if none are found:
            {
                RaycastHit2D hitValidTile = Physics2D.Raycast(TargetChecker.transform.position, TargetChecker.transform.forward, 0.1f, ValidTilelayerMask);
                //check for a valid floor tile
                if (!hitValidTile)
                {
                    DragTarget.transform.position = LastValidPosition; //4. DragTarget stays in place
                }
                else
                {
                    DragTarget.transform.position = TargetChecker.transform.position; //3. move DragTarget to the checker's spot if it is valid
                    LastValidPosition = DragTarget.transform.position;
                }
            }
            else //if the checker is in an invalid space:
            {
                DragTarget.transform.position = LastValidPosition; //4. DragTarget stays in place
            }

            this.gameObject.layer = oldLayer; //put tile back to its proper layer

            if (Input.GetKeyDown("r"))
            {
                transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetMouseButtonUp(0)) //when letting go
        {
            canMove = false;
            dragging = false;
            //place the dragged tile at target location
            //destroy target and targetChecker
            try
            {
                this.transform.position = DragTarget.transform.position;// fix this later so it snaps to grid
            }
            catch(System.Exception e)
            {
                //fuck it
            }
            Destroy(DragTarget);
            Destroy(TargetChecker);
        }
    }
}
