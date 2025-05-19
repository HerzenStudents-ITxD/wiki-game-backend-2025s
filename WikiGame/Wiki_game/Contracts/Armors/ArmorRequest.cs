namespace WikiGame.API.Contracts.Armors
{
    public record ArmorRequest(
        string SetId,
        string Name,
        string Type,
        string Stats,
        string Description
        );
}
