namespace Play.Inventory.Service.Dtos
{
    public record GrantItemsDto(Guid userId, Guid CatalogItemId, int Quantity);
    public record InventoryItemDto(Guid CatalogItemId, String name, String Description, int Quantity, DateTimeOffset AcquiredDate);

    public record CatalogItemDto(Guid Id, string Name, string Description);


}