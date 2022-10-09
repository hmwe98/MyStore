using MyStore.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderSericeDto request);
    }
}
