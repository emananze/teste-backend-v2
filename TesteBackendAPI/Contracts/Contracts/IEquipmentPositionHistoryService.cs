using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentPositionHistoryService
    {
        List<EquipmentPositionHistory> GetEquipmentPositionHistories();
        List<EquipmentPositionHistory> GetEquipmentPositionHistories(Guid equipmentId);
        void CreateEquipmentPositionHistory(EquipmentPositionHistory equipmentPositionHistory);
        EquipmentPositionHistory GetLastPosition(Guid equipmentId);
    }
}
