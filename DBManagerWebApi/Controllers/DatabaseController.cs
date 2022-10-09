using System;
using System.Collections.Generic;
using DBManager.Business.Interfaces;
using DBManager.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseController"/> class.
        /// </summary>
        /// <param name="databaseService">The database service</param>
        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        /// <summary>
        /// Gets all database.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDatabases")]
        [ProducesResponseType(200, Type = typeof(List<Database>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult GetAllDatabases()
        {
            try
            {
                var result = _databaseService.GetAllDatabases();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot get databases");
            }
        }
        /// <summary>
        /// Opens database located in specified path.
        /// </summary>
        /// <param name="path">The path of database file.</param>
        /// <returns></returns>
        [HttpPost("OpenDatabase/{path}")]
        [ProducesResponseType(200, Type = typeof(Database))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult OpenDatabase(string path)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                    return BadRequest("File doesn't exists");
                var result = _databaseService.OpenDatabase(path);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot open database");
            }
        }

        /// <summary>
        /// Creates database with specified name in specified path.
        /// </summary>
        /// <param name="database">Database</param>
        /// <returns></returns>
        [HttpPost("CreateDatabase")]
        [ProducesResponseType(200, Type = typeof(Database))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult CreateDatabase([FromBody] Database database)
        {
            try
            {
                var result = _databaseService.CreateDatabase(database);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot create database");
            }
        }
        /// <summary>
        /// Saves current database.
        /// </summary>
        /// <returns></returns>
        [HttpPost("SaveDatabase")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult SaveDatabase()
        {
            try
            {
                var currentDatabase = _databaseService.GetCurrentDatabase();
                if (currentDatabase == null)
                    return BadRequest("Database doesn't exists");
                if (string.IsNullOrEmpty(currentDatabase.Name))
                    return BadRequest("Database name cannot be empty");
                if (string.IsNullOrEmpty(currentDatabase.Path))
                    return BadRequest("Database path cannot be empty");
                var result = _databaseService.SaveDatabase();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot save database");
            }
        }
        /// <summary>
        /// Deletes current database.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteDataBase")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult DeleteDataBase()
        {
            try
            {
                var currentDatabase = _databaseService.GetCurrentDatabase();
                if (currentDatabase == null)
                    return BadRequest("Database doesn`t exists");
                var result = _databaseService.DeleteDataBase();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot delete database");
            }
        }
        /// <summary>
        /// Deletes current database.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteDataBaseByPath{databasePath}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult DeleteDataBaseByPath(string databasePath)
        {
            try
            {
                var currentDatabase = _databaseService.GetDatabaseByPath(databasePath);
                if (currentDatabase == null)
                    return BadRequest("Database doesn't exists");
                var result = _databaseService.DeleteDatabaseByPath(databasePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot delete database");
            }
        }
    }
}