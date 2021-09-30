using Contracts.Contracts;
using Data.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EquipmentStateHistoryService : IEquipmentStateHistoryService
    {
        private readonly DBContext _context;
        public EquipmentStateHistoryService(DBContext context)
        {
            _context = context;
        }

        public void CreateEquipmentStateHistory(EquipmentStateHistory equipmentStateHistory)
        {
            try
            {
                _context.EquipmentStateHistories.Add(equipmentStateHistory);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }

        public void DeleteEEquipmentStateHistory(Guid equipmentId, Guid equipmentStateId)
        {
            try
            {
                var equipmentStateHistory = _context.EquipmentStateHistories.Where(x => x.EquipmentId == equipmentId && x.EquipmentStateId  == equipmentStateId).FirstOrDefault();

                if (equipmentStateHistory != null)
                {
                    _context.EquipmentStateHistories.Remove(equipmentStateHistory);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }

        public List<EquipmentStateHistory> GetEquipmentStateHistories()
        {
            var equipmentStateHistories = new List<EquipmentStateHistory>();

            try
            {
                equipmentStateHistories = _context.EquipmentStateHistories
                    .Include(x=> x.Equipment)
                    .Include(x=> x.EquipmentState)
                    .ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentStateHistories;
        }

        public List<EquipmentStateHistory> GetEquipmentStateHistoriesByEquipment(Guid equipmentId)
        {
            var equipmentStateHistories = new List<EquipmentStateHistory>();

            try
            {
                equipmentStateHistories = _context.EquipmentStateHistories.Where(x=> x.EquipmentId ==  equipmentId).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentStateHistories;
        }

        public List<EquipmentStateHistory> GetEquipmentStateHistoriesByState(Guid equipmentStateId)
        {
            var equipmentStateHistories = new List<EquipmentStateHistory>();

            try
            {
                equipmentStateHistories = _context.EquipmentStateHistories.Where(x => x.EquipmentStateId == equipmentStateId).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentStateHistories;
        }

        public string GetLastState(Guid equipmentId)
        {
            string lastState =  string.Empty;
            try
            {
                lastState = _context.EquipmentStateHistories.OrderByDescending(x=> x.Date)
                     .Join(
                             _context.EquipmentStates,
                             equipmentStateHistories => equipmentStateHistories.EquipmentStateId,
                             equipmentState => equipmentState.Id,
                             (equipmentStateHistories, equipmentState) => new { equipmentStateHistories, equipmentState }
                     ).Where(x => x.equipmentStateHistories.EquipmentId == equipmentId).FirstOrDefault().equipmentState.Name;

                
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return lastState;
        }

        public void UpdateEquipmentStateHistory(EquipmentStateHistory equipmentStateHistory)
        {
            try
            {

                var objEquipmentStateHistory = _context.EquipmentStateHistories
                    .Where(x => x.EquipmentId == equipmentStateHistory.EquipmentId && x.EquipmentStateId == equipmentStateHistory.EquipmentStateId).FirstOrDefault();

                objEquipmentStateHistory.Date = equipmentStateHistory.Date;

                _context.Entry(objEquipmentStateHistory).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }
    }
}
