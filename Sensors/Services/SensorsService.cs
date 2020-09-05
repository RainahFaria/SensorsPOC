using Microsoft.EntityFrameworkCore;
using Sensors.Data;
using Sensors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensors.Services
{
    public class SensorsService : ISensorsService
    {
		private readonly SQLiteDBContext _dBContext;
		public SensorsService(SQLiteDBContext context)
		{
			_dBContext = context;
		}

		public async Task<List<Sensor>> ListSensors()
		{ 
			List<Sensor> sensorsList = await _dBContext.Sensors.OrderBy(s => s.Tag).ToListAsync();
			return sensorsList;
		}

		public async Task<Sensor> GetSensorById(int id)
		{
			return await _dBContext.Sensors.FindAsync(id);
		}

		public async Task UpdateSensor(int id, Sensor sensor)
		{
			_dBContext.Entry(sensor).State = EntityState.Modified;
			await _dBContext.SaveChangesAsync();
				return;
		}

		public async Task<Sensor> AddSensor(SensorVm newSensor)
		{
			var sensor = new Sensor();

			Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime())).TotalSeconds;
			sensor.Timestamp = unixTimestamp.ToString();
			sensor.Tag = newSensor.Tag;
			sensor.Value = newSensor.Value;

			_dBContext.Sensors.Add(sensor);
			await _dBContext.SaveChangesAsync();
			
			return sensor;
		}

		public async Task<Sensor> DeleteSensor(int id, Sensor sensor)
		{
			_dBContext.Sensors.Remove(sensor);
			await _dBContext.SaveChangesAsync();
			return sensor;
		}

		public bool SensorExists(int id)
		{
			return _dBContext.Sensors.Any(e => e.Id == id);
		}
	}
}
