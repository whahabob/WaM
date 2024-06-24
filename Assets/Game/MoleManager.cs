using UnityEngine;
/// <summary>
/// MoleManager initialises and creates the Moles on the tiles and notifies other classes with the WaMSystem of the newly spawned mole
/// </summary>
public class MoleManager : MonoBehaviour, IEventHandler<StartOccupantSpawning<Mole>>, IEventHandler<MoleClearedEvent>, IEventHandler<GameStartedEvent>
{
    public GameObject molePrefab;
    public GameBoard gameBoard;

    private void Awake()
    {
        WaMEventSystem.Instance.Subscribe((IEventHandler<StartOccupantSpawning<Mole>>)this);
        WaMEventSystem.Instance.Subscribe((IEventHandler<MoleClearedEvent>)this);
        WaMEventSystem.Instance.Subscribe((IEventHandler<GameStartedEvent>)this);
    }

    public void SpawnAllMoles()
    {
        // Example logic to start spawning moles
        for (int i = 0; i < gameBoard.rows; i++)
        {
            for (int j = 0; j < gameBoard.columns; j++)
            {
                Tile tile = gameBoard.GetTile(i, j);
                if (tile != null)
                {
                    SpawnMoleOnTile(tile);
                }
            }
        }
    }

    public void ClearAllMoles()
    {
        // Example logic to stop spawning moles
        for (int i = 0; i < gameBoard.rows; i++)
        {
            for (int j = 0; j < gameBoard.columns; j++)
            {
                Tile tile = gameBoard.GetTile(i, j);
                if (tile != null)
                {
                    ClearMoleOnTile(tile);
                }
            }
        }
    }

    public void SpawnMoleOnTile(Tile tile)
    {
        GameObject mole = Instantiate(molePrefab, tile.OccupantTransform);
        mole.GetComponent<Mole>().Initialize(tile);
        WaMEventSystem.Instance.Notify(new MoleSpawnedEvent { Tile = tile, NewOccupant = mole.GetComponent<Mole>() });
    }

    public void ClearMoleOnTile(Tile tile)
    {
        if (tile.Occupant == null)
        {
            tile.Reset();
            return;
        }
        if(tile?.Occupant.UIObject != null)
        {
            Destroy(tile.Occupant.UIObject);
            tile.Occupant = null;
        }
        //Replace with a dedicated spawn system
        Timer timer = WaMTimerManager.Instance.AddTimer(Random.Range(2, 12), () => SpawnMoleOnTile(tile));
    }

    public void OnEvent(StartOccupantSpawning<Mole> args)
    {
        SpawnAllMoles();
        ClearAllMoles();
    }

    public void OnEvent(MoleClearedEvent args)
    {
       ClearMoleOnTile(args.Tile);
    }

    public void OnEvent(GameStartedEvent args)
    {
        SpawnAllMoles();
        ClearAllMoles();
    }
}