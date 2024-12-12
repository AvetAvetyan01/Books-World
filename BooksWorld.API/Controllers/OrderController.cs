using BooksWorld.Application.Commands.OrderCommands.Create;
using BooksWorld.Application.Commands.OrderCommands.Update;
using BooksWorld.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService orderService) : ControllerBase
{
    private readonly OrderService _orderService = orderService;

    [HttpPost("create")]
    public async Task<IResult> Create(CreateOrderRequest request)
    {
        await _orderService.CreateAsync(request);

        return Results.Ok("Order created successfully");
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var order = await _orderService.GetByIdAsync(id);

        if (order == null)
            return Results.NotFound("Order not found");

        return Results.Ok(order);
    }

    [HttpPut("update")]
    public async Task<IResult> Update(UpdateOrderRequest request)
    {
        await _orderService.UpdateAsync(request);

        return Results.Ok("Order updated successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IResult> Delete(int id)
    {
        await _orderService.DeleteAsync(id);

        return Results.Ok("Order deleted successfully");
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync();

        return Results.Ok(orders);
    }
}