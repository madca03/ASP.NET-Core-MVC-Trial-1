CREATE TABLE [dbo].[Employees](  
    [EmployeeID] [int] IDENTITY(1,1) NOT NULL,  
    [EmployeeName] [varchar](50) NULL,  
    [PhoneNumber] [varchar](50) NULL,  
    [SkillID] [int] null,  
    [YearsExperience] [int] null,  
PRIMARY KEY CLUSTERED   
(  
    [EmployeeID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  