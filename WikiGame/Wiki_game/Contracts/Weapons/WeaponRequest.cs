namespace WikiGame.API.Contracts.Weapons
{
    public record WeaponRequest(
        string Name,
        string Type,
        string Stats,
        string Description
        );
}
