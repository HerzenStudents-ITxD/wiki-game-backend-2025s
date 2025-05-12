namespace WikiGame.API.Contracts.Armors;

public record GetArmorRequest(string? Search, string? SortItem, string? SortOrder);
