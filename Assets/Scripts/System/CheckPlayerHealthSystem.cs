
using Entitas;
using UnityEngine;

public class CheckPlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerHealthGroup;

    public CheckPlayerHealthSystem(Contexts contexts)
    {
        _playerHealthGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        foreach (var entity in _playerHealthGroup.GetEntities())
        {
            if (entity.isPlayerDamaged)
            {
                // Reduce health by 10, floored at 0
                entity.ReplacePlayerHealth(Mathf.Max(0, entity.playerHealth.Value - 10));
                entity.isPlayerDamaged = false; // Remove tag
            }

            if (entity.isPlayerHealed)
            {
                // Increase health by 10, capped at 100
                entity.ReplacePlayerHealth(Mathf.Min(100, entity.playerHealth.Value + 10));
                entity.isPlayerHealed = false; // Remove tag
            }
        }
    }
}
