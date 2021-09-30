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
    public class EquipmentPositionHistoryService : IEquipmentPositionHistoryService
    {
        private readonly DBContext _context;
        public EquipmentPositionHistoryService(DBContext context)
        {
            _context = context;
        }

        public void CreateEquipmentPositionHistory(EquipmentPositionHistory equipmentPositionHistory)
        {
            try
            {
                
                _context.EquipmentPositionHistories.Add(equipmentPositionHistory);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }
         

        public List<EquipmentPositionHistory> GetEquipmentPositionHistories()
        {
            var equipmentPositions = new List<EquipmentPositionHistory>();

            try
            {
                equipmentPositions = _context.EquipmentPositionHistories.ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentPositions;
        }

        public List<EquipmentPositionHistory> GetEquipmentPositionHistories(Guid equipmentId)
        {
            var equipmentPositions = new List<EquipmentPositionHistory>();

            try
            {
                equipmentPositions = _context.EquipmentPositionHistories.Where(x=> x.EquipmentId == equipmentId).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentPositions;
        }

        public EquipmentPositionHistory GetLastPosition(Guid equipmentId)
        {
            var equipmentPosition = new EquipmentPositionHistory();

            try
            {
                equipmentPosition = _context.EquipmentPositionHistories
                                    .OrderByDescending(x=> x.Date)
                                    .Where(x => x.EquipmentId == equipmentId)
                                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentPosition;
        }
    }
}
