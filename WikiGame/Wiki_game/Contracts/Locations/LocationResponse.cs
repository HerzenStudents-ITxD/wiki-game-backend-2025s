namespace WikiGame.API.Contracts.Locations
{
    public record LocationResponse(
        Guid Id,
        string Name,
        string Description
        );
}
