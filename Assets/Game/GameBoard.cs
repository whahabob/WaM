using UnityEngine;
/// <summary>
/// Holds information about the tiles and Occupants on the tiles
/// Will create board on new game start
/// </summary>
public class GameBoard : UIComponent, IEventHandler<MoleClearedEvent>,  IEventHandler<MoleSpawnedEvent> 
{
    public int rows;
    public int columns;
    public GameObject tilePrefab;
    public GameObject rowPrefab;
    private Tile[,] tiles;
    public RectTransform rowTransform;
    private bool initialized = false;

    private void Awake()
    {
        WaMEventSystem.Instance.Subscribe((IEventHandler<MoleClearedEvent>) this);
        WaMEventSystem.Instance.Subscribe((IEventHandler<MoleSpawnedEvent>)this);
    }

    public void CreateBoard(int size)
    {
        //If GameObjects are created, reset the tiles
        if(initialized)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    tiles[i, j].Reset();
                }
            }
            return;
        }

        tiles = new Tile[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            GameObject row = Instantiate(rowPrefab, rowTransform);
            for (int j = 0; j < columns; j++)
            {
                GameObject tileObject = Instantiate(tilePrefab);
                
                tileObject.transform.SetParent(row.transform);
                tileObject.transform.localScale = Vector3.one;

                Tile tile = tileObject.GetComponent<Tile>();
                tile.Position = new Vector2Int(i, j);
                tiles[i, j] = tile;
            }
        }
        initialized = true;
        
       
    }

    public Tile GetTile(int row, int column)
    {
        return tiles[row, column];
    }
    private void SetOccupant(Tile tile, Occupant occupant)
    {
        occupant.transform.SetParent(tile.OccupantTransform, false);
        tile.Occupant = occupant;
        tiles[tile.Position.x, tile.Position.y] = tile;
    }

    private void ClearOccupant(Tile tile)
    {
       // Tile tempTile = tiles[tile.Position.x, tile.Position.y];
      //  tiles[tile.Position.x, tile.Position.y] = tempTile;
    }

    public void OnEvent(MoleClearedEvent args)
    {
        ClearOccupant(args.Tile);
    }

    public void OnEvent(MoleSpawnedEvent args)
    {
        SetMoleOnTile(args.Tile, (Mole)args.NewOccupant);
    }

    void SetMoleOnTile(Tile tile, Mole mole)
    {
        mole.transform.SetParent(tile.OccupantTransform, false);
        tile.Occupant = mole;
        mole.Initialize(tile);
        tiles[tile.Position.x, tile.Position.y] = tile;
    }
}