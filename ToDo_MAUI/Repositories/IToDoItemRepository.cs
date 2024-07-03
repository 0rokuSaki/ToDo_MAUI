using ToDo_MAUI.Models;

namespace ToDo_MAUI.Repositories;

internal interface IToDoItemRepository
{
    event EventHandler<ToDoItem> OnItemAdded;
    event EventHandler<ToDoItem> OnItemUpdated;
    Task<List<ToDoItem>> GetItemsAsync();
    Task AddItemAsync(ToDoItem item);
    Task UpdateItemAsync(ToDoItem item);
    Task AddOrUpdateAsync(ToDoItem item);
}
