<<<<<<< HEAD
﻿using FlowerShopManagement.Application.Models;
using MimeKit;

namespace FlowerShopManagement.Application.Interfaces;

public interface IEmailService
{
    public Task<bool> SendAsync(MimeMessage mimeMessage);
    public bool Send(MimeMessage mimeMessage);
    public MimeMessage CreateMimeMessage(ImportModel supplyForm);
}
=======
﻿using FlowerShopManagement.Application.Models;
using MimeKit;

namespace FlowerShopManagement.Application.Interfaces;

public interface IEmailService
{
    public Task<bool> SendAsync(MimeMessage mimeMessage);
    public bool Send(MimeMessage mimeMessage);
    public MimeMessage CreateMimeMessage(ImportModel supplyForm);
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
