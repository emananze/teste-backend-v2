using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentStateService
    {
        List<EquipmentState> GetEquipmentStates();
        EquipmentState GetEquipmentState(Guid Id);
        void CreateEquipmentState(EquipmentState equipmentState);
        void DeleteEquipmentState(Guid Id);
        void UpdateEquipmentState(Guid Id, EquipmentState equipmentState);
        bool EquipmentStateExists(Guid Id);
    }
}
