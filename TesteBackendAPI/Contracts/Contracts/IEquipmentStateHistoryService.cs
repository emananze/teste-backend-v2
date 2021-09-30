using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentStateHistoryService
    {
        List<EquipmentStateHistory> GetEquipmentStateHistories();
        List<EquipmentStateHistory> GetEquipmentStateHistoriesByEquipment(Guid equipmentId);
        List<EquipmentStateHistory> GetEquipmentStateHistoriesByState(Guid equipmentStateId);
        void CreateEquipmentStateHistory(EquipmentStateHistory equipmentStateHistory);
        string GetLastState(Guid equipmentId);
    }
}
