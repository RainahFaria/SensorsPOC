using Sensors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensors.Services
{
    public interface ISensorsService
    {
        Task<List<Sensor>> ListSensors();
        Task<Sensor> AddSensor(SensorVm newSensor);
        Task<Sensor> GetSensorById(int id);
        Task UpdateSensor(int id, Sensor sensor);
        Task<Sensor> DeleteSensor(int id, Sensor sensor);
        bool SensorExists(int id);
    }
}
