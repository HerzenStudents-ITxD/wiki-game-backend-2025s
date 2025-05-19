namespace WikiGame.API.Contracts.Armors
{
    public record ArmorResponse(
        Guid Id,
        string SetId,
        string Name,
        string Type,
        string Stats,
        string Description
        );
}
