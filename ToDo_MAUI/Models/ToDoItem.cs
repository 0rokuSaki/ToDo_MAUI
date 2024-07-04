﻿using SQLite;

namespace ToDo_MAUI.Models;

public class ToDoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
    public DateTime Due { get; set; }
}
