﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CW5.Models;
using CW5.Services;

namespace CW5.Controllers
{
    [Route("api/warehouses2")]
    [ApiController]
    public class Warehouse2Controller : ControllerBase
    {
        private readonly IDbProcedureService DbProcedureService;

        public Warehouse2Controller(IDbProcedureService DbProcedureService)
        {
            this.DbProcedureService = DbProcedureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse([FromBody] ProductWarehouse productWarehouse)
        {
            int idProductWarehouse;
            try { idProductWarehouse = await DbProcedureService.AddProductToWarehouseAsync(productWarehouse); }
            catch (Exception e) { return NotFound(e.Message); }
            return Ok($"Dodane! ID: {idProductWarehouse}!");
        }
    }
}