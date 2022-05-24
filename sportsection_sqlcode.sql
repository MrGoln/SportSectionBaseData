/****** Object:  Table [dbo].[Sports]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sports](
	[SportName] [nvarchar](50) NOT NULL,
	[SportsRules] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[SportName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportsAndAll]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportsAndAll](
	[ID] [int] NOT NULL,
	[Sports] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SportsAndTrainer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Sports] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportsMan]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportsMan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Trainer] [nvarchar](50) NULL,
	[SportsRank] [nvarchar](50) NULL,
	[NumberPhone] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[SportName] [nvarchar](50) NULL,
 CONSTRAINT [PK_SportsManBeta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportsManAndTrainer]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportsManAndTrainer](
	[IDSportsMan] [int] NOT NULL,
	[IDTrainer] [int] NOT NULL,
 CONSTRAINT [PK_SportsManAndTrainer] PRIMARY KEY CLUSTERED 
(
	[IDSportsMan] ASC,
	[IDTrainer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportsTimeGroup]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportsTimeGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SportName] [nvarchar](50) NULL,
	[Monday] [nvarchar](50) NULL,
	[Tuesday] [nvarchar](50) NULL,
	[Wednesday] [nvarchar](50) NULL,
	[Thusday] [nvarchar](50) NULL,
	[Friday] [nvarchar](50) NULL,
	[Saturday] [nvarchar](50) NULL,
	[Sunday] [nvarchar](50) NULL,
 CONSTRAINT [PK_SportsTimeGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 24.05.2022 15:52:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[SportsRank] [nvarchar](50) NULL,
	[NumberPhone] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[SportName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrainerBeta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'бег', N'https://ru.wikipedia.org/wiki/%D0%91%D0%B5%D0%B3')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'метание диска', N'https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'метание копья', N'https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'метание молота', N'https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'прыжки в высоту', N'https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D1%8B%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'прыжки в длину', N'https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D1%8B%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'прыжки с шестом', N'https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D1%8B%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'толкание ядра', N'https://ru.wikipedia.org/wiki/%D0%A2%D0%BE%D0%BB%D')
INSERT [dbo].[Sports] ([SportName], [SportsRules]) VALUES (N'тройные прыжки', N'https://ru.wikipedia.org/wiki/%D0%A2%D1%80%D0%BE%D')
GO
SET IDENTITY_INSERT [dbo].[SportsMan] ON 

INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (1, N'Акименко Михаил Сергеевич', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79512351512', CAST(N'2011-01-24' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (2, N'Анжелика Александровна Сидорова', N'Сергей Сергеевич Сергеев', N'третий юношеский спортивный разряд', N'+79431334532', CAST(N'2011-06-12' AS Date), N'метание молота')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (3, N'Аплачкин Артём Игоревич', N'Сергей Сергеевич Сергеев', N'второй юношеский спортивный разряд', N'+79415165634', CAST(N'2011-11-04' AS Date), N'метание диска')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (4, N'Арясова Татьяна Алексеевна', N'Сергей Сергеевич Сергеев', N'первый юношеский спортивный разряд', N'+79512346513', CAST(N'2012-06-23' AS Date), N'метание копья')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (5, N'Биктагирова Мадина Ульфатовна', N'Сергей Сергеевич Сергеев', N'первый юношеский спортивный разряд', N'+79412363214', CAST(N'2011-12-03' AS Date), N'метание молота')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (6, N'Богомолова Галина Евгеньевна', N'Сергей Сергеевич Сергеев', N'второй юношеский спортивный разряд', N'+79414121443', CAST(N'2011-12-19' AS Date), N'метание диска')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (7, N'Болоховец Олег Валерьевич', N'Сергей Сергеевич Сергеев', N'первый юношеский спортивный разряд', N'+79465163424', CAST(N'2009-04-27' AS Date), N'метание копья')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (8, N'Бондарчук Ирина Ивановна', N'Сергей Сергеевич Сергеев', N'третий юношеский спортивный разряд', N'+79416125633', CAST(N'2008-03-01' AS Date), N'метание диска')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (9, N'Бурангулова Рамиля Мунаваровна', N'Сергей Сергеевич Сергеев', N'первый юношеский спортивный разряд', N'+79424515253', CAST(N'2009-01-20' AS Date), N'метание молота')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (10, N'Бурмакин Дмитрий Валерьевич', N'Сергей Сергеевич Сергеев', N'второй юношеский спортивный разряд', N'+79461562546', CAST(N'2010-03-02' AS Date), N'метание копья')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (11, N'Бухаров Никита Олегович', N'Сергей Сергеевич Сергеев', N'первый юношеский спортивный разряд', N'+79341235345', CAST(N'2012-03-02' AS Date), N'метание молота')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (12, N'Вейенберг Надежда Олеговна', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79413251256', CAST(N'2009-10-25' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (13, N'Выговская Гульнара Гайнуловна', N'Постный Виктор Васильевич', N'второй юношеский спортивный разряд', N'+79412566123', CAST(N'2011-09-04' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (14, N'Гайнетдинова Гульшат Иршатовна', N'Постный Виктор Васильевич', N'третий юношеский спортивный разряд', N'+79412561763', CAST(N'2010-04-25' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (15, N'Галкина Гульнара Искандеровна', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79412325221', CAST(N'2011-03-19' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (16, N'Галлямова Надежда Викторовна', N'Постный Виктор Васильевич', N'второй юношеский спортивный разряд', N'+79412167161', CAST(N'2014-04-12' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (17, N'Глок Ольга Алексеевна', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79461613532', CAST(N'2013-09-11' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (18, N'Григорьева Лидия Николаевна', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79412361563', CAST(N'2011-03-23' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (19, N'Гущинский Виктор Геннадьевич', N'Монастырский Михаил Исаакович', N'второй юношеский спортивный разряд', N'+79314514233', CAST(N'2013-10-25' AS Date), N'бег')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (20, N'Дасько Михаил Антонович', N'Постный Виктор Васильевич', N'второй юношеский спортивный разряд', N'+79412351245', CAST(N'2009-06-23' AS Date), N'толкание ядра')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (21, N'Дектярёва Татьяна Валерьевна', N'Карманукова Дарья Игоревна', N'второй юношеский спортивный разряд', N'+79351425134', CAST(N'2011-03-12' AS Date), N'тройные прыжки')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (22, N'Есипчук Оксана Александровна', N'Карманукова Дарья Игоревна', N'первый юношеский спортивный разряд', N'+79324211423', CAST(N'2010-02-24' AS Date), N'прыжки с шестом')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (23, N'Жиркова Татьяна Юрьевна', N'Монастырский Михаил Исаакович', N'первый юношеский спортивный разряд', N'+79241242155', CAST(N'2013-04-02' AS Date), N'бег')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (24, N'Журавлёва Татьяна Владимировна', N'Карманукова Дарья Игоревна', N'третий юношеский спортивный разряд', N'+79321415124', CAST(N'2009-12-25' AS Date), N'прыжки с шестом')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (25, N'Зброжек Оксана Станиславовна', N'Монастырский Михаил Исаакович', N'второй юношеский спортивный разряд', N'+79312351151', CAST(N'2014-03-19' AS Date), N'бег')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (26, N'Иванов Александр Валерьевич', N'Карманукова Дарья Игоревна', N'второй юношеский спортивный разряд', N'+79321451424', CAST(N'2013-09-11' AS Date), N'прыжки в длину')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (27, N'Казанов Игорь Яковлевич', N'Монастырский Михаил Исаакович', N'третий юношеский спортивный разряд', N'+79421412345', CAST(N'2012-07-12' AS Date), N'бег')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (28, N'Калмыков Дмитрий Андреевич', N'Монастырский Михаил Исаакович', N'третий юношеский спортивный разряд', N'+79321515123', CAST(N'2010-09-23' AS Date), N'бег')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (29, N'Коновалова Дарья Ивановна', N'Карманукова Дарья Игоревна', N'первый юношеский спортивный разряд', N'+79412315125', CAST(N'2011-03-21' AS Date), N'прыжки в высоту')
INSERT [dbo].[SportsMan] ([ID], [FullName], [Trainer], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (43, N'Якушкин Олег Олегович', N'Постный Виктор Васильевич', N'первый юношеский спортивный разряд', N'+79412315124', CAST(N'2012-03-21' AS Date), N'толкание ядра')
SET IDENTITY_INSERT [dbo].[SportsMan] OFF
GO
SET IDENTITY_INSERT [dbo].[SportsTimeGroup] ON 

INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (1, N'бег', N'16:00 - 20:00', N'16:00 - 20:00', N'16:00 - 20:00', N'16:00 - 20:00', N'16:00 - 20:00', N'13:00 - 16:00', N'13:00 - 16:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (2, N'метание диска', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'12:00 - 15:00', N'12:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (3, N'метание копья', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'12:00 - 15:00', N'12:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (4, N'метание молота', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'15:00 - 19:00', N'12:00 - 15:00', N'12:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (5, N'прыжки в высоту', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'10:00 - 15:00', N'10:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (6, N'прыжки в длину', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'10:00 - 15:00', N'10:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (7, N'прыжки с шестом', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'10:00 - 15:00', N'10:00 - 15:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (8, N'толкание ядра', N'14:00 - 18:00', N'14:00 - 18:00', N'14:00 - 18:00', N'14:00 - 18:00', N'14:00 - 18:00', N'11:00 - 14:00', N'11:00 - 14:00')
INSERT [dbo].[SportsTimeGroup] ([ID], [SportName], [Monday], [Tuesday], [Wednesday], [Thusday], [Friday], [Saturday], [Sunday]) VALUES (9, N'тройные прыжки', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'14:00 - 20:00', N'10:00 - 15:00', N'10:00 - 15:00')
SET IDENTITY_INSERT [dbo].[SportsTimeGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainer] ON 

INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (2, N'Карманукова Дарья Игоревна', N'тренер высшей квалификационной категории', N'+79245612345', CAST(N'1986-02-15' AS Date), N'прыжки в высоту')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (3, N'Карманукова Дарья Игоревна', N'тренер высшей квалификационной категории', N'+79245612345', CAST(N'1986-02-15' AS Date), N'прыжки в длину')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (4, N'Карманукова Дарья Игоревна', N'тренер высшей квалификационной категории', N'+79245612345', CAST(N'1986-02-15' AS Date), N'прыжки с шестом')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (5, N'Карманукова Дарья Игоревна', N'тренер высшей квалификационной категории', N'+79245612345', CAST(N'1986-02-15' AS Date), N'тройные прыжки')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (6, N'Монастырский Михаил Исаакович', N'тренер высшей квалификационной категории', N'+79456125642', CAST(N'1956-01-30' AS Date), N'бег')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (7, N'Постный Виктор Васильевич', N'тренер первой квалификационной категории', N'+79456723412', CAST(N'1994-09-16' AS Date), N'толкание ядра')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (8, N'Сергей Сергеевич Сергеев', N'тренер высшей квалификационной категории', N'+79754151511', CAST(N'1958-03-25' AS Date), N'метание диска')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (9, N'Сергей Сергеевич Сергеев', N'тренер высшей квалификационной категории', N'+79754151511', CAST(N'1958-03-25' AS Date), N'метание копья')
INSERT [dbo].[Trainer] ([ID], [FullName], [SportsRank], [NumberPhone], [DateOfBirth], [SportName]) VALUES (10, N'Сергей Сергеевич Сергеев', N'тренер высшей квалификационной категории', N'+79754151511', CAST(N'1958-03-25' AS Date), N'метание молота')
SET IDENTITY_INSERT [dbo].[Trainer] OFF
GO
ALTER TABLE [dbo].[SportsAndAll]  WITH CHECK ADD  CONSTRAINT [FK_SportsAndTrainer_Sports] FOREIGN KEY([Sports])
REFERENCES [dbo].[Sports] ([SportName])
GO
ALTER TABLE [dbo].[SportsAndAll] CHECK CONSTRAINT [FK_SportsAndTrainer_Sports]
GO
ALTER TABLE [dbo].[SportsAndAll]  WITH CHECK ADD  CONSTRAINT [FK_SportsAndTrainer_SportsMan] FOREIGN KEY([ID])
REFERENCES [dbo].[SportsMan] ([ID])
GO
ALTER TABLE [dbo].[SportsAndAll] CHECK CONSTRAINT [FK_SportsAndTrainer_SportsMan]
GO
ALTER TABLE [dbo].[SportsAndAll]  WITH CHECK ADD  CONSTRAINT [FK_SportsAndTrainer_SportsTimeGroup] FOREIGN KEY([ID])
REFERENCES [dbo].[SportsTimeGroup] ([ID])
GO
ALTER TABLE [dbo].[SportsAndAll] CHECK CONSTRAINT [FK_SportsAndTrainer_SportsTimeGroup]
GO
ALTER TABLE [dbo].[SportsAndAll]  WITH CHECK ADD  CONSTRAINT [FK_SportsAndTrainer_Trainer] FOREIGN KEY([ID])
REFERENCES [dbo].[Trainer] ([ID])
GO
ALTER TABLE [dbo].[SportsAndAll] CHECK CONSTRAINT [FK_SportsAndTrainer_Trainer]
GO
ALTER TABLE [dbo].[SportsManAndTrainer]  WITH CHECK ADD  CONSTRAINT [FK_SportsManAndTrainer_SportsMan] FOREIGN KEY([IDSportsMan])
REFERENCES [dbo].[SportsMan] ([ID])
GO
ALTER TABLE [dbo].[SportsManAndTrainer] CHECK CONSTRAINT [FK_SportsManAndTrainer_SportsMan]
GO
ALTER TABLE [dbo].[SportsManAndTrainer]  WITH CHECK ADD  CONSTRAINT [FK_SportsManAndTrainer_Trainer] FOREIGN KEY([IDTrainer])
REFERENCES [dbo].[Trainer] ([ID])
GO
ALTER TABLE [dbo].[SportsManAndTrainer] CHECK CONSTRAINT [FK_SportsManAndTrainer_Trainer]
GO
USE [master]
GO
ALTER DATABASE [Sport_section] SET  READ_WRITE 
GO
