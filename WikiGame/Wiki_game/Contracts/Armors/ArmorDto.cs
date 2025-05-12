namespace WikiGame.API.Contracts.Armors;

public record ArmorDto(
    Guid Id,
    Guid SetId,
    string Name,
    string Type,
    string Stats,
    string Description
    );