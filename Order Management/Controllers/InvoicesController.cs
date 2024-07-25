using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Dto;
using OrderManagement.Repo;

namespace Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InvoicesController : ControllerBase
    {
        private readonly OrderManagementDbContext _context;

        public InvoicesController(OrderManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/invoices
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices()
        {
            var invoices = await _context.Invoices
                .Select(invoice => new InvoiceDto
                {
                    InvoiceId = invoice.InvoiceId,
                    OrderId = invoice.OrderId,
                    InvoiceDate = invoice.InvoiceDate,
                    TotalAmount = invoice.TotalAmount
                }).ToListAsync();

            return Ok(invoices);
        }

       
        [HttpGet("{invoiceId}")]  // GET: api/invoices/{invoiceId}
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int invoiceId)
        {
            var invoice = await _context.Invoices
                .Where(i => i.InvoiceId == invoiceId)
                .Select(invoice => new InvoiceDto
                {
                    InvoiceId = invoice.InvoiceId,
                    OrderId = invoice.OrderId,
                    InvoiceDate = invoice.InvoiceDate,
                    TotalAmount = invoice.TotalAmount
                }).FirstOrDefaultAsync();

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

    }
}
