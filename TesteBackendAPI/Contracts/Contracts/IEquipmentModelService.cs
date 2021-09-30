using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentModelService
    {
        List<EquipmentModel> GetEquipmentModels();
        EquipmentModel GetEquipmentModel(Guid Id);
        void CreateEquipmentModel(EquipmentModel equipmentModel);
        void DeleteEquipmentModel(Guid Id);
        void UpdateEquipmentModel(Guid Id, EquipmentModel equipmentModel);
        bool EquipmentModelExists(Guid Id);
    }
}
