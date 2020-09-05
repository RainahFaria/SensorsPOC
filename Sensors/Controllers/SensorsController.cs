using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensors.Data;
using Sensors.Models;
using Sensors.Services;

namespace Sensors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorsService _service;

        public SensorsController(ISensorsService sensorsService)
        {
            _service = sensorsService;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> ListSensors()
        {
            return await _service.ListSensors();
        }

        // GET: api/Sensors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            Sensor sensor = await _service.GetSensorById(id);
            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        // PUT: api/Sensors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor sensor)
        {
            try
            {
                if (id != sensor.Id)
                {
                    return BadRequest();
                }
                
                await _service.UpdateSensor(id, sensor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();         
        }

        // POST: api/Sensors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(SensorVm newSensor)
        {
            await _service.AddSensor(newSensor);

            return CreatedAtAction("GetSensor", new { id = newSensor.Id }, newSensor);
        }

        // DELETE: api/Sensors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensor>> DeleteSensor(int id)
        {
            Sensor sensor = await _service.GetSensorById(id);
            if (sensor == null)
            {
                return NotFound();
            }

            await _service.DeleteSensor(id, sensor);

            return sensor;
        }

        private bool SensorExists(int id)
        {
            return _service.SensorExists(id);
        }
    }
}
