using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentService
    {
        List<Equipment> GetEquipments();
        Equipment GetEquipment(Guid Id);
        void CreateEquipment(Equipment equipment);
        void DeleteEquipment(Guid Id);
        void UpdateEquipment(Guid Id, Equipment equipment);
        bool EquipmentExists(Guid Id);

    }
}
