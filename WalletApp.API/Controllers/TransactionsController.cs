﻿using Microsoft.AspNetCore.Mvc;
using WalletApp.Core.Models;
using WalletApp.Service;

namespace WalletApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("blocs")]
    public IActionResult GetBlocs()
    {
        return Ok(_transactionService.GetBlock());
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetTransactionsList([FromRoute] string userId)
    {

        return Ok(await _transactionService.GetTransactionsAsync(userId));
    }

    [HttpGet("transaction/{id}")]
    public async Task<IActionResult> GetTransactionById([FromRoute] int id)
    {
        return Ok(await _transactionService.GetTransactionByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionModel model)
    {
        await _transactionService.CreateTransactionAsync(model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
    {
        await _transactionService.DeleteTransactionAsync(id);

        return Ok();
    }
}
