using System;
using System.Linq;
using DBManager.Business.Interfaces;
using DBManager.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITableService _tableService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableController"/> class.
        /// </summary>
        /// <param name="databaseService">The database service</param>
        /// <param name="tableService">The table service</param>
        public TableController(IDatabaseService databaseService
            , ITableService tableService)
        {
            _databaseService = databaseService;
            _tableService = tableService;
        }

        /// <summary>
        /// Creates table with specified name in current database.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns></returns>
        [HttpPost("CreateTable/{name}")]
        [ProducesResponseType(200, Type = typeof(Table))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult CreateTable(string name)
        {
            try
            {
                var currentDatabase = _databaseService.GetCurrentDatabase();
                if (currentDatabase == null)
                    return BadRequest("Database doesn't exists");
                if (currentDatabase.Tables.FirstOrDefault(i => i.Name == name) != null)
                    return BadRequest("Table with this name already exists");
                var result = _tableService.CreateTable(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot create table");
            }
        }


        /// <summary>
        /// Gets table with specified name in current database.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns></returns>
        [HttpGet("GetTableByName/{name}")]
        [ProducesResponseType(200, Type = typeof(Table))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult GetTableByName(string name)
        {
            try
            {
                var currentDatabase = _databaseService.GetCurrentDatabase();
                if (currentDatabase == null)
                    return BadRequest("Database doesn't exists");
                if (!currentDatabase.Tables.Exists(i => i.Name == name))
                    return BadRequest("Table with this name doesn't exists");
                var result = _tableService.CreateTable(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot get table");
            }
        }

        /// <summary>
        /// Deletes table by specified name in current database.
        /// </summary>
        /// <param name="name">The name of table.</param>
        /// <returns></returns>
        [HttpDelete("DeleteTable/{name}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult DeleteTable(string name)
        {
            try
            {
                var currentDatabase = _databaseService.GetCurrentDatabase();
                if (currentDatabase == null)
                    return BadRequest("Database doesn't exists");
                if (currentDatabase.Tables.FirstOrDefault(i => i.Name == name) == null)
                    return BadRequest("Table doesn't exists");
                var result = _tableService.DeleteTable(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot open database");
            }
        }

        /// <summary>
        /// Gets difference of tables.
        /// </summary>
        /// <param name="firstTableName">The name of the first table.</param>
        /// <param name="secondTableName">The name of the second table</param>
        /// <returns></returns>
        [HttpPost("Difference/{firstTableName}/{secondTableName}")]
        [ProducesResponseType(200, Type = typeof(Table))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Difference(string firstTableName, string secondTableName)
        {
            try
            {
                if (_databaseService.GetCurrentDatabase() == null)
                    return BadRequest("Database doesn't exists");
                if (_tableService.GetTableByName(firstTableName) == null)
                    return BadRequest($"Table with name {firstTableName} doesn't exists");
                if (_tableService.GetTableByName(secondTableName) == null)
                    return BadRequest($"Table with name {secondTableName} doesn't exists");
                var result = _tableService.Difference(firstTableName, secondTableName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot get result");
            }
        }
    }
}