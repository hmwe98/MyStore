using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndPoint.Site.Models;
using MyStore.Application.Services.Common.Queries.GetSlider;
using EndPoint.Site.Models.ViewModels.HomePages;
using MyStore.Application.Interfaces.FacadPatterns;
using MyStore.Application.Services.Products.Queries.GetProductForSite;
using MyStore.Application.Services.Common.Queries.GetHomePageImages;
using Microsoft.AspNetCore.Http;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetSliderService _getSliderService;
        private readonly IProductFacad _productFacad;
        private readonly IGetHomePageImagesService
            _homePageImagesService;
        public HomeController(IGetSliderService getSliderService,
            IProductFacad productFacad,
            IGetHomePageImagesService getHomePageImagesService)
        {
            _getSliderService = getSliderService;
            _homePageImagesService = getHomePageImagesService;
            _productFacad = productFacad;
        }        
        public IActionResult Index()
        {            
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImagesService.Execute().Data,
                Camera = _productFacad.GetProductForSiteService.Execute
                (Ordering.theNewest
                , null, 1, 6, 1).Data.Products,
            };
            return View(homePage);
        }           
    }
}
