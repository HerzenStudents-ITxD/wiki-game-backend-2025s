namespace WikiGame.API.Contracts.Items
{
    public record ItemRequest(
        string Name,
        string Kind,
        string Description,
        bool IsDroppable,
        bool IsSellable
        );
}
