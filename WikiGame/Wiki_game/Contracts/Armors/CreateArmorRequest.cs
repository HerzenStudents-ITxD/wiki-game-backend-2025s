namespace WikiGame.API.Contracts.Armors;

public record CreateArmorRequest(
    string Name,
    string Type,
    string Stats,
    string Description
    );
