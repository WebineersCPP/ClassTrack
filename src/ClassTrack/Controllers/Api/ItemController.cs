using ClassTrack.Models;
using ClassTrack.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClassTrack.Controllers.Api
{
    [Authorize]
    [Route("/api/item")]
    public class ItemController : Controller
    {
        private IClassTrackRepository _repository;

        public ItemController(IClassTrackRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("update-highlight")]
        public IActionResult UpdateItemHighlightColor(int itemId, short hcolor)
        {
            try
            {
                Item item = _repository.UpdateItemHighlightColor(itemId, hcolor);
                if (item != null)
                {
                    return Ok(item);
                }
                else
                {
                    return BadRequest($"Unable to update item. Id: {itemId}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while updating item. Id: {itemId}");
            }
        }

    }
}
