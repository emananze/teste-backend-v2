using Contracts.Contracts;
using Data.Context;
using Entities.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EquipmentModelStateHourlyEarningService : IEquipmentModelStateHourlyEarningService
    {

        private readonly DBContext _context;
        public EquipmentModelStateHourlyEarningService(DBContext context)
        {
            _context = context;
        }

        public void CreateEquipmentModelStateHourly(EquipmentModelStateHourlyEarning equipmentModelStateHourly)
        {

            try
            {

                _context.EquipmentModelStateHourlyEarnings.Add(equipmentModelStateHourly);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }

        }

        public List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlys()
        {
            var equipmentModelStateHourlys = new List<EquipmentModelStateHourlyEarning>();

            try
            {
                equipmentModelStateHourlys = _context.EquipmentModelStateHourlyEarnings.ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentModelStateHourlys;
        }

        public List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlysByModel(Guid equipmentModelId)
        {
            var equipmentModelStateHourlys = new List<EquipmentModelStateHourlyEarning>();

            try
            {
                equipmentModelStateHourlys = _context.EquipmentModelStateHourlyEarnings.Where(x=> x.EquipmentModelId == equipmentModelId).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentModelStateHourlys;
        }

        public List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlysByState(Guid equipmentStateId)
        {
            var equipmentModelStateHourlys = new List<EquipmentModelStateHourlyEarning>();

            try
            {
                equipmentModelStateHourlys = _context.EquipmentModelStateHourlyEarnings.Where(x => x.EquipmentStateId == equipmentStateId).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentModelStateHourlys;
        }
    }
}
