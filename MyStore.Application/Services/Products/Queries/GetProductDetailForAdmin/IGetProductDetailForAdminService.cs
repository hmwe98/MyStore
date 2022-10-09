using MyStore.Common.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.Queries
    .GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdmindto> Execute(long Id);

    }
}
