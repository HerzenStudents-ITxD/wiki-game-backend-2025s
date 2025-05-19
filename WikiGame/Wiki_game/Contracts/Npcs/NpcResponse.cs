namespace WikiGame.API.Contracts.Npcs
{
    public record NpcResponse(
        Guid Id,
        string Name,
        string Stats,
        bool IsEnemy,
        bool IsBoss,
        string Description
        );
}
