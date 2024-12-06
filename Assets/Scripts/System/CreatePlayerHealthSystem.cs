
using Entitas;

public class CreatePlayerHealthSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public CreatePlayerHealthSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddPlayerHealth(100f); // Initial health set to 100
    }
}
