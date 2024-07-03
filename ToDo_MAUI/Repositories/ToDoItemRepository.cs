using ToDo_MAUI.Models;
using SQLite;

namespace ToDo_MAUI.Repositories;

internal class ToDoItemRepository : IToDoItemRepository
{
    private SQLiteAsyncConnection _connection;

    public event EventHandler<ToDoItem> OnItemAdded;
    public event EventHandler<ToDoItem> OnItemUpdated;

    public async Task<List<ToDoItem>> GetItemsAsync()
    {
        await CreateConnectionAsync();
        return await _connection.Table<ToDoItem>().ToListAsync();
    }

    public async Task AddItemAsync(ToDoItem item)
    {
        await CreateConnectionAsync();
        await _connection.InsertAsync(item);
        OnItemAdded?.Invoke(this, item);
    }

    public async Task UpdateItemAsync(ToDoItem item)
    {
        await CreateConnectionAsync();
        await _connection.UpdateAsync(item);
        OnItemUpdated?.Invoke(this, item);
    }

    public async Task AddOrUpdateAsync(ToDoItem item)
    {
        if (item.Id == 0)
        {
            await AddItemAsync(item);
        }
        else
        {
            await UpdateItemAsync(item);
        }
    }

    private async Task CreateConnectionAsync()
    {
        if (_connection != null)
        {
            return;
        }

        var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var databasePath = Path.Combine(documentPath, "TodoItems.db");

        _connection = new SQLiteAsyncConnection(databasePath);
        await _connection.CreateTableAsync<ToDoItem>();

        if (await _connection.Table<ToDoItem>().CountAsync() == 0)
        {
            await _connection.InsertAsync(new ToDoItem()
            {
                Title = "Welcome to To Do app",
                Due = DateTime.Now,
            });
        }
    }
}
