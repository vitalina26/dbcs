using System;
using DBManager.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITableService _tableService;
        private readonly IColumnService _columnService;
        private readonly IRowService _rowService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowController"/> class.
        /// </summary>
        /// <param name="databaseService">The database service</param>
        /// <param name="tableService">The table service</param>
        /// <param name="columnService">The column service</param>
        /// <param name="rowService">The row service</param>
        public RowController(IDatabaseService databaseService
            ,ITableService tableService
            ,IColumnService columnService
            ,IRowService rowService)
        {
            _databaseService = databaseService;
            _tableService = tableService;
            _columnService = columnService;
            _rowService = rowService;
        }

        /// <summary>
        /// Creates row in table with specified name in current database.
        /// </summary>
        /// <param name="tableName">The name of table.</param>
        /// <returns></returns>
        [HttpPost("CreateRow/{tableName}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult CreateRow(string tableName)
        {
            try
            { 
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if(_tableService.GetTableByName(tableName) == null)
                    return BadRequest($"Table doesn't exists");
                var result = _rowService.CreateRow(tableName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot create row");
            }

        }

        /// <summary>
        /// Deletes row by index in table with specified name in current database.
        /// </summary>
        /// <param name="tableName">The name of table.</param>
        /// <param name="rowIndex">Row index.</param>
        /// <returns></returns>
        [HttpDelete("DeleteRow/{tableName}/{rowIndex}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult DeleteRow(string tableName, int rowIndex)
        {
            try
            {
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if(_tableService.GetTableByName(tableName) == null)
                    return BadRequest($"Table doesn't exists");
                if(_rowService.GetRowByIndex(tableName, rowIndex) == null)
                    return BadRequest($"Row doesn't exists");
                var result = _rowService.DeleteRow(tableName, rowIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot delete row");
            }

        }

        /// <summary>
        /// Edits cell by row and column index in table with specified name in current database.
        /// </summary>
        /// <param name="tableName">The name of table.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="newValue">New value</param>
        /// <returns></returns>
        [HttpPut("EditCell/{tableName}/{columnIndex}/{rowIndex}/{newValue}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult EditCell(string tableName, int columnIndex, int rowIndex, string newValue)
        {
            try
            {
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if(_tableService.GetTableByName(tableName) == null)
                    return BadRequest($"Table doesn't exists");
                if(_columnService.GetColumnByIndex(tableName, columnIndex) == null)
                    return BadRequest($"Column doesn't exists");
                if(_rowService.GetRowByIndex(tableName, rowIndex) == null)
                    return BadRequest($"Row doesn't exists");
                var result = _rowService.EditCell(tableName, columnIndex, rowIndex, newValue);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot edit cell");
            }

        }
    }
}