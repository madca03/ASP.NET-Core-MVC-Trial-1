CREATE TABLE [dbo].[Skills](  
    [SkillID] [int] IDENTITY(1,1) NOT NULL,  
    [Title] [varchar](50) NULL,  
PRIMARY KEY CLUSTERED   
(  
    [SkillID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  