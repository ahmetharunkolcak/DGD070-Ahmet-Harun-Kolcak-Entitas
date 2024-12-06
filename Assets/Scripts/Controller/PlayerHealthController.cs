using UnityEngine; 
using Entitas;     
public class PlayerHealthController : MonoBehaviour
{
    private Systems _systems;

    private void Start()
    {
        
        var contexts = Contexts.sharedInstance;

        
        _systems = new Feature("PlayerHealth")
            .Add(new PlayerHealthFeature(contexts));

        
        _systems.Initialize();
    }

    private void Update()
    {
        
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        
        _systems.TearDown();
    }
}
