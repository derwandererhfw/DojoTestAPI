using Microsoft.AspNetCore.Mvc;

namespace DojoTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADOWebhookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CreatedItem workItemTypeModel)
        {
            if (workItemTypeModel == null || string.IsNullOrWhiteSpace(workItemTypeModel.resource.fields.WorkItemType))
            {
                return BadRequest("System.WorkItemType darf nicht leer sein.");
            }

            CreatedItemResponse response = new CreatedItemResponse()
            {
                EventType = workItemTypeModel.EventType,
                MessageText = workItemTypeModel.Message.Text,
                ResourceId = workItemTypeModel.resource.id,
                WorkItemType = workItemTypeModel.resource.fields.WorkItemType
            };

            DatabaseServices.AdoWebhook(response);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAdoWebhook(int id)
        {
            try
            {
                CreatedItemResponse retrievedItem = DatabaseServices.GetAdoWebhook(id);

                if (retrievedItem == null)
                {
                    return NotFound("Item not found");
                }

                return Ok(retrievedItem);
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, return error response, etc.)
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
