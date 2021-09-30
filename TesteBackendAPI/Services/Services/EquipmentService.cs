using Contracts.Contracts;
using Data.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly DBContext _context;

        public EquipmentService(DBContext context)
        {
            _context = context;
        }

        public void CreateEquipment(Equipment equipment)
        {

            try
            {
                equipment.Id = Guid.NewGuid();
                _context.Equipment.Add(equipment);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }

        }

        public void DeleteEquipment(Guid Id)
        {
            

            try
            {
                 var equipment  =  _context.Equipment.Where(x=> x.Id ==  Id).FirstOrDefault();

                if(equipment != null)
                {
                    _context.Equipment.Remove(equipment);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                
                Log.Error(ex.StackTrace);

            }
                       
        }

        public bool EquipmentExists(Guid Id)
        {
            return _context.Equipment.Any(e => e.Id == Id);
        }

        public Equipment GetEquipment(Guid Id)
        {
            var equipment = new Equipment();


            try
            {
                throw new Exception();
                equipment = _context.Equipment.FirstOrDefault(x=> x.Id == Id);
            }
            catch (Exception ex)
            {
                
                Log.Error(ex.StackTrace);

                return null;
            }

            return equipment;
        }

        public List<Equipment> GetEquipments()
        {

            var equipments = new List<Equipment>();
            
            try
            {
                equipments = _context.Equipment.ToList();
            }
            catch (Exception ex)
            {
                
                Log.Error(ex.StackTrace);

                return null;
            }

            return equipments;
        }

        public void UpdateEquipment(Guid Id, Equipment equipment)
        {
            try
            {

                var objEquipment = _context.Equipment.Where(x => x.Id == Id).FirstOrDefault();

                objEquipment.EquipmentModelId = equipment.EquipmentModelId;
                objEquipment.Name = equipment.Name;

                _context.Entry(objEquipment).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                                
                Log.Error(ex.StackTrace);

            }
        }
    }
}
