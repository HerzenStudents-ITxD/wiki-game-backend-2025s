namespace WikiGame.API.Contracts.Items
{
    public record ItemResponse(
        Guid Id,
        string Name,
        string Kind,
        string Description,
        bool IsDroppable,
        bool IsSellable
        );
}
