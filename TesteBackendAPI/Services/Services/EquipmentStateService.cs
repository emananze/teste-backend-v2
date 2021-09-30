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
    public class EquipmentStateService : IEquipmentStateService
    {

        private readonly DBContext _context;
        public EquipmentStateService(DBContext context)
        {
            _context = context;
        }
        public void CreateEquipmentState(EquipmentState equipmentState)
        {

            try
            {
                equipmentState.Id = Guid.NewGuid();
                _context.EquipmentStates.Add(equipmentState);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }

        }

        public void DeleteEquipmentState(Guid Id)
        {
            try
            {
                var equipmentStates = _context.EquipmentStates.Where(x => x.Id == Id).FirstOrDefault();

                if (equipmentStates != null)
                {
                    _context.EquipmentStates.Remove(equipmentStates);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }

        public bool EquipmentStateExists(Guid Id)
        {
            return _context.EquipmentStates.Any(e => e.Id == Id);
        }

        public EquipmentState GetEquipmentState(Guid Id)
        {
            var equipmentState = new EquipmentState();


            try
            {
                equipmentState = _context.EquipmentStates.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentState;
        }

        public List<EquipmentState> GetEquipmentStates()
        {
            var equipmentState = new List<EquipmentState>();

            try
            {
                equipmentState = _context.EquipmentStates.ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentState;
        }

        public void UpdateEquipmentState(Guid Id, EquipmentState equipmentState)
        {
            try
            {

                var objEquipmentState = _context.EquipmentStates.Where(x => x.Id == Id).FirstOrDefault();

                objEquipmentState.Name = equipmentState.Name;
                objEquipmentState.Color = equipmentState.Color;

                _context.Entry(objEquipmentState).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }
    }
}
