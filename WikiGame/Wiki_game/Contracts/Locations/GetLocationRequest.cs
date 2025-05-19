namespace WikiGame.API.Contracts.Locations;

public record GetLocationRequest(string? Search, string? SortItem, string? SortOrder);
