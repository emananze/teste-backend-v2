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
    public class EquipmentModelService : IEquipmentModelService
    {

        private readonly DBContext _context;
        public EquipmentModelService(DBContext context)
        {
            _context = context;
        }
        public void CreateEquipmentModel(EquipmentModel equipmentModel)
        {
            try
            {
                equipmentModel.Id = Guid.NewGuid();
                _context.EquipmentModels.Add(equipmentModel);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }

        public void DeleteEquipmentModel(Guid Id)
        {
            try
            {
                var equipmentModels = _context.EquipmentModels.Where(x => x.Id == Id).FirstOrDefault();

                if (equipmentModels != null)
                {
                    _context.EquipmentModels.Remove(equipmentModels);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }

        public bool EquipmentModelExists(Guid Id)
        {
            return _context.EquipmentModels.Any(e => e.Id == Id);
        }

        public EquipmentModel GetEquipmentModel(Guid Id)
        {
            var equipmentModel = new EquipmentModel();


            try
            {
                equipmentModel = _context.EquipmentModels.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentModel;
        }

        public List<EquipmentModel> GetEquipmentModels()
        {
            var equipmentModels = new List<EquipmentModel>();

            try
            {
                equipmentModels = _context.EquipmentModels.ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

                return null;
            }

            return equipmentModels;
        }

        public void UpdateEquipmentModel(Guid Id, EquipmentModel equipmentModel)
        {

            try
            {

                var objEquipmentModel = _context.EquipmentModels.Where(x => x.Id == Id).FirstOrDefault();

                objEquipmentModel.Name = equipmentModel.Name;

                _context.Entry(objEquipmentModel).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                Log.Error(ex.StackTrace);

            }
        }
    }
}
