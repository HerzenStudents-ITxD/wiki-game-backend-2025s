namespace WikiGame.API.Contracts.Weapons
{
    public record WeaponResponse(
        Guid Id,
        string Name,
        string Type,
        string Stats,
        string Description
        );
}
