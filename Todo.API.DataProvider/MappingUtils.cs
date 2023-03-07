using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.API.DataProvider.Entities;
using Todo.Shared;

namespace Todo.API.DataProvider
{
    internal static class MappingUtils
    {
        public static TodoItemModel ModelFromEntity(TodoItem entity)
        {
            return new TodoItemModel
            {
                Id = entity.PublicId,
                Title = entity.Title,
                IsDone = entity.IsDone
            };
        }        
    }
}
