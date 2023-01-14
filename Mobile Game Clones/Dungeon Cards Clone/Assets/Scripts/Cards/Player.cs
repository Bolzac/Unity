using System;

public class Player : Base
{
    public static event Action<Player> OnPlayerBorn = delegate { };
    public PlayerController playerController;
    public PlayerModel playerModel;

    private void Start()
    {
        OnPlayerBorn(this);
    }
}