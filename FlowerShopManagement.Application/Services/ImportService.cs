<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Interfaces;
using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using System.Text;

namespace FlowerShopManagement.Application.Services;

public class ImportService : IImportService
{
    private readonly IImportRepository _importRepository;
    private readonly IProductRepository _productRepository;
    private readonly IEmailService _mailService;

    public ImportService(IImportRepository importRepository, IProductRepository productRepository, IEmailService mailService)
    {
        _importRepository = importRepository;
        _productRepository = productRepository;
        _mailService = mailService;
    }

    public List<ImportModel> GetRequests()
    {
        var result = new List<ImportModel>();
        try
        {
            var requests = _importRepository.GetRequests();

            foreach (var request in requests)
            {
                var model = new ImportModel(request);
                result.Add(model);
            }

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ImportModel?> GetRequest(string id)
    {
        try
        {
            var request = await _importRepository.GetById(id);

            if (request == null) return null;

            return new ImportModel(request);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string?> Verify(string id, List<int> deliveredQties, List<string> notes, string userId, string username)
    {
        try
        {
            var importDetail = await _importRepository.GetById(id);

            if (importDetail == null) return "Import not found!";

            var isCompleted = true;

            for (int i = 0; i < deliveredQties.Count; i++)
            {
                if (importDetail.details[i].orderQty != deliveredQties[i]) isCompleted = false;

                importDetail.details[i].deliveredQty = deliveredQties[i];
                importDetail.details[i].note = notes[i];
            }

            importDetail.checkedBy._id = userId;
            importDetail.checkedBy.name = username;

            if (isCompleted) importDetail.status = Core.Enums.ImportStatus.Completed;

            await _importRepository.UpdateById(id, importDetail);

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateStock(string importId)
    {
        try
        {
            var importDetail = await _importRepository.GetById(importId);

            if (importDetail == null) return;

            foreach (var item in importDetail.details)
            { 
                var product = await _productRepository.GetById(item._id);

                if (product == null) return;

                product._amount += item.deliveredQty;

                await _productRepository.UpdateById(product._id, product);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> SendRequest(ImportModel form)
    {
        var mimeMessage = _mailService.CreateMimeMessage(form);
        var request = new Import(form.Supplier, form.Details, form.CreatedBy);

        try
        {
            // Save request to database before really sending it
            await _importRepository.Add(request);

            // Send request
            return _mailService.Send(mimeMessage);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public ImportModel CreateRequestForm(
        List<ProductDetailModel> products,  
        SupplierModel suppliers, 
        List<int> requestQty,
        string staffId, string staffName, string htmlPath)
    {
        var form = new ImportModel(
            suppliers, 
            products, requestQty, 
            staffName, staffId);

        // Set html part
        var builder = new StringBuilder();

        using (var reader = new StreamReader(htmlPath))
        {
            while (!reader.EndOfStream)
            {
                var text = reader.ReadLine();

                builder.AppendLine(text);

                if (text != null && text.Contains("req-items-tab"))
                {
                    // Table header
                    builder.AppendLine("        <tr>");
                    builder.AppendLine("          <th>No.</th>");
                    builder.AppendLine("          <th>Product Name</th>");
                    builder.AppendLine("          <th>Amount</th>");
                    builder.AppendLine("        <tr>");

                    // Pass data to template
                    for (int i = 0; i < form.Details.Count; i++)
                    {
                        builder.AppendLine("        <tr>");
                        builder.AppendLine("          <td class=\"product-index\">" + (i + 1).ToString() + "</td>");
                        builder.AppendLine("          <td>" + form.Details[i].name + "</td>");
                        builder.AppendLine("          <td>" + form.Details[i].orderQty + "</td>");
                        builder.AppendLine("        <tr>");
                    }
                }
            }
        }

        builder.Replace("Supplier_Name", form.Supplier.name);

        form.HtmlPart = builder.ToString();

        return form;
    }
}
=======
﻿using FlowerShopManagement.Application.Interfaces;
using FlowerShopManagement.Application.Interfaces.MongoDB;
using FlowerShopManagement.Application.Models;
using FlowerShopManagement.Application.MongoDB.Interfaces;
using FlowerShopManagement.Core.Entities;
using System.Text;

namespace FlowerShopManagement.Application.Services;

public class ImportService : IImportService
{
    private readonly IImportRepository _importRepository;
    private readonly IProductRepository _productRepository;
    private readonly IEmailService _mailService;

    public ImportService(IImportRepository importRepository, IProductRepository productRepository, IEmailService mailService)
    {
        _importRepository = importRepository;
        _productRepository = productRepository;
        _mailService = mailService;
    }

    public List<ImportModel> GetRequests()
    {
        var result = new List<ImportModel>();
        try
        {
            var requests = _importRepository.GetRequests();

            foreach (var request in requests)
            {
                var model = new ImportModel(request);
                result.Add(model);
            }

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ImportModel?> GetRequest(string id)
    {
        try
        {
            var request = await _importRepository.GetById(id);

            if (request == null) return null;

            return new ImportModel(request);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string?> Verify(string id, List<int> deliveredQties, List<string> notes, string userId, string username)
    {
        try
        {
            var importDetail = await _importRepository.GetById(id);

            if (importDetail == null) return "Import not found!";

            var isCompleted = true;

            for (int i = 0; i < deliveredQties.Count; i++)
            {
                if (importDetail.details[i].orderQty != deliveredQties[i]) isCompleted = false;

                importDetail.details[i].deliveredQty = deliveredQties[i];
                importDetail.details[i].note = notes[i];
            }

            importDetail.checkedBy._id = userId;
            importDetail.checkedBy.name = username;

            if (isCompleted) importDetail.status = Core.Enums.ImportStatus.Completed;

            await _importRepository.UpdateById(id, importDetail);

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateStock(string importId)
    {
        try
        {
            var importDetail = await _importRepository.GetById(importId);

            if (importDetail == null) return;

            foreach (var item in importDetail.details)
            { 
                var product = await _productRepository.GetById(item._id);

                if (product == null) return;

                product._amount += item.deliveredQty;

                await _productRepository.UpdateById(product._id, product);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> SendRequest(ImportModel form)
    {
        var mimeMessage = _mailService.CreateMimeMessage(form);
        var request = new Import(form.Supplier, form.Details, form.CreatedBy);

        try
        {
            // Save request to database before really sending it
            await _importRepository.Add(request);

            // Send request
            return _mailService.Send(mimeMessage);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public ImportModel CreateRequestForm(
        List<ProductDetailModel> products,  
        SupplierModel suppliers, 
        List<int> requestQty,
        string staffId, string staffName, string htmlPath)
    {
        var form = new ImportModel(
            suppliers, 
            products, requestQty, 
            staffName, staffId);

        // Set html part
        var builder = new StringBuilder();

        using (var reader = new StreamReader(htmlPath))
        {
            while (!reader.EndOfStream)
            {
                var text = reader.ReadLine();

                builder.AppendLine(text);

                if (text != null && text.Contains("req-items-tab"))
                {
                    // Table header
                    builder.AppendLine("        <tr>");
                    builder.AppendLine("          <th>No.</th>");
                    builder.AppendLine("          <th>Product Name</th>");
                    builder.AppendLine("          <th>Amount</th>");
                    builder.AppendLine("        <tr>");

                    // Pass data to template
                    for (int i = 0; i < form.Details.Count; i++)
                    {
                        builder.AppendLine("        <tr>");
                        builder.AppendLine("          <td class=\"product-index\">" + (i + 1).ToString() + "</td>");
                        builder.AppendLine("          <td>" + form.Details[i].name + "</td>");
                        builder.AppendLine("          <td>" + form.Details[i].orderQty + "</td>");
                        builder.AppendLine("        <tr>");
                    }
                }
            }
        }

        builder.Replace("Supplier_Name", form.Supplier.name);

        form.HtmlPart = builder.ToString();

        return form;
    }
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
