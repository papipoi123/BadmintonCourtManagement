using Applications.Interfaces;
using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.Response;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HolidayController : ControllerBase
	{
		private readonly IHolidayService _holidayService;

		public HolidayController(IHolidayService holidayService)
		{
			_holidayService = holidayService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllHolidayAsync(int pageNumber = 0, int pageSize = 10)
		{
			var result = await _holidayService.GetAllHolidayAsync(pageNumber, pageSize);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddHolidayAsync(HolidayViewModel createHolidayViewModel)
		{
			var result = await _holidayService.AddHolidayAsync(createHolidayViewModel);
			return Ok(result);
		}

		[HttpPut("{holidayId}")]
		public async Task<IActionResult> UpdateHolidatAsync(int holidayId, HolidayViewModel updateHolidayViewModel)
		{
			var result = await _holidayService.UpdateHolidayAsync(holidayId, updateHolidayViewModel);
			return Ok(result);
		}

		[HttpDelete("{holidayId}")]
		public async Task<IActionResult> DeleteHolidatAsync(int holidayId)
		{
			var result = await _holidayService.RemoveHolidayAsync(holidayId);
			return Ok(result);

		}

		[HttpGet("GetHolidayByDate")]
		public async Task<IActionResult> GetHolidayByDate(DateTime date)
		{
			var result = await _holidayService.GetHoliddateByDateAsync(date);
			return Ok(result);
		}

	}
}
