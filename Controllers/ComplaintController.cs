using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourComplaint.Models;

namespace yourComplaint.Controllers
{
    public class Complaint : Controller
    {
        //Only matches on get request
        private readonly ComplaintContext _context;
        public Complaint(ComplaintContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //It will only match on POST requests
        public async Task<IActionResult> Create([Bind("ID,Name,Mail,Company,Complain")]yourComplaint.Models.Complaint complaint)
        {
                _context.Add(complaint);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Index()
        {

            return View(await _context.Complaint.ToListAsync());
        }

    }
}