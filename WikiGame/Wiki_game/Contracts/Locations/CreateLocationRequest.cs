namespace WikiGame.API.Contracts.Locations;

public record CreateLocationRequest(
    string Name,
    string Description
    );