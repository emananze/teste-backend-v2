using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contracts
{
    public interface IEquipmentModelStateHourlyEarningService
    {
        List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlys();
        List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlysByState(Guid equipmentStateId);
        List<EquipmentModelStateHourlyEarning> GetEquipmentModelStateHourlysByModel(Guid equipmentModelId);
        void CreateEquipmentModelStateHourly(EquipmentModelStateHourlyEarning equipmentModelStateHourly);
    }
}
