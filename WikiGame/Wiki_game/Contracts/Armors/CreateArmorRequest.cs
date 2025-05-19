namespace WikiGame.API.Contracts.Armors;

public record CreateArmorRequest(
    Guid SetId,
    string Name,
    string Type,
    string Stats,
    string Description
    );
