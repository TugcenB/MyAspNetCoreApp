﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisitorViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors = _context.Visitors.ToList();

            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);
            ViewBag.visitorviewModels = visitorViewModels;

            return View();
        }
    }
}
