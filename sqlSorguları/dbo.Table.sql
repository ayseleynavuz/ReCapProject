CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[BrandId] INT NOT NULL ,
	[ColorId] INT NOT NULL ,
	[ModelYear] datetime null,
	[DailyPrice] int null,
	[Description] nvarchar(50) null,
	primary key clustered ([Id] asc),
	constraint [FK_Cars_Brands]  foreign key (BrandId) references Brands(BrandId),
	constraint [FK_Cars_Colors]  foreign key (ColorId) references Colors(ColorId)
);
