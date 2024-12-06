
using Entitas;
using UnityEngine;

public class ChangePlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerHealthGroup;

    public ChangePlayerHealthSystem(Contexts contexts)
    {
        _playerHealthGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        foreach (var entity in _playerHealthGroup.GetEntities())
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                entity.isPlayerDamaged = true; // Mark entity as damaged
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                entity.isPlayerHealed = true; // Mark entity as healed
            }
        }
    }
}
