<<<<<<< HEAD
﻿using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace FlowerShopManagement.Application.Models;

public class UserModel1
{
    public string _id { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string PhoneNumber { get; set; } = string.Empty;

	public UserModel1()
    {

    }
	public UserModel1(UserModel1 entity)
	{
		_id = entity._id;
		Email = entity.Email;
		PhoneNumber = entity.PhoneNumber;
		Name = entity.Name;

	}
	public static UserModel1 ToModel(User entity)
	{
        UserModel1 a = new UserModel1();
		a._id = entity._id;
		a.Email = entity.email;
		a.PhoneNumber = entity.phoneNumber;
		a.Name = entity.name;
        return a;
	}
    
}

public class UserModel
{
    public string _id { get; set; }

    // Account
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid email!")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^([\\+]?84[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Invalid phone number!")]
    public string PhoneNumber { get; set; }

    public string Password { get; set; }

    public Role Role { get; set; } = Role.Customer;

    // Profile
    [Required]
    [RegularExpression(@"^([A-Z][a-zA-Z_\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$)", ErrorMessage = "Invalid name!")]
    public string Name { get; set; }

    public string Avatar { get; set; } = "avt3.png";

    public Gender Gender { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime BirthYear { get; set; }
    public List<InforDeliveryModel> InforDelivery = new List<InforDeliveryModel>();

    public List<string> FavProductIds { get; set; }

    // Extra
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime LastModified { get; set; }

    // More Extra
    public IFormFile? FormFile { get; set; } // help to generate user avatar, no need to store on dB nha 

    public UserModel(User entity)
    {
        _id = entity._id;

        Email = entity.email;
        PhoneNumber = entity.phoneNumber;
        Password = entity.password;
        Role = entity.role;

        Name = entity.name;
        Avatar = entity.avatar;
        Gender = entity.gender;
        BirthYear = entity.birthYear;
        foreach(var i in entity.inforDelivery)
        {
            InforDelivery.Add(new InforDeliveryModel(i));

        }
        FavProductIds = entity.favProductIds;

        CreatedDate = entity.createdDate;
        LastModified = entity.lastModified;
    }

    public UserModel()
    {
        //_id = new Guid().ToString();
        //_password = string.Empty;
        //CreatedDate = DateTime.Now;
        //Role = Role.Customer;
        //Gender = Gender.Female;
        //Addresses = new string[2];
    }

    public void ToEntity(ref User entity)
    {
        entity._id = _id;

        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.password = Password;
        entity.role = Role;

        entity.name = Name;
        entity.avatar = Avatar;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }
       
        entity.favProductIds = FavProductIds;

        entity.createdDate = CreatedDate;
        entity.lastModified = LastModified;
    }
    public User ToEntity()
    {
        var entity = new User();

        entity._id = _id;
        entity.password = Password;
        entity.role = Role;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }

        entity.createdDate = CreatedDate;
        entity.lastModified = LastModified;
        entity.name = Name;
        entity.email = Email;
        entity.avatar = Avatar;
        entity.favProductIds = FavProductIds;

        return entity;
    }

	public User ToNewEntity()
    {
        var entity = new User();

        entity.password = Password;
        entity.name = Name;
        entity.avatar = Avatar;
        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }


        return entity;
    }
    public async Task<User> ToNewEntity(string wwwRootPath)
    {
        var entity = new User();

        if (this.FormFile != null && this.FormFile.Length > 0)
        {
            string fileName = this.FormFile.FileName;
            string path = Path.Combine(wwwRootPath + "/avatar/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await this.FormFile.CopyToAsync(fileStream);
                entity.avatar = this.FormFile.FileName;
            }
        }
        else
        {
            entity.avatar = "avt2.png";

        }
        entity.name = Name;
        entity.password = Password;
        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }


        return entity;
    }
    public bool IsPasswordMatched(string encryptedPassword)
    {
        return Password == encryptedPassword;
       
    }
}

public class UserBasicInfoModel
{
	public string _id { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid email!")]
    public string Email { get; set; } = string.Empty;

    [Required]

    [RegularExpression(@"^([\\+]?84[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Invalid phone number!")]
    public string PhoneNumber { get; set; } = string.Empty;


    // Profile
    [Required]
	[RegularExpression(@"^([A-Z][a-zA-Z_\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$)", ErrorMessage = "Invalid name!")]

	//[RegularExpression(@"^([A-Z][a-zA-Z_\s]*$)")]
    public string Name { get; set; } = string.Empty;
	public string Avatar { get; set; } = "user.png";

    [Required]
	public Gender Gender { get; set; } = Gender.Male;

    [DataType(DataType.DateTime)]
    public DateTime BirthYear { get; set; } = DateTime.UtcNow;
	// More Extra

	public IFormFile? FormFile { get; set; } // help to generate user avatar, no need to store on dB nha 

    public UserBasicInfoModel(User entity)
    {
        _id = entity._id;

        Email = entity.email;
        PhoneNumber = entity.phoneNumber;
        Name = entity.name;
        Avatar = entity.avatar;
        Gender = entity.gender;
        BirthYear = entity.birthYear;

    }
    public UserBasicInfoModel() { }

	public async Task ChangesTracking(User editUser,string root)
	{
		//_id = editUser._id;
		if (editUser.email != this.Email)
		{
			editUser.email = Email;

		}
		if (editUser.phoneNumber != this.PhoneNumber)
		{
			editUser.phoneNumber = PhoneNumber;

		}
		if (editUser.name != this.Name)
		{
			editUser.name = Name;

		}
		if (editUser.birthYear != this.BirthYear)
		{
			editUser.birthYear = BirthYear;
		}
		if (editUser.gender != this.Gender)
		{
			editUser.gender = Gender;

		}
		//change avatar
		if (this.FormFile != null && this.FormFile.Length > 0)
		{
			string fileName = this.FormFile.FileName;
			string path = Path.Combine(root + "/avatar/", fileName);
			using (var fileStream = new FileStream(path, FileMode.Create))
			{
				await this.FormFile.CopyToAsync(fileStream);
				editUser.avatar = this.FormFile.FileName;
			}
		}
		//editUser.Avatar = Avatar;

		//editUser.Addresses = Addresses;
	}
	
	
=======
﻿using FlowerShopManagement.Core.Entities;
using FlowerShopManagement.Core.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace FlowerShopManagement.Application.Models;

public class UserModel1
{
    public string _id { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string PhoneNumber { get; set; } = string.Empty;

	public UserModel1()
    {

    }
	public UserModel1(UserModel1 entity)
	{
		_id = entity._id;
		Email = entity.Email;
		PhoneNumber = entity.PhoneNumber;
		Name = entity.Name;

	}
	public static UserModel1 ToModel(User entity)
	{
        UserModel1 a = new UserModel1();
		a._id = entity._id;
		a.Email = entity.email;
		a.PhoneNumber = entity.phoneNumber;
		a.Name = entity.name;
        return a;
	}
    
}

public class UserModel
{
    public string _id { get; set; }

    // Account
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid email!")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^([\\+]?84[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Invalid phone number!")]
    public string PhoneNumber { get; set; }

    public string Password { get; set; }

    public Role Role { get; set; } = Role.Customer;

    // Profile
    [Required]
    [RegularExpression(@"^([A-Z][a-zA-Z_\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$)", ErrorMessage = "Invalid name!")]
    public string Name { get; set; }

    public string Avatar { get; set; } = "avt3.png";

    public Gender Gender { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime BirthYear { get; set; }
    public List<InforDeliveryModel> InforDelivery = new List<InforDeliveryModel>();

    public List<string> FavProductIds { get; set; }

    // Extra
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime LastModified { get; set; }

    // More Extra
    public IFormFile? FormFile { get; set; } // help to generate user avatar, no need to store on dB nha 

    public UserModel(User entity)
    {
        _id = entity._id;

        Email = entity.email;
        PhoneNumber = entity.phoneNumber;
        Password = entity.password;
        Role = entity.role;

        Name = entity.name;
        Avatar = entity.avatar;
        Gender = entity.gender;
        BirthYear = entity.birthYear;
        foreach(var i in entity.inforDelivery)
        {
            InforDelivery.Add(new InforDeliveryModel(i));

        }
        FavProductIds = entity.favProductIds;

        CreatedDate = entity.createdDate;
        LastModified = entity.lastModified;
    }

    public UserModel()
    {
        //_id = new Guid().ToString();
        //_password = string.Empty;
        //CreatedDate = DateTime.Now;
        //Role = Role.Customer;
        //Gender = Gender.Female;
        //Addresses = new string[2];
    }

    public void ToEntity(ref User entity)
    {
        entity._id = _id;

        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.password = Password;
        entity.role = Role;

        entity.name = Name;
        entity.avatar = Avatar;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }
       
        entity.favProductIds = FavProductIds;

        entity.createdDate = CreatedDate;
        entity.lastModified = LastModified;
    }
    public User ToEntity()
    {
        var entity = new User();

        entity._id = _id;
        entity.password = Password;
        entity.role = Role;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }

        entity.createdDate = CreatedDate;
        entity.lastModified = LastModified;
        entity.name = Name;
        entity.email = Email;
        entity.avatar = Avatar;
        entity.favProductIds = FavProductIds;

        return entity;
    }

	public User ToNewEntity()
    {
        var entity = new User();

        entity.password = Password;
        entity.name = Name;
        entity.avatar = Avatar;
        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }


        return entity;
    }
    public async Task<User> ToNewEntity(string wwwRootPath)
    {
        var entity = new User();

        if (this.FormFile != null && this.FormFile.Length > 0)
        {
            string fileName = this.FormFile.FileName;
            string path = Path.Combine(wwwRootPath + "/avatar/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await this.FormFile.CopyToAsync(fileStream);
                entity.avatar = this.FormFile.FileName;
            }
        }
        else
        {
            entity.avatar = "avt2.png";

        }
        entity.name = Name;
        entity.password = Password;
        entity.email = Email;
        entity.phoneNumber = PhoneNumber;
        entity.gender = Gender;
        entity.birthYear = BirthYear;
        foreach (var i in InforDelivery)
        {
            entity.inforDelivery.Add(i.ToEntity());

        }


        return entity;
    }
    public bool IsPasswordMatched(string encryptedPassword)
    {
        return Password == encryptedPassword;
       
    }
}

public class UserBasicInfoModel
{
	public string _id { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid email!")]
    public string Email { get; set; } = string.Empty;

    [Required]

    [RegularExpression(@"^([\\+]?84[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Invalid phone number!")]
    public string PhoneNumber { get; set; } = string.Empty;


    // Profile
    [Required]
	[RegularExpression(@"^([A-Z][a-zA-Z_\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễếệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]*$)", ErrorMessage = "Invalid name!")]

	//[RegularExpression(@"^([A-Z][a-zA-Z_\s]*$)")]
    public string Name { get; set; } = string.Empty;
	public string Avatar { get; set; } = "user.png";

    [Required]
	public Gender Gender { get; set; } = Gender.Male;

    [DataType(DataType.DateTime)]
    public DateTime BirthYear { get; set; } = DateTime.UtcNow;
	// More Extra

	public IFormFile? FormFile { get; set; } // help to generate user avatar, no need to store on dB nha 

    public UserBasicInfoModel(User entity)
    {
        _id = entity._id;

        Email = entity.email;
        PhoneNumber = entity.phoneNumber;
        Name = entity.name;
        Avatar = entity.avatar;
        Gender = entity.gender;
        BirthYear = entity.birthYear;

    }
    public UserBasicInfoModel() { }

	public async Task ChangesTracking(User editUser,string root)
	{
		//_id = editUser._id;
		if (editUser.email != this.Email)
		{
			editUser.email = Email;

		}
		if (editUser.phoneNumber != this.PhoneNumber)
		{
			editUser.phoneNumber = PhoneNumber;

		}
		if (editUser.name != this.Name)
		{
			editUser.name = Name;

		}
		if (editUser.birthYear != this.BirthYear)
		{
			editUser.birthYear = BirthYear;
		}
		if (editUser.gender != this.Gender)
		{
			editUser.gender = Gender;

		}
		//change avatar
		if (this.FormFile != null && this.FormFile.Length > 0)
		{
			string fileName = this.FormFile.FileName;
			string path = Path.Combine(root + "/avatar/", fileName);
			using (var fileStream = new FileStream(path, FileMode.Create))
			{
				await this.FormFile.CopyToAsync(fileStream);
				editUser.avatar = this.FormFile.FileName;
			}
		}
		//editUser.Avatar = Avatar;

		//editUser.Addresses = Addresses;
	}
	
	
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
}