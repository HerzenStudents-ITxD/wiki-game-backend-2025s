namespace WikiGame.API.Contracts.Npcs
{
    public record NpcRequest(
        string Name,
        string Stats,
        bool IsEnemy,
        bool IsBoss,
        string Description
        );
}
