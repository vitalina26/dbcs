using System;
using System.Linq;
using DBManager.Business.Interfaces;
using DBManager.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITableService _tableService;
        private readonly IColumnService _columnService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnController"/> class.
        /// </summary>
        /// <param name="databaseService">The database service</param>
        /// <param name="tableService">The table service</param>
        /// <param name="columnService">The column service</param>
        public ColumnController(IDatabaseService databaseService
            , ITableService tableService
            , IColumnService columnService)
        {
            _databaseService = databaseService;
            _tableService = tableService;
            _columnService = columnService;
        }

        /// <summary>
        /// Creates column in table with specified name in current database.
        /// </summary>
        /// <param name="tableName">The name of database.</param>
        /// <param name="column">New column.</param>
        /// <returns></returns>
        [HttpPost("CreateColumn/{tableName}")]
        [ProducesResponseType(200, Type = typeof(Column))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult CreateColumn(string tableName, [FromBody]Column column)
        {
            try
            {
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if(_tableService.GetTableByName(tableName) == null)
                    return BadRequest($"Table doesn't exists");
                var result = _columnService.CreateColumn(tableName, column);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot create column");
            }
        }


        /// <summary>
        /// Renames column by tableName in current database.
        /// </summary>
        /// <param name="tableName">The name of database.</param>
        /// <param name="oldName">Old column name.</param>
        /// <param name="newName">New column name</param>
        /// <returns></returns>
        [HttpPost("RenameColumn/{tableName}/{oldName}/{newName}")]
        [ProducesResponseType(200, Type = typeof(Database))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult RenameColumn(string tableName, string oldName, string newName)
        {
            try
            {
                if(_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                var table = _tableService.GetTableByName(tableName);
                if(table == null)
                    return BadRequest("Table doesn't exists");
                if (table.Columns.FirstOrDefault(i => i.Name == newName) != null)
                    return BadRequest("Column with this name already exists");
                var result = _columnService.RenameColumn(tableName, oldName, newName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot rename column");
            }
        }
        /// <summary>
        /// Deletes column by column index in table with specified name in current database.
        /// </summary>
        /// <param name="tableName">The name of table.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns></returns>
        [HttpDelete("DeleteColumn/{tableName}/{columnIndex}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult DeleteColumn(string tableName, int columnIndex)
        {
            try
            {
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if(_tableService.GetTableByName(tableName) == null)
                    return BadRequest($"Table doesn't exists");
                var result = _columnService.DeleteColumn(tableName, columnIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot delete column");
            }
        }
    }
}