﻿using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using web.DTO.DentalHistory;
using web.Mapper;

namespace web.Controllers.views;

public class DentalHistoryController : Controller
{
      private readonly IDentalHistoryEntityService _service;

        public DentalHistoryController(IDentalHistoryEntityService service)
        {
            _service = service;
        }

        // GET: DentalHistory/Index
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var dentalHistories = await _service.GetDentalHistoriesAsync(pageNumber, pageSize);
            var response = DentalHistoryMapper.ToDTO(dentalHistories);
            return View(response);
        }

        // GET: DentalHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DentalHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDentalHistoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var dentalHistory = await _service.CreateDentalHistoryAsync(
                    request.UserId, 
                    request.Procedures, 
                    request.ConsultationDate, 
                    request.ToothCondition
                );
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: DentalHistory/Edit/5
        public async Task<IActionResult> Edit(int dentalHistoryId)
        {
            var dentalHistory = await _service.GetDentalHistoryByIdAsync(dentalHistoryId);
            if (dentalHistory == null)
            {
                return NotFound();
            }

            UpdateDentalHistoryRequest update = new UpdateDentalHistoryRequest();
            return View(update);
        }

        // POST: DentalHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int dentalHistoryId, UpdateDentalHistoryRequest request)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateDentalHistoryUserAsync(dentalHistoryId, request.NewProcedures);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: DentalHistory/Delete/5
        public async Task<IActionResult> Delete(int dentalHistoryId)
        {
            var dentalHistory = await _service.GetDentalHistoryByIdAsync(dentalHistoryId);
            if (dentalHistory == null)
            {
                return NotFound();
            }
            return View(dentalHistory);
        }

        // POST: DentalHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int dentalHistoryId)
        {
            await _service.DeleteDentalHistoryAsync(dentalHistoryId);
            return RedirectToAction(nameof(Index));
        }
}