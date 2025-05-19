namespace WikiGame.API.Contracts.Locations;

public record LocationDto(
    Guid Id,
    string Name,
    string Description
    );